﻿using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
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
            var messagevalues = mm.GetListInbox();
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

            if (button == "draft")
            {

                if (result.IsValid)
                {
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    message.SenderMail = "emel@gmail.com";
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
                    message.SenderMail = "emel@gmail.com";
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

        public PartialViewResult MessageListMenu()
        {
            
            ViewBag.MessageInboxCount = mm.GetListInbox().Where(x => x.ReadStatus == false).Count();
            return PartialView();
        }
        public ActionResult SendBox()
        {
            var messagevalues = mm.GetListSendbox();
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
            var sendList = mm.GetListSendbox();
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
            var messagelist = mm.GetList().Where(x=>x.SenderMail=="emel@gmail.com" && x.isTrash == true).ToList();
            return View(messagelist);
        }
        public ActionResult GetTrashMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
        }
     
    }
}