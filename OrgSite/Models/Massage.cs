namespace OrgSite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Massage")]
    public partial class Massage
    {
        [Key]
        public int mId { get; set; }

        [StringLength(20)]
        public string topic { get; set; }

        [StringLength(50)]
        public string header { get; set; }

        public DateTime? publishingTime { get; set; }

        public int? pId { get; set; }

        public short? UserId { get; set; }

        public short? targetId { get; set; }

        [Column(TypeName = "ntext")]
        public string content { get; set; }
    }
}
