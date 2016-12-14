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
    public class articlesController : Controller
    {
       // private RecDatabaseModelContainer db = new RecDatabaseModelContainer();
        webApiClass eventHelper = new webApiClass();
        // GET: articles
        public ActionResult Index()
        {
            return View(eventHelper.GetArticles());
        }

        // GET: articles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            articles articles = eventHelper.GetArticle(id);
            if (articles == null)
            {
                return HttpNotFound();
            }
            return View(articles);
        }

        // GET: articles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "articleId,articleImage,articlePDF,description,name,category")] articles articles)
        {
            if (ModelState.IsValid)
            {
                //db.articles.Add(articles);
                // db.SaveChanges();
                eventHelper.insertArticle(articles.name, articles.articleImage, articles.articlePDF,articles.category, articles.description);
                return RedirectToAction("Index");
            }

            return View(articles);
        }

        // GET: articles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            articles articles = eventHelper.GetArticle(id);
            if (articles == null)
            {
                return HttpNotFound();
            }
            return View(articles);
        }

        // POST: articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "articleId,articleImage,articlePDF,category,description,name")] articles articles)
        {
            if (ModelState.IsValid)
            {
                eventHelper.editArticle(articles.articleId, articles.name, articles.articleImage, articles.articlePDF,articles.description,articles.category);
                return RedirectToAction("Index");
            }
            return View(articles);
        }

        // GET: articles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            articles articles = eventHelper.GetArticle(id);
            if (articles == null)
            {
                return HttpNotFound();
            }
            return View(articles);
        }

        // POST: articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            eventHelper.deleteArticle(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
               // db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
