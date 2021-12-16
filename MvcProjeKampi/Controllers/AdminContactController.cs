 using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
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
        MessageManager mm = new MessageManager(new EfMessageDal());
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
            contactvalues.ReadStatus = true;
            cm.ContactUpdate(contactvalues);
            return View(contactvalues);
        }
        public PartialViewResult MessageListMenu(string p)
        {
            
            ViewBag.ContactMessageCount = cm.GetList().Where(x => x.ReadStatus == false).Count();
            ViewBag.MessageInboxCount = mm.GetListAdminInbox().Where(x => x.ReadStatus == false).Count();  
            return PartialView();
        }

        public ActionResult AddContact(Contact contact)
        {
            contact.ContactDate = DateTime.Now;
            contact.ReadStatus = false;
            cm.ContactAdd(contact);
            return RedirectToAction("HomePage","Home"); 
        }
    }
}