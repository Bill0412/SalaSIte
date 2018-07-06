namespace OrgSite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Task")]
    public partial class TaskOfEvent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TaskId { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string Summary { get; set; }

        public int EventId { get; set; }

        public short? UserId { get; set; }

        public DateTime CompletionTime { get; set; }

        public virtual Event Event { get; set; }

        public virtual Member Member { get; set; }
    }
}
