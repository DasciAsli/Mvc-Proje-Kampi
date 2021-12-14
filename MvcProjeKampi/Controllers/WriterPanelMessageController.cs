using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator writervalidator = new MessageValidator();
        
        // GET: WriterPanelMessage
        public ActionResult Inbox()
        {
            string p = (string)Session["WriterMail"];
            var messagevalues = mm.GetListInbox(p);
            return View(messagevalues);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message, string button)
        {
            ValidationResult result = writervalidator.Validate(message);
            string p = (string)Session["WriterMail"];
            if (button == "draft")
            {

                if (result.IsValid)
                {
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    message.SenderMail = p;
                    message.isDraft = true;
                    mm.MessageAdd(message);
                    return RedirectToAction("Draft");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            else if (button == "save")
            {

                if (result.IsValid)
                {
                    message.MessageDate = DateTime.Now;
                    message.SenderMail = p;
                    message.isDraft = false;
                    mm.MessageAdd(message);
                    return RedirectToAction("SendBox");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            return View();
            //if (result.IsValid)
            //{
            //    message.SenderMail = "admin@gmail.com";
            //    message.MessageDate = DateTime.Now;
            //    mm.MessageAdd(message);
            //    return RedirectToAction("Sendbox");
            //}
            //else
            //{
            //    foreach (var item in result.Errors)
            //    {
            //        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            //    }
            //}

            //return View();
        }

        public PartialViewResult MessageListMenu(string p)
        {
            p = (string)Session["WriterMail"];
            ViewBag.MessageInboxCount = mm.GetListInbox(p).Where(x => x.ReadStatus == false).Count();
            return PartialView();
        }
        public ActionResult SendBox()
        {
            string p = (string)Session["WriterMail"];
            var messagevalues = mm.GetListSendbox(p);
            var sendmessages = messagevalues.FindAll(x => x.isDraft == false);
            return View(sendmessages);
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            values.ReadStatus = true;
            mm.MessageUpdate(values);
            return View(values);
        }
        public ActionResult GetSendboxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
        }
        public ActionResult Draft()
        {
            string p = (string)Session["WriterMail"];
            var sendList = mm.GetListSendbox(p);
            var draftList = sendList.FindAll(x => x.isDraft == true);
            return View(draftList);
        }
        public ActionResult GetDraftMessageDetails(int id)
        {
            var Values = mm.GetByID(id);
            return View(Values);
        }
        public ActionResult Trash()
        {
            string p = (string)Session["WriterMail"];
            var messagelist = mm.GetList().Where(x=>x.SenderMail==p && x.isTrash == true).ToList();
            return View(messagelist);
        }
        public ActionResult GetTrashMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
        }
     
    }
}