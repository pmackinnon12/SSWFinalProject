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
    [Authorize]
    public class ListingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Listings
        [AllowAnonymous]
        public ActionResult Index(string citySearch, string provinceSearch, string numOfBathSearch, string numOfBedsSearch, string sortOrder)
        {
            ViewBag.CitySortParm = String.IsNullOrEmpty(citySearch) ? "City" : "";
            ViewBag.ProvinceSortParm = String.IsNullOrEmpty(citySearch) ? "Province" : "";
            ViewBag.NumOfBathSortParm = String.IsNullOrEmpty(citySearch) ? "NumOfBaths" : "";
            ViewBag.NumOfBedSortParm = String.IsNullOrEmpty(citySearch) ? "NumOfBeds" : "";
            ViewBag.ViewOrderSortParm = String.IsNullOrEmpty(citySearch) ? "ViewOrder" : "";

            var listings = db.Listings.Include(l => l.Agent).Include(l => l.Customer);

            if (!String.IsNullOrEmpty(citySearch))
            {
                listings = listings.Where(l => l.Municipality.ToUpper().Contains(
                    citySearch.ToUpper()));
            }
            if (!String.IsNullOrEmpty(provinceSearch))
            {
                var province = Provinces.NB;

                switch (provinceSearch)
                {
                    case "NB":
                        province = Provinces.NB;
                        break;
                    case "NS":
                        province = Provinces.NS;
                        break;
                    case "PEI":
                        province = Provinces.PEI;
                        break;
                    case "ON":
                        province = Provinces.ON;
                        break;
                    case "QC":
                        province = Provinces.QC;
                        break;
                    case "MA":
                        province = Provinces.MA;
                        break;
                    case "BC":
                        province = Provinces.BC;
                        break;
                    case "AL":
                        province = Provinces.AL;
                        break;
                    case "SK":
                        province = Provinces.SK;
                        break;
                    case "YU":
                        province = Provinces.YU;
                        break;
                    case "NU":
                        province = Provinces.NU;
                        break;
                    case "NWT":
                        province = Provinces.NWT;
                        break;
                    case "NF":
                        province = Provinces.NF;
                        break;
                }

                listings = listings.Where(l => l.Province == province);
            }
            if (!String.IsNullOrEmpty(numOfBathSearch))
            {
                listings = listings.Where(l => l.NumberOfBaths.ToString().Contains(
                    numOfBathSearch.ToUpper()));
            }
            if (!String.IsNullOrEmpty(numOfBedsSearch))
            {
                listings = listings.Where(l => l.NumberOfBeds.ToString().Contains(
                    numOfBedsSearch.ToUpper()));
            }
            switch (sortOrder)
            {
                case "Ascending":
                    listings = listings.OrderBy(l => l.SalesPrice) ;
                    break;
                case "Descending":
                    listings = listings.OrderByDescending(l => l.SalesPrice);
                    break;
                default:
                    listings = listings.OrderBy(l => l.ListingID);
                    break;
            }
            
            return View(listings.ToList());
        }

        // GET: Listings/Details/5
        [AllowAnonymous]
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
