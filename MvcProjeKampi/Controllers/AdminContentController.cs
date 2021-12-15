using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AdminContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        // GET: AdminContent
        public ActionResult Index()
        {
            return View();
        }
      
        public ActionResult GetAllContent(string p)
        {
            var values = cm.GetList();
            if (!string.IsNullOrEmpty(p))
            {
                 values = cm.GetList(p);
            }          
            return View(values);
        }

        public ActionResult ContentByHeading(int id)
        {
            var contentvalues = cm.GetListByID(id);
            return View(contentvalues);
        }
    }
}