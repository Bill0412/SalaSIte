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
        public int MId { get; set; }

        [StringLength(20)]
        [Display(Name = "����")]
        public string Topic { get; set; }

        [StringLength(50)]
        [Display(Name = "����")]
        public string Header { get; set; }

        [Display(Name = "����ʱ��")]
        public DateTime? publishingTime { get; set; }

        public int? PId { get; set; }

        public short? UserId { get; set; }

        public short? TargetId { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "����")]
        public string Content { get; set; }
    }
}
