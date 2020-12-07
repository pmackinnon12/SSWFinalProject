using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using SSWProject.Models;

namespace SSWProject.Controllers
{
    [Authorize]
    public class ShowingsController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Showings
        [AllowAnonymous]
        public ActionResult Index()
        {
            var showings = db.Showings.Include(s => s.Listing);
            DateTime todaysDate = DateTime.Now.Date;
            showings = showings.Where(s => s.ShowingDate <= todaysDate);
            return View(showings.ToList());
        }

        // GET: Showings/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Showing showing = db.Showings.Find(id);
            if (showing == null)
            {
                return HttpNotFound();
            }
            return View(showing);
        }

        // GET: Showings/Create
        public ActionResult Create()
        {
            ViewBag.ListingID = new SelectList(db.Listings, "ListingID", "StreetAddress");
            return View();
        }

        // POST: Showings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShowingID,ListingID,ShowingDate,StartTime,EndTime")] Showing showing)
        {
            if (ModelState.IsValid)
            {
                db.Showings.Add(showing);
                db.SaveChanges();
                string email = User.Identity.Name;
                sendConfirmationEmail(User.Identity.Name);
                return RedirectToAction("Index");
            }

            return View(showing);
        }

        // GET: Showings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Showing showing = db.Showings.Find(id);
            if (showing == null)
            {
                return HttpNotFound();
            }
            return View(showing);
        }

        // POST: Showings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShowingID,ListingID,ShowingDate,StartTime,EndTime")] Showing showing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(showing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(showing);
        }

        // GET: Showings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Showing showing = db.Showings.Find(id);
            if (showing == null)
            {
                return HttpNotFound();
            }
            return View(showing);
        }

        // POST: Showings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Showing showing = db.Showings.Find(id);
            db.Showings.Remove(showing);
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

        protected void sendConfirmationEmail(string agentEmail)
        {
            MailMessage mailMessage = new MailMessage();

            mailMessage.To.Add(agentEmail);

            mailMessage.From = new MailAddress("admin@YETI.ca");
            mailMessage.Subject = "Showing Confirmation";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = "<h2>Showing has successfully been saved</h2>";

            SmtpClient client = new SmtpClient("localhost");
            client.Send(mailMessage);

            return;
        }
    }
}
