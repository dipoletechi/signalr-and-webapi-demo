using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;


namespace SignalRclient
{
    class Program
    {
       
        static void Main(string[] args)
        {
            HubConnection connection;
            connection = new HubConnectionBuilder()
                .WithUrl("https://sspdemoww:443/DESIGOCCWS/eventsHub")
                .Build();


            //connection.On<klj>("notifyEvents", (param) => {
            //    Console.Clear();
            //    // desserialize the response into list of events
            //    List<Event> listOfEvents = JsonConvert.DeserializeObject<List<Event>>(Convert.ToString(param));
            //    if (listOfEvents != null)
            //    {
            //        foreach (Event tempEvent in listOfEvents)
            //        {
            //            Console.WriteLine();
            //            Console.WriteLine("New Event:" + tempEvent.CategoryDescriptor
            //                + " - " + tempEvent.Cause
            //                + (tempEvent.MessageText != null && !string.IsNullOrEmpty(tempEvent.MessageText[0]) ? tempEvent.MessageText[0] : string.Empty));
            //        }
            //    }
            //});

            

            connection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                Console.WriteLine(user+" says "+message);
                
                RestClient restClient = new RestClient("http://localhost:64112/demo");

                //Creating Json object
                var sendData = new SendData
                {
                    Message = message,
                    User = user
                };

                string jsonToSend = JsonConvert.SerializeObject(sendData);
                RestRequest restRequest = new RestRequest(Method.POST);

                //Adding Json body as parameter to the post request
                restRequest.AddParameter("application/json", jsonToSend, ParameterType.RequestBody);

                IRestResponse restResponse = restClient.Execute(restRequest);                
                Console.WriteLine(restResponse.Content);                
            });

            connection.StartAsync().Wait();                    
            Console.Read();
           
        }
    }

    public class SendData
    {
        public string User { get; set; }
        public string Message { get; set; }
    }
}
