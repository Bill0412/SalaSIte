namespace OrgSite.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbAccess : DbContext
    {
        public DbAccess()
            : base("name=DbAccess0")
        {
        }

        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventAssignment> EventAssignments { get; set; }
        public virtual DbSet<Massage> Massages { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<MemberLogin> MemberLogins { get; set; }
        public virtual DbSet<TaskOfEvent> Tasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>()
                .HasMany(e => e.EventAssignments)
                .WithRequired(e => e.Event)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.Tasks)
                .WithRequired(e => e.Event)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.EventAssignments)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasOptional(e => e.MemberLogin)
                .WithRequired(e => e.Member);
        }
    }
}
