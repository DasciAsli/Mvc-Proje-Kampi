using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AdminAboutController : Controller
    {
        AboutManager abm = new AboutManager(new EfAboutDal()); 
        // GET: AdminAbout
        public ActionResult Index()
        {
            var aboutvalues =abm.GetList();
            return View(aboutvalues);
        }
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            about.AboutStatus = false;
            abm.AboutAdd(about);
            return RedirectToAction("Index");
        }
        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
        public ActionResult AboutStatus(int id)
        {
            var aboutvalues = abm.GetByID(id);
            if (aboutvalues.AboutStatus == true)
            {
                aboutvalues.AboutStatus = false;
            }
            else 
            {
                aboutvalues.AboutStatus = true;
            }
            abm.AboutUpdate(aboutvalues);
            return RedirectToAction("Index");
        }
    }
}