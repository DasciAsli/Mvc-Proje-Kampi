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
    public class AdminMessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        // GET: AdminMessage
        public ActionResult Inbox()
        {
            var messagevalues = mm.GetListInbox();
            return View(messagevalues);
        }
        public ActionResult SendBox()
        {
            var messagevalues = mm.GetListSendbox();
            return View(messagevalues);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {

            return View();
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
        }
    }
}