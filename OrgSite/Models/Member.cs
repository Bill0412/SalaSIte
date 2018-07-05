namespace OrgSite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Member")]
    public partial class Member
    {
        [Key]
        public short UserId { get; set; }

        [StringLength(20)]
        public string UserName { get; set; }

        [Required]
        [StringLength(20)]
        public string RealName { get; set; }

        [StringLength(10)]
        public string Department { get; set; }

        [StringLength(10)]
        public string Position { get; set; }

        [StringLength(30)]
        public string Email { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Birthday { get; set; }

        public DateTime EntryTime { get; set; }

        public DateTime? ResignTime { get; set; }

        [StringLength(150)]
        public string SelfDescription { get; set; }

        public virtual MemberLogin MemberLogin { get; set; }
    }
}
