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
    public class AuthorizationController : Controller
    {
        AdminManager adm = new AdminManager(new EfAdminDal());
        // GET: Authorization
        public ActionResult Index()
        {
            var adminvalues = adm.GetList();          
            return View(adminvalues);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin admin)
        {
            adm.AdminAdd(admin);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            List<SelectListItem> valuerole = (from x in adm.GetList()
                                              select new SelectListItem
                                              {
                                                  Text = x.AdminRole,
                                                  Value = x.AdminRole.ToString()
                                              }).ToList();

            ViewBag.vr = valuerole;
            var adminvalue = adm.GetByID(id);
            return View(adminvalue);
        }

        [HttpPost]
        public ActionResult EditAdmin(Admin p)
        {
            
            adm.AdminUpdate(p);
            return RedirectToAction("Index");
        }

        public ActionResult AdminStatus(int id)
        {
            var adminvalues = adm.GetByID(id);
            if (adminvalues.AdminStatus== true)
            {
                adminvalues.AdminStatus = false;
            }
            else
            {
                adminvalues.AdminStatus = true;
            }
            adm.AdminUpdate(adminvalues);
            return RedirectToAction("Index");
        }


    }
}