using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AdminContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactDal());
        ContactValidator cv = new ContactValidator();
        // GET: AdminContact
        public ActionResult Index()
        {
            var contactvalues = cm.GetList();

            return View(contactvalues);
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactvalues =cm.GetByID(id);
            return View(contactvalues);
        }
    }
}