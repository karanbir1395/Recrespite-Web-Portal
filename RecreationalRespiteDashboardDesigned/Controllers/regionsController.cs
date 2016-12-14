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
    public class regionsController : Controller
    {
        // private RecDatabaseModelContainer db = new RecDatabaseModelContainer();
        webApiClass eventHelper = new webApiClass();
        // GET: regions
        public ActionResult Index()
        {
           // if()
            return View(eventHelper.GetRegions());
        }

        // GET: regions/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            regions regions = eventHelper.GetRegion(id);
            if (regions == null)
            {
                return HttpNotFound();
            }
            return View(regions);
        }

        // GET: regions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: regions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "regionId,name")] regions regions)
        {
            if (ModelState.IsValid)
            {
                eventHelper.insertRegions(regions.name);
                return RedirectToAction("Index");
            }

            return View(regions);
        }

        // GET: regions/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            regions regions = eventHelper.GetRegion(id);
            if (regions == null)
            {
                return HttpNotFound();
            }
            return View(regions);
        }

        // POST: regions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "regionId,name")] regions regions)
        {
            if (ModelState.IsValid)
            {
                eventHelper.EditRegion(regions.name, regions.regionId);
                return RedirectToAction("Index");
            }
            return View(regions);
        }

        // GET: regions/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            regions regions = eventHelper.GetRegion(id);
            if (regions == null)
            {
                return HttpNotFound();
            }
            return View(regions);
        }

        // POST: regions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            eventHelper.deleteRegion(id);
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
    }
}
