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
        [StringLength(20), Display(Name = "用户名")]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(AutoGenerateField = false)]
        public string PassWord { get; set; }

        public virtual Member Member { get; set; }
    }

    public class LoginStatus
    {
        public short UserId { get; set; }
        [MaxLength(20,ErrorMessage ="超出用户名的长度限制。")]
        public string UserName { get; set; }
        public string RealName { get; set; }
    }
}
