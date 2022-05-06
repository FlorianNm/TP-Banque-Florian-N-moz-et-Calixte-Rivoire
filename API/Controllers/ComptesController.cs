using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DB;

namespace API.Controllers
{
    public class ComptesController : Controller
    {
        private Model1 db = new Model1();

        // GET: Comptes
        public ActionResult Index()
        {
            return View(db.Compte.ToList());
        }

        // GET: Comptes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compte compte = db.Compte.Find(id);
            if (compte == null)
            {
                return HttpNotFound();
            }
            return View(compte);
        }

        // GET: Comptes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comptes/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCompte,Libelle")] Compte compte)
        {
            if (ModelState.IsValid)
            {
                db.Compte.Add(compte);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(compte);
        }

        // GET: Comptes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compte compte = db.Compte.Find(id);
            if (compte == null)
            {
                return HttpNotFound();
            }
            return View(compte);
        }

        // POST: Comptes/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCompte,Libelle")] Compte compte)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compte).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(compte);
        }

        // GET: Comptes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compte compte = db.Compte.Find(id);
            if (compte == null)
            {
                return HttpNotFound();
            }
            return View(compte);
        }

        // POST: Comptes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Compte compte = db.Compte.Find(id);
            db.Compte.Remove(compte);
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
