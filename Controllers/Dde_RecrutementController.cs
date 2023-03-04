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
    public class Dde_RecrutementController : Controller
    {
        private recruitEntities2 db = new recruitEntities2();

        // GET: Dde_Recrutement
        public ActionResult Index()
        {
            return View(db.Dde_Recrutement.ToList());
        }

        // GET: Dde_Recrutement/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dde_Recrutement dde_Recrutement = db.Dde_Recrutement.Find(id);
            if (dde_Recrutement == null)
            {
                return HttpNotFound();
            }
            return View(dde_Recrutement);
        }

        // GET: Dde_Recrutement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dde_Recrutement/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date_Dde,Nom_Emp,Fonction_Emp,Type_Dde,Nbre_Poste,Remplacemnt,File_Name,File_Path,Nature_Contrat,Diplome,NB_année,Affectation,Remarque")] Dde_Recrutement dde_Recrutement)
        {
            if (ModelState.IsValid)
            {
                db.Dde_Recrutement.Add(dde_Recrutement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dde_Recrutement);
        }

        // GET: Dde_Recrutement/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dde_Recrutement dde_Recrutement = db.Dde_Recrutement.Find(id);
            if (dde_Recrutement == null)
            {
                return HttpNotFound();
            }
            return View(dde_Recrutement);
        }

        // POST: Dde_Recrutement/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date_Dde,Nom_Emp,Fonction_Emp,Type_Dde,Nbre_Poste,Remplacemnt,File_Name,File_Path,Nature_Contrat,Diplome,NB_année,Affectation,Remarque")] Dde_Recrutement dde_Recrutement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dde_Recrutement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dde_Recrutement);
        }

        // GET: Dde_Recrutement/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dde_Recrutement dde_Recrutement = db.Dde_Recrutement.Find(id);
            if (dde_Recrutement == null)
            {
                return HttpNotFound();
            }
            return View(dde_Recrutement);
        }

        // POST: Dde_Recrutement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dde_Recrutement dde_Recrutement = db.Dde_Recrutement.Find(id);
            db.Dde_Recrutement.Remove(dde_Recrutement);
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
