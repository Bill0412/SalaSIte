namespace OrgSite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Event")]
    public partial class Event
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Event()
        {
            EventAssignments = new HashSet<EventAssignment>();
            Tasks = new HashSet<TaskOfEvent>();
        }

        public int EventId { get; set; }

        [Required]
        [StringLength(50)]
        public string EventName { get; set; }

        public DateTime? StartingTime { get; set; }

        [StringLength(180)]
        public string Link { get; set; }

        [StringLength(10)]
        public string Status { get; set; }

        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        [StringLength(10)]
        public string Type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EventAssignment> EventAssignments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TaskOfEvent> Tasks { get; set; }
    }
}
