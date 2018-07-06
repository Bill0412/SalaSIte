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
    public class DbInit : DropCreateDatabaseIfModelChanges<DbAccess>
    {
        protected override void Seed(DbAccess context)
        {
            context.Members.Add(new Models.Member { RealName = "李嘉宁", EntryTime = DateTime.Now.ToLocalTime() ,Email="lijn@zju.edu.cn"});
            context.Members.Add(new Member { RealName = "李雨谦", EntryTime = DateTime.Now });
            context.Members.Add(new Member { RealName = "刘真言", EntryTime = DateTime.Now });
            context.Members.Add(new Member { RealName = "老学姐", EntryTime = DateTime.Now });
            context.Massages.Add(new Massage {Header="协会简介", Topic= "协会简介",
                Content = "浙江大学学生校友联络协会成(SALA)立于2006年12月，以“凝聚求是力量”为宗旨，积极用各类优质活动服务" +
                "广大校友与在校同学。协会协助浙江大学发展联络办公室（发展委员会、校友总会）开展各项事务，配合其策划、组织国" +
                "内外校友和社会各界人士的交流、访问、研讨及拓展办学资源等各项活动。"
            });
            context.Massages.Add(new Massage
            {
                Header = "校友资源部",
                Topic = "部门简介",
                Content = "组织走访校友行、校友讲堂等对外活动。"
            });
            context.Massages.Add(new Massage
            {
                Header = "新闻网络部",
                Topic = "部门简介",
                Content = "负责协会的线上宣传渠道。"
            });
            context.Massages.Add(new Massage
            {
                Header = "宣传推广部",
                Topic = "部门简介",
                Content = "负责协会的线下宣传品的设计工作。"
            });
            context.Massages.Add(new Massage
            {
                Header = "综合事务部",
                Topic = "部门简介",
                Content = "开展内建、负责财务、考评、纳新等工作。"
            });
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
