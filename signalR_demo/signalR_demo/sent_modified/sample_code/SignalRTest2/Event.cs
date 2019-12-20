using System;
using System.Collections.Generic;
using System.Text;

namespace SignalRTest2
{
    public class Link
    {
        public string Rel { get; set; }
        public string Href { get; set; }
        public bool IsTemplated { get; set; }
    }

    public class Command
    {
        public string Id { get; set; }
        public string EventId { get; set; }
        public int Configuration { get; set; }
        public List<Link> _links { get; set; }
    }

    public class DesignationList
    {
        public int ViewId { get; set; }
        public string Descriptor { get; set; }
    }

    public class DescriptionList
    {
        public int ViewId { get; set; }
        public string Descriptor { get; set; }
    }

    public class SourceDesignationList
    {
        public int ViewId { get; set; }
        public string Descriptor { get; set; }
    }

    public class DescriptionLocationsList
    {
        public int ViewId { get; set; }
        public string Descriptor { get; set; }
    }

    public class Link2
    {
        public string Rel { get; set; }
        public string Href { get; set; }
        public bool IsTemplated { get; set; }
    }

    public class Event
    {
        public string Id { get; set; }
        public bool Deleted { get; set; }
        public int EventId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryDescriptor { get; set; }
        public string State { get; set; }
        public string Cause { get; set; }
        public string SrcPropertyId { get; set; }
        public string SrcObservedPropertyId { get; set; }
        public string SrcState { get; set; }
        public int SrcSystemId { get; set; }
        public string SrcViewName { get; set; }
        public string SrcViewDescriptor { get; set; }
        public string SrcDesignation { get; set; }
        public string SrcLocation { get; set; }
        public string SrcName { get; set; }
        public string SrcDescriptor { get; set; }
        public int SrcDisciplineId { get; set; }
        public string SrcDisciplineDescriptor { get; set; }
        public DateTime CreationTime { get; set; }
        public string Direction { get; set; }
        public string InfoDescriptor { get; set; }
        public string InProcessBy { get; set; }
        public List<Command> Commands { get; set; }
        public List<string> MessageText { get; set; }
        public List<DesignationList> DesignationList { get; set; }
        public List<DescriptionList> DescriptionList { get; set; }
        public List<SourceDesignationList> SourceDesignationList { get; set; }
        public List<DescriptionLocationsList> DescriptionLocationsList { get; set; }
        public List<Link2> _links { get; set; }
    }
}
