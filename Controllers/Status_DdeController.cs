using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DE_Recrutement.Models;

namespace DE_Recrutement.Controllers
{
    public class Status_DdeController : Controller
    {
        private recruitEntities2 db = new recruitEntities2();

        // GET: Status_Dde
        public ActionResult Index()
        {
            var status_Dde = db.Status_Dde.Include(s => s.Dde_Recrutement);
            return View(status_Dde.ToList());
        }

        // GET: Status_Dde/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Status_Dde status_Dde = db.Status_Dde.Find(id);
            if (status_Dde == null)
            {
                return HttpNotFound();
            }
            return View(status_Dde);
        }

        // GET: Status_Dde/Create
        public ActionResult Create()
        {
            ViewBag.IdDemande = new SelectList(db.Dde_Recrutement, "Id", "Nom_Emp");
            return View();
        }

        // POST: Status_Dde/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Status_Dde_demandeur,Date_Crea_demandeur,Status_Dde_chef,Date_Dde_chef,Motif_Ref_chef,Status_Dde_rh,Date_Dde_rh,Motif_Ref_rh,Status_Dde_ds,Date_Dde_ds,Motif_Ref_ds,StatusDemandeFinal,IdDemande")] Status_Dde status_Dde)
        {
            if (ModelState.IsValid)
            {
                db.Status_Dde.Add(status_Dde);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdDemande = new SelectList(db.Dde_Recrutement, "Id", "Nom_Emp", status_Dde.IdDemande);
            return View(status_Dde);
        }

        // GET: Status_Dde/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Status_Dde status_Dde = db.Status_Dde.Find(id);
            if (status_Dde == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDemande = new SelectList(db.Dde_Recrutement, "Id", "Nom_Emp", status_Dde.IdDemande);
            return View(status_Dde);
        }

        // POST: Status_Dde/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Status_Dde_demandeur,Date_Crea_demandeur,Status_Dde_chef,Date_Dde_chef,Motif_Ref_chef,Status_Dde_rh,Date_Dde_rh,Motif_Ref_rh,Status_Dde_ds,Date_Dde_ds,Motif_Ref_ds,StatusDemandeFinal,IdDemande")] Status_Dde status_Dde)
        {
            if (ModelState.IsValid)
            {
                db.Entry(status_Dde).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdDemande = new SelectList(db.Dde_Recrutement, "Id", "Nom_Emp", status_Dde.IdDemande);
            return View(status_Dde);
        }

        // GET: Status_Dde/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Status_Dde status_Dde = db.Status_Dde.Find(id);
            if (status_Dde == null)
            {
                return HttpNotFound();
            }
            return View(status_Dde);
        }

        // POST: Status_Dde/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Status_Dde status_Dde = db.Status_Dde.Find(id);
            db.Status_Dde.Remove(status_Dde);
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
