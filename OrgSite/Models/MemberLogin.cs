namespace OrgSite.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

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

    public enum Position
    {
        nobody,members,board,top,other
    }

    public class LoginStatus
    {
        public short UserId { get; set; }
        [MaxLength(20, ErrorMessage = "超出用户名的长度限制。")]
        public string UserName { get; set; }
        public string RealName { get; set; }
        public string Position { get; set; }

        static public bool OfPosition(object o, Position position)
        {
            return false;
        }
        static public bool IsMember(object o)
        {
            return o != null;
        }
        static public bool IsManager(object o)
        {
            if (o == null) return false;
            var u = o as LoginStatus;
            return u.Position != "社员";
        }
    }
}
