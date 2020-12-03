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
    public class CustomerFilesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CustomerFiles
        /**
         public ActionResult Index(int id)
        {
            var customerFiles = db.CustomerFiles.Find(id);
            return CustomerFile(customerFiles.Content, customerFiles.ContentType);
        }
         */

    }
}
