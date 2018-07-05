namespace OrgSite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MemberLogin")]
    public partial class MemberLogin
    {
        [Key]
        public short UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string PassWord { get; set; }

        public virtual Member Member { get; set; }
    }
}
