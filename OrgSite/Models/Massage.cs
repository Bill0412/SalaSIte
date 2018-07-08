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
        [Display(Name = "主题")]
        public string Topic { get; set; }

        [StringLength(50)]
        [Display(Name = "标题")]
        public string Header { get; set; }

        [Display(Name = "发布时间")]
        public DateTime? publishingTime { get; set; }

        public int? PId { get; set; }

        public short? UserId { get; set; }

        public short? TargetId { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "内容")]
        public string Content { get; set; }
    }
}
