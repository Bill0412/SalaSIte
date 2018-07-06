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

        public short UserId { get; set; }

        [Key]
        [StringLength(20), Display(Name = "ÓÃ»§Ãû")]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(AutoGenerateField = false)]
        public string PassWord { get; set; }

        public virtual Member Member { get; set; }
    }
}
