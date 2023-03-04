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
    public class Dde_ArchiveRecrutementController : Controller
    {
        private recruitEntities2 db = new recruitEntities2();

        // GET: Dde_ArchiveRecrutement
        public ActionResult Index()
        {
            return View(db.Dde_ArchiveRecrutement.ToList());
        }

        // GET: Dde_ArchiveRecrutement/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dde_ArchiveRecrutement dde_ArchiveRecrutement = db.Dde_ArchiveRecrutement.Find(id);
            if (dde_ArchiveRecrutement == null)
            {
                return HttpNotFound();
            }
            return View(dde_ArchiveRecrutement);
        }

        // GET: Dde_ArchiveRecrutement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dde_ArchiveRecrutement/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date_Dde,Nom_Emp,Fonction_Emp,Type_Dde,Nbre_Poste,Remplacemnt,File_Name,File_Path,Nature_Contrat,Diplome,NB_année,Affectation,Remarque")] Dde_ArchiveRecrutement dde_ArchiveRecrutement)
        {
            if (ModelState.IsValid)
            {
                db.Dde_ArchiveRecrutement.Add(dde_ArchiveRecrutement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dde_ArchiveRecrutement);
        }

        // GET: Dde_ArchiveRecrutement/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dde_ArchiveRecrutement dde_ArchiveRecrutement = db.Dde_ArchiveRecrutement.Find(id);
            if (dde_ArchiveRecrutement == null)
            {
                return HttpNotFound();
            }
            return View(dde_ArchiveRecrutement);
        }

        // POST: Dde_ArchiveRecrutement/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date_Dde,Nom_Emp,Fonction_Emp,Type_Dde,Nbre_Poste,Remplacemnt,File_Name,File_Path,Nature_Contrat,Diplome,NB_année,Affectation,Remarque")] Dde_ArchiveRecrutement dde_ArchiveRecrutement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dde_ArchiveRecrutement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dde_ArchiveRecrutement);
        }

        // GET: Dde_ArchiveRecrutement/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dde_ArchiveRecrutement dde_ArchiveRecrutement = db.Dde_ArchiveRecrutement.Find(id);
            if (dde_ArchiveRecrutement == null)
            {
                return HttpNotFound();
            }
            return View(dde_ArchiveRecrutement);
        }

        // POST: Dde_ArchiveRecrutement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dde_ArchiveRecrutement dde_ArchiveRecrutement = db.Dde_ArchiveRecrutement.Find(id);
            db.Dde_ArchiveRecrutement.Remove(dde_ArchiveRecrutement);
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
