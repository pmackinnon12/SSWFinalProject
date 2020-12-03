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
    public class AgentFilesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AgentFiles

        /**
        public ActionResult Index(int id)
        {
            var agentFiles = db.AgentFiles.Find(id);
            return AgentFile(agentFiles.Content, agentFiles.ContentType);
        }*/
    }
}
