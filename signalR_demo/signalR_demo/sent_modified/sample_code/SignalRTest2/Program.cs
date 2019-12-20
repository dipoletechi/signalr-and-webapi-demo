using System;
using System.Net;
using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json;
using System.Collections.Generic;
using RestSharp;

namespace SignalRTest2
{
    class Program
    {

        private static string _baseUrl = @"https://sspdemoww:443/DESIGOCCWS/";
        static void Main(string[] args)
        {
            test();
        }

        private static void test()
        {
            //Set connection
            var connection = new HubConnection(_baseUrl);
            //Make proxy to hub based on hub name on server
            var myHub = connection.CreateHubProxy("eventsHub");

            // add handler when receiving new notification

            myHub.On("notifyEvents", (param) => {
                Console.Clear();
                // desserialize the response into list of events
                List<Event> listOfEvents = JsonConvert.DeserializeObject<List<Event>>(Convert.ToString(param));
                if (listOfEvents != null)
                {
                    foreach (Event tempEvent in listOfEvents)
                    {
                        Console.WriteLine();
                        Console.WriteLine("New Event:" + tempEvent.CategoryDescriptor 
                            + " - " + tempEvent.Cause
                            + (tempEvent.MessageText != null && !string.IsNullOrEmpty( tempEvent.MessageText[0]) ? tempEvent.MessageText[0] : string.Empty));
                    }

                    RestClient restClient = new RestClient("http://localhost:5000/demo");

                    //Creating Json object
                    var sendData = new 
                    {
                        Message = JsonConvert.SerializeObject(listOfEvents)
                    };

                    string jsonToSend = JsonConvert.SerializeObject(sendData);
                    RestRequest restRequest = new RestRequest(Method.POST);

                    //Adding Json body as parameter to the post request
                    restRequest.AddParameter("application/json", jsonToSend, ParameterType.RequestBody);

                    IRestResponse restResponse = restClient.Execute(restRequest);
                    Console.WriteLine(restResponse.Content);
                }
            });

            //Start connection

            connection.Start().ContinueWith(task => {
                if (task.IsFaulted)
                {
                    Console.WriteLine("There was an error opening the connection:{0}",
                                      task.Exception.GetBaseException());
                }
                else
                {
                    Console.WriteLine("Connected");
                }

            }).Wait();



            // get access token by post request; username and password should be changed to be as your credintials

            string testURL = _baseUrl + @"api/token";
            var client = new WebClient();
            var response = client.UploadString(testURL, @"grant_type=password&username=baen&password=baen");
            AccessToken accessToken = JsonConvert.DeserializeObject<AccessToken>(response);



            // subscripe to the event hub using the connectionID and access token by post request also
            testURL = _baseUrl + @"api/sr/eventssubscriptions/" + connection.ConnectionId;
            client = new WebClient();
            client.QueryString.Add("sorting", "1");
            string authText = @"Bearer " + accessToken.access_token;
            client.Headers[HttpRequestHeader.Authorization] = authText;
            response = client.UploadString(testURL, string.Empty);


            // connection will stop if the user hit any key on the console
            Console.Read();
            connection.Stop();
        }

    }
}
