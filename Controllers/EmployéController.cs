using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using DE_Recrutement.Models;

namespace DE_Recrutement.Controllers
{
    public class EmployéController : Controller
    {
        private recruitEntities2 db = new recruitEntities2();

        // GET: Employé
        public ActionResult Index()
        {
            var employé = db.Employé.Include(e => e.Role);
            return View(employé.ToList());
        }

        // GET: Employé/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employé employé = db.Employé.Find(id);
            if (employé == null)
            {
                return HttpNotFound();
            }
            return View(employé);
        }

        // GET: Employé/Create
        public ActionResult Create()
        {
            ViewBag.Id_role = new SelectList(db.Roles, "Id", "Nom_role");
            return View();
        }

        // POST: Employé/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Matricule,Nom_prenom,E_mail,Fonction,Responsable,Id_role")] Employé employé)
        {
            if (ModelState.IsValid)
            {
               WindowsIdentity identity = WindowsIdentity.GetCurrent();
               employé.Matricule = identity.Name;

                db.Employé.Add(employé);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_role = new SelectList(db.Roles, "Id", "Nom_role", employé.Id_role);
            return View(employé);
        }

        // GET: Employé/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employé employé = db.Employé.Find(id);
            if (employé == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_role = new SelectList(db.Roles, "Id", "Nom_role", employé.Id_role);
            return View(employé);
        }

        // POST: Employé/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Matricule,Nom_prenom,E_mail,Fonction,Responsable,Id_role")] Employé employé)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employé).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_role = new SelectList(db.Roles, "Id", "Nom_role", employé.Id_role);
            return View(employé);
        }

        // GET: Employé/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employé employé = db.Employé.Find(id);
            if (employé == null)
            {
                return HttpNotFound();
            }
            return View(employé);
        }

        // POST: Employé/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employé employé = db.Employé.Find(id);
            db.Employé.Remove(employé);
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
