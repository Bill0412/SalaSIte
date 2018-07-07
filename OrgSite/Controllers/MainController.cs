using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrgSite.Models;

namespace OrgSite.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Index()
        {
            var t = Session["login"];
            List<Massage> massages;
            using(DbAccess db=new DbAccess())
            {
                var q = from x in db.Massages where x.Header== "协会简介" select x.Content;
                //string content= db.Massages.LastOrDefault(x=>x.Header=="协会简介").Content;
                string content = q.First();
                ViewBag.intro = content;
                massages = db.Massages.Where(x=>x.Topic=="部门简介").ToList();
            }
            return View(massages);
        }
        [HttpGet]
        public ActionResult ChangePw()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePw(ResetPasswordViewModel resetPw)
        {
            ViewBag.tips = null;
            if (resetPw.ConfirmPassword != resetPw.Password)
            {
                ViewBag.tips = "两次输入不一致";
                return View();
            }
            else
            {
                using(DbAccess db=new DbAccess())
                {
                    if (ModelState.IsValid)
                    {
                        var one = db.MemberLogins.Find(resetPw.UserName);
                        if (one.PassWord.Trim() != resetPw.OldPassword) { ViewBag.tips = "原密码输入错误"; ; return View(); }
                        db.MemberLogins.Find(resetPw.UserName).PassWord = resetPw.Password;
                        //db.Entry(resetPw).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
            }
            return RedirectToAction("Index");
        }
        public ActionResult Logout()
        {
            var cur = Session["login"];
            if (null != cur)
            {
                //(LoginStatus)cur;
                Session.Remove("login");
            }
            else
            {
                
            }
            return RedirectToAction("Index");
        }

        // GET: Main/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Main/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Login(Models.MemberLogin login)
        {
            
            using(DbAccess db=new DbAccess())
            {
                var user = db.MemberLogins.Where(x => x.UserName.Trim() == login.UserName && x.PassWord.Trim()==login.PassWord);
                if (user.Any())
                {
                    try
                    {
                        short uid = user.SingleOrDefault().UserId;
                        Member uname = db.Members.SingleOrDefault(x => x.UserId == uid);
                        LoginStatus userLogin = new LoginStatus() { UserId = uid, UserName = login.UserName, RealName = uname.RealName };
                        Session["login"] = userLogin;
                    }
                    catch(NullReferenceException e)
                    {
                        ViewBag.err = e.Message;
                    }
                }
                else
                {
                    ViewBag.tips = "密码错误";
                }
            }
            return RedirectToAction("Index", "Members");
        }
    }
}
