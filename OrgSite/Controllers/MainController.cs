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

        // GET: Main/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Main/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Main/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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

        // GET: Main/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Main/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

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
                var user = db.MemberLogins.Where(x => x.UserName == login.UserName && x.PassWord==login.PassWord);
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
            }
            return RedirectToAction("Index", "Members");
        }
    }
}
