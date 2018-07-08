namespace OrgSite.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("EventAssignment")]
    public partial class EventAssignment
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short UserId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EventId { get; set; }

        [StringLength(20)]
        [Display(Name = "½ÇÉ«")]
        public string Role { get; set; }

        public virtual Event Event { get; set; }

        public virtual Member Member { get; set; }
    }
}
