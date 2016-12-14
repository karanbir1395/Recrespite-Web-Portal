using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RecreationalRespiteDashboardDesigned.Models;

namespace RecreationalRespiteDashboardDesigned.Controllers
{
    public class eventsController : Controller
    {
        //  private RecDatabaseModelContainer db = new RecDatabaseModelContainer();
        webApiClass eventHelper = new webApiClass();
        // GET: events
        public ActionResult Index()
        {
            return View(eventHelper.GetEvents());
        }

        // GET: events/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            events events = eventHelper.GetEvent(id);
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);
        }

        // GET: events/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,cost,date,endTime,endDescription,eventImage,eventName,location,region,startTime,totalSeats,region")] events events)
        {
            if (ModelState.IsValid)
            {
                eventHelper.insertEvents(events.cost, events.date, events.eventDescription, events.eventImage, events.eventName, events.eventName, events.startTime, events.totalSeats, events.endTime,events.region);
                return RedirectToAction("Index");
            }

            return View(events);
        }

        // GET: events/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            events events = eventHelper.GetEvent(id);
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);
        }

        // POST: events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,cost,date,endTime,endDescription,eventImage,eventName,location,region,startTime,totalSeats,region")] events events)
        {
            if (ModelState.IsValid)
            {
                eventHelper.EditEvents(events.Id, events.cost, events.date, events.eventDescription, events.eventImage, events.eventName, events.location, events.startTime, events.totalSeats, events.endTime,events.region);
                return RedirectToAction("Index");
            }
            return View(events);
        }

        // GET: events/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            events events = eventHelper.GetEvent(id);
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);
        }

        // POST: events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //events events = eventHelper.GetEvent(id);
            eventHelper.deleteEvent(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
              //  db.Dispose();
            }
            base.Dispose(disposing);
        }


        // GET: events/Participant/5
        public ActionResult Participants(int id)
        {
            if (eventHelper.GetReg(id) == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            return View(eventHelper.GetReg(id));
        }
        // GET: events/Participant/5
        public ActionResult moreInfo(int id,int eventID)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registration reg = eventHelper.GetRegById(id,eventID);
            if (reg== null)
            {
                return HttpNotFound();
            }
            return View(reg);
        }
        // POST: events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /*    [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Participants([Bind(Include = "name,age,email,expectationsAndGoals,paymentType,programOfInterest,recreationalInterest,specialNeeds,allergies,email")] registration registration)
            {
                if (ModelState.IsValid)
                {
                    eventHelper.EditEvents(events.Id, events.cost, events.date, events.eventDescription, events.eventImage, events.eventName, events.location, events.startTime, events.totalSeats, events.endTime, events.region);
                    return RedirectToAction("Index");
                }
                return View(events);
            }*/
    }
}
