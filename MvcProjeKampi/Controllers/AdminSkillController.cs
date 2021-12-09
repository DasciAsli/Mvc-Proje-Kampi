using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AdminSkillController : Controller
    {
        SkillManager sm = new SkillManager(new EfSkillDal());
        // GET: AdminSkill
        public ActionResult Index()
        {
            var skillvalues = sm.GetList();
            return View(skillvalues);
        }
    }
}