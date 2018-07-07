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
        [StringLength(20), Display(Name = "用户名"),Required]
        public string UserName { get; set; }

        [Required]
        [StringLength(20,MinimumLength =4,ErrorMessage ="密码长度不符要求。")]
        [Display(AutoGenerateField = false)]
        public string PassWord { get; set; }

        public virtual Member Member { get; set; }
    }


}
