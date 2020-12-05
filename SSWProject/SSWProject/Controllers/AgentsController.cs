using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SSWProject.Models;

namespace SSWProject.Controllers
{
    public class AgentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Agents
        public ActionResult Index()
        {
            return View(db.Agents.ToList());
        }

        // GET: Agents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agent agent = db.Agents.Include(a => a.files).SingleOrDefault(a => a.AgentID == id);
            if (agent == null)
            {
                return HttpNotFound();
            }
            return View(agent);
        }

        // GET: Agents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Agents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AgentID,FirstName,MiddleName,LastName,Username,Password,JobRole,StreetAddress,Municipality,Province,PostalCode,HomePhone,CellPhone,OfficeEmail,OfficePhone,DOB,SIN")] Agent agent, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if(upload != null && upload.ContentLength > 0)
                {
                    var avatar = new AgentFile
                    {
                        FileName = Path.GetFileName(upload.FileName),
                        FileType = FileType.Avatar,
                        ContentType = upload.ContentType
                    };
                    using(var reader = new BinaryReader(upload.InputStream))
                    {
                        avatar.Content = reader.ReadBytes(upload.ContentLength);
                    }
                    string targetDir = @"../Content/images";
                    string fileDir = $@"C:Users/Owner/OneDrive/Pictures\{upload.FileName}";
                    var path = Path.Combine(Server.MapPath(targetDir), Path.GetFileName(upload.FileName));
                    //System.Drawing.Image img = System.Drawing.Image.FromStream(upload.InputStream);
                    //System.IO.
                    //System.IO.File.Copy(fileDir, path);
                    agent.files = new List<AgentFile> { avatar };
                    upload.SaveAs(path);
                    
                }
                foreach (var a in db.Agents)
                {
                    if (a.Username == agent.Username)
                    {
                        ModelState.AddModelError("Username", "Username already taken");
                    }
                    if (a.SIN == agent.SIN)
                    {
                        ModelState.AddModelError("SIN", "SIN already exists");
                    }
                    if (a.OfficeEmail == agent.OfficeEmail)
                    {
                        ModelState.AddModelError("OfficeEmail", "Email already in use");
                    }
                    if (!ModelState.IsValid)
                    {
                        return View(agent);
                    }
                }
                db.Agents.Add(agent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(agent);
        }

        // GET: Agents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agent agent = db.Agents.Include(a => a.files).SingleOrDefault(a => a.AgentID == id);
            if (agent == null)
            {
                return HttpNotFound();
            }
            return View(agent);
        }

        // POST: Agents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AgentID,FirstName,MiddleName,LastName,Username,StreetAddress,Municipality,Province,PostalCode,HomePhone,CellPhone,OfficeEmail,OfficePhone,DOB,SIN")] Agent agent, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agent).State = EntityState.Modified;
                if(upload != null && upload.ContentLength > 0)
                {
                    var avatar = new AgentFile
                    {
                        FileName = System.IO.Path.GetFileName(upload.FileName),
                        FileType = FileType.Avatar,
                        ContentType = upload.ContentType
                    };
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        avatar.Content = reader.ReadBytes(upload.ContentLength);
                    }
                    agent.files = new List<AgentFile> { avatar };
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(agent);
        }

        // GET: Agents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agent agent = db.Agents.Include(a => a.files).SingleOrDefault(a => a.AgentID == id);
            if (agent == null)
            {
                return HttpNotFound();
            }
            return View(agent);
        }

        // POST: Agents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            Agent agent = db.Agents.Include(a => a.files).SingleOrDefault(a => a.AgentID == id);
            db.Agents.Remove(agent);
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
