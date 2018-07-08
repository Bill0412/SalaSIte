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
    public class EventsController : Controller
    {
        private DbAccess db = new DbAccess();

        private bool AccessToEvent(int eid)
        {
            var o = Session["login"];
            if (LoginStatus.IsMember(o))
            {
                short uid = (o as LoginStatus).UserId;
                if (db.EventAssignments.Where(x => x.UserId == uid).Any()) return true;
            }
            return false;
        }
        private List<EventMemberViewModel> GetMembersAccessible(int? eid)
        {
            if (eid == null) return null;
            var q = from x in db.Members
                    join y in db.EventAssignments on x.UserId equals y.UserId
                    select new EventMemberViewModel
                    {
                        Uid=x.UserId,
                        Name=x.RealName,
                        PhoneNumber=x.PhoneNumber,
                        Role=y.Role,
                        Position=x.Position
                    };
            return q.ToList();
        }

        // GET: Events
        public ActionResult Index()
        {
            return View(db.Events.ToList());
        }

        // GET: Events/Details/5
        public ActionResult EventMembers(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var mlist = GetMembersAccessible(id);//Event @event = db.Events.Find(id);
            if (mlist == null)
            {
                return HttpNotFound();
            }
            ViewBag.msg = db.Events.Find(id).EventName;
            ViewBag.eid = id;
            return View(mlist);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventId,EventName,StartingTime,Link,Status,Detail,Type")] Event @event)
        {
            if (ModelState.IsValid)
            {
                @event.StartingTime = DateTime.Now;
                db.Events.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(@event);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventId,EventName,StartingTime,Link,Status,Detail,Type")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
            db.SaveChanges();
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
