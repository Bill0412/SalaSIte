using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using OrgSite.Models;

namespace OrgSite
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Database.SetInitializer<DbAccess>(new DbInit());
        }
    }
    public class DbInit : DropCreateDatabaseAlways<DbAccess>
    {
        protected override void Seed(DbAccess context)
        {
            context.Members.Add(new Models.Member { RealName = "李嘉宁", EntryTime = DateTime.Now.Date ,Email="3@33.c"});
            context.Members.Add(new Models.Member { RealName = "李雨谦", EntryTime = DateTime.Now.Date });
            context.Members.Add(new Models.Member { RealName = "刘真言", EntryTime = DateTime.Now.Date });
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
