using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Business;
using Data;

namespace FixMeApplication.Controllers
{
    [Route("RepairShops")]
    public class RepairShopsController : Controller
    {
        private RepairContext db = new RepairContext();

        // GET: RepairShops
        public ActionResult Index()
        {
            return View(db.RepairShops.ToList());
        }

        // GET: RepairShops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepairShop repairShop = db.RepairShops.Find(id);
            if (repairShop == null)
            {
                return HttpNotFound();
            }
            return View(repairShop);
        }

        [Route("Map/{repairTypeId}")]
        [HttpGet]
        public ActionResult Map()
        {
            var id = Request.Url.Segments[3];
            ViewBag.MapId = id;            
            return View(db.RepairShops.ToList());
        }

        // GET: RepairShops/Create
        public ActionResult Create()
        {
            ViewBag.RepairTypesList = new SelectList(
                db.RepairTypes
      .Select(e => new SelectListItem
      {
          Value = e.Id.ToString(),
          Text = e.Name
      })
     .ToList()
     , "Value", "Text");

            return View();
        }

        // POST: RepairShops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Address,RepairTypes")] RepairShop repairShop)
        {

            if (ModelState.IsValid)
            {
                repairShop.RepairTypes = new List<RepairType>();
                string repairTypeId = Request.Form["RepairTypes"].ToString();
                RepairTypeBusiness repairTypeBusiness = new RepairTypeBusiness();
                RepairType repairType = repairTypeBusiness.Get(int.Parse(repairTypeId));
                db.RepairTypes.Find(repairType).RepairShops.Add(repairShop);
                

                db.RepairShops.Add(repairShop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RepairTypesList = new SelectList(
                db.RepairTypes
              .Select(e => new SelectListItem
              {
                  Value = e.Id.ToString(),
                  Text = e.Name
              })
             .ToList()
             , "Value", "Text");

            return View(repairShop);
        }

        // GET: RepairShops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepairShop repairShop = db.RepairShops.Find(id);
            if (repairShop == null)
            {
                return HttpNotFound();
            }
            return View(repairShop);
        }

        // POST: RepairShops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Address")] RepairShop repairShop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(repairShop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(repairShop);
        }

        // GET: RepairShops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepairShop repairShop = db.RepairShops.Find(id);
            if (repairShop == null)
            {
                return HttpNotFound();
            }
            return View(repairShop);
        }

        // POST: RepairShops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RepairShop repairShop = db.RepairShops.Find(id);
            db.RepairShops.Remove(repairShop);
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
