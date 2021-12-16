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
    public class AdminSkillController : Controller
    {
        SkillManager sm = new SkillManager(new EfSkillDal());
        // GET: AdminSkill
        public ActionResult Index()
        {
            var skillvalues = sm.GetList();
            return View(skillvalues);
        }
       
        public ActionResult EditSkill()
        {
            var skillvalues = sm.GetList();
            return View(skillvalues);
        }

        
        public ActionResult DeleteSkill(int id)
        {
            var value = sm.GetByID(id);
            sm.SkillDelete(value);
            return RedirectToAction("EditSkill");
        }


        [HttpGet]
        public ActionResult AddSkill()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSkill(Skill skill)
        {
            sm.SkillAdd(skill);
            return RedirectToAction("Index");
        }
    }
}