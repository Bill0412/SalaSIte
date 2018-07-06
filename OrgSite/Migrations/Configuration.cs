namespace OrgSite.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using OrgSite.Models;

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
           // context.Members.AddOrUpdate(new Models.Member { RealName = "�����", EntryTime = DateTime.Now.ToLocalTime(), Email = "lijn@zju.edu.cn" });
            //context.Members.AddOrUpdate(new Member { RealName = "����ǫ", EntryTime = DateTime.Now });
            context.Members.AddOrUpdate(new Member { RealName = "������",
                EntryTime = DateTime.Now ,SelfDescription="��ѧ�ߴ������ử�ˣ��Ҿ����ң���һ�����̻���������������������˵�ٻ���"
            + "�㽭��ѧѧ��У������Э���(SALA)����2006��12�£��ԡ���������������Ϊ��ּ�������ø������ʻ����" +
              "���У������Уͬѧ��"});
            //context.MemberLogins.AddOrUpdate(new MemberLogin { UserId = 1, UserName = "no.1", PassWord = "pass",
            //    Member =new Member { UserId=1 } });
            //context.Members.AddOrUpdate(new Member { RealName = "��ѧ��", EntryTime = DateTime.Now });
            //context.Massages.AddOrUpdate(new Massage
            //{
            //    Header = "Э����",
            //    Topic = "Э����",
            //    Content = "�㽭��ѧѧ��У������Э���(SALA)����2006��12�£��ԡ���������������Ϊ��ּ�������ø������ʻ����" +
            //    "���У������Уͬѧ��Э��Э���㽭��ѧ��չ����칫�ң���չίԱ�ᡢУ���ܻᣩ��չ�������������߻�����֯��" +
            //    "����У�Ѻ���������ʿ�Ľ��������ʡ����ּ���չ��ѧ��Դ�ȸ�����"
            //});
            //context.Massages.AddOrUpdate(new Massage
            //{
            //    Header = "У����Դ��",
            //    Topic = "���ż��",
            //    Content = "��֯�߷�У���С�У�ѽ��õȶ�����"
            //});
            //context.Massages.AddOrUpdate(new Massage
            //{
            //    Header = "�������粿",
            //    Topic = "���ż��",
            //    Content = "����Э�����������������"
            //});
            //context.Massages.AddOrUpdate(new Massage
            //{
            //    Header = "�����ƹ㲿",
            //    Topic = "���ż��",
            //    Content = "����Э�����������Ʒ����ƹ�����"
            //});
            //context.Massages.AddOrUpdate(new Massage
            //{
            //    Header = "�ۺ�����",
            //    Topic = "���ż��",
            //    Content = "��չ�ڽ���������񡢿��������µȹ�����"
            //});
            base.Seed(context);
        }
    }
}
