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
        [Display(Name ="活动名称")]
        public string EventName { get; set; }

        [Display(Name = "开始时间")]
        public DateTime? StartingTime { get; set; }

        [StringLength(180)]
        [Display(Name = "相关链接")]
        public string Link { get; set; }

        [StringLength(10)]
        [Display(Name = "状态")]
        public string Status { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "详情")]
        public string Detail { get; set; }

        [StringLength(10)]
        [Display(Name = "类型")]
        public string Type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EventAssignment> EventAssignments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TaskOfEvent> Tasks { get; set; }
    }
}
