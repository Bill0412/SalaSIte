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
}