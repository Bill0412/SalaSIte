namespace OrgSite.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbAccess : DbContext
    {
        public DbAccess()
            : base("name=DbAccess")
        {
        }

        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<MemberLogin> MemberLogins { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>()
                .Property(e => e.UserName)
                .IsFixedLength();

            modelBuilder.Entity<Member>()
                .Property(e => e.RealName)
                .IsFixedLength();

            modelBuilder.Entity<Member>()
                .Property(e => e.Department)
                .IsFixedLength();

            modelBuilder.Entity<Member>()
                .Property(e => e.Position)
                .IsFixedLength();

            modelBuilder.Entity<Member>()
                .Property(e => e.Email)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.PhoneNumber)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .HasOptional(e => e.MemberLogin)
                .WithRequired(e => e.Member);

            modelBuilder.Entity<MemberLogin>()
                .Property(e => e.PassWord)
                .IsFixedLength();
        }
    }
}
