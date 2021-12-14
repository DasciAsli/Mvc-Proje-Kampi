using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        ContentManager cm = new ContentManager(new EfContentDal());
        public ActionResult Heading()
        {
            var headinglist = hm.GetList().Where(x=>x.HeadingStatus== true).ToList();
            return View(headinglist);
        }
        // GET: Default
        public PartialViewResult Index(int id=0)
        {
            var contentList = cm.GetListByID(id);
            return PartialView(contentList);
        }
    }
}