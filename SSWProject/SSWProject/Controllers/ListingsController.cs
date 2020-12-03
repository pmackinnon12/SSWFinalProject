using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SSWProject.Models;

namespace SSWProject.Controllers
{
    public class ListingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Listings
        public ActionResult Index()
        {
            var listings = db.Listings.Include(l => l.Agent).Include(l => l.Customer);
            return View(listings.ToList());
        }

        // GET: Listings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Listing listing = db.Listings.Find(id);
            if (listing == null)
            {
                return HttpNotFound();
            }
            return View(listing);
        }

        // GET: Listings/Create
        public ActionResult Create()
        {
            ViewBag.AgentID = new SelectList(db.Agents, "AgentID", "FirstName");
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName");
            return View();
        }

        // POST: Listings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ListingID,AgentID,CustomerID,StreetAddress,PostalCode,Municipality,AreaOfCity,NumberOfStories,NumberOfBeds,NumberOfBaths,Summary,TypeOfHeating,SalesPrice,IsContractSigned")] Listing listing, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    var photo = new ListingFile
                    {
                        FileName = System.IO.Path.GetFileName(upload.FileName),
                        FileType = FileType.Avatar,
                        ContentType = upload.ContentType
                    };
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        photo.Content = reader.ReadBytes(upload.ContentLength);
                    }
                    listing.Files = new List<ListingFile> { photo };
                }
                db.Listings.Add(listing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AgentID = new SelectList(db.Agents, "AgentID", "FirstName", listing.AgentID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName", listing.CustomerID);
            return View(listing);
        }

        // GET: Listings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Listing listing = db.Listings.Find(id);
            if (listing == null)
            {
                return HttpNotFound();
            }
            ViewBag.AgentID = new SelectList(db.Agents, "AgentID", "FirstName", listing.AgentID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName", listing.CustomerID);
            return View(listing);
        }

        // POST: Listings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ListingID,AgentID,CustomerID,StreetAddress,PostalCode,Municipality,AreaOfCity,NumberOfStories,NumberOfBeds,NumberOfBaths,Summary,TypeOfHeating,SalesPrice,IsContractSigned")] Listing listing, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    var photo = new ListingFile
                    {
                        FileName = System.IO.Path.GetFileName(upload.FileName),
                        FileType = FileType.Avatar,
                        ContentType = upload.ContentType
                    };
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        photo.Content = reader.ReadBytes(upload.ContentLength);
                    }
                    listing.Files = new List<ListingFile> { photo };
                }
                db.Entry(listing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AgentID = new SelectList(db.Agents, "AgentID", "FirstName", listing.AgentID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName", listing.CustomerID);
            return View(listing);
        }

        // GET: Listings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Listing listing = db.Listings.Find(id);
            if (listing == null)
            {
                return HttpNotFound();
            }
            return View(listing);
        }

        // POST: Listings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Listing listing = db.Listings.Find(id);
            db.Listings.Remove(listing);
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
