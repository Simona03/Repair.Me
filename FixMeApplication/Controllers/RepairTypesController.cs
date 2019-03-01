using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data;

namespace FixMeApplication.Controllers
{
    public class RepairTypesController : Controller
    {
        private RepairContext db = new RepairContext();

        // GET: RepairTypes
        public ActionResult Index()
        {
            return View(db.RepairTypes.ToList());
        }

        // GET: RepairTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepairType repairType = db.RepairTypes.Find(id);
            if (repairType == null)
            {
                return HttpNotFound();
            }
            return View(repairType);
        }

        // GET: RepairTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RepairTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] RepairType repairType)
        {
            if (ModelState.IsValid)
            {
                db.RepairTypes.Add(repairType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(repairType);
        }

        // GET: RepairTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepairType repairType = db.RepairTypes.Find(id);
            if (repairType == null)
            {
                return HttpNotFound();
            }
            return View(repairType);
        }

        // POST: RepairTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] RepairType repairType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(repairType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(repairType);
        }

        // GET: RepairTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepairType repairType = db.RepairTypes.Find(id);
            if (repairType == null)
            {
                return HttpNotFound();
            }
            return View(repairType);
        }

        // POST: RepairTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RepairType repairType = db.RepairTypes.Find(id);
            db.RepairTypes.Remove(repairType);
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
