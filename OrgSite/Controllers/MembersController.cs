using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OrgSite.Models;

namespace OrgSite.Controllers
{
    public class MembersController : Controller
    {
        private DbAccess db = new DbAccess();

        // GET: Members
        public ActionResult Index()
        {
            var members = db.Members.Include(m => m.MemberLogin);
            return View(members.ToList());
        }

        // GET: Members/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // GET: Members/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.MemberLogins, "UserId", "PassWord");
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,UserName,RealName,Department,Position,Email,PhoneNumber,Birthday,EntryTime,ResignTime,SelfDescription")] Member member)
        {
            LoginStatus loginStatus = (LoginStatus)Session["login"];
            if (loginStatus.Position == "社员")
            {
                return RedirectToAction("Index");
            }
            member.EntryTime = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Members.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.MemberLogins, "UserId", "PassWord", member.UserId);
            return View(member);
        }

        // GET: Members/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.MemberLogins, "UserId", "PassWord", member.UserId);
            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,UserName,RealName,Department,Position,Email,PhoneNumber,Birthday,EntryTime,ResignTime,SelfDescription")] Member member)
        {
            if (ModelState.IsValid)
            {
                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.MemberLogins, "UserId", "PassWord", member.UserId);
            return View(member);
        }

        // GET: Members/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            if (((LoginStatus)Session["login"]).IsManager())
            {
                Member member = db.Members.Find(id);
                db.Members.Remove(member);
                db.SaveChanges();
            }
            else
            {
                ViewBag.tips = "没有权限";
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
