namespace OrgSite.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OrgSite.Models.DbAccess>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(OrgSite.Models.DbAccess context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Members.AddOrUpdate(new Models.Member { UserName = "admin", RealName = "Àî¼ÎÄþ", EntryTime = DateTime.Now.Date });
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
