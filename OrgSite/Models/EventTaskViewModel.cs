using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrgSite.Models
{
    public class EventDetailViewModel
    {
        public List<TaskOfEvent> Tasks { get; set; }
        public Event ThisEvent { get; set; }
    }
    public class EventMemberViewModel
    {
        public short Uid { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
        public string Position { get; set; }
    }
}