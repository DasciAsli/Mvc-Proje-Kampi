using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class ChartController : Controller
    {
        Context c = new Context();

        //Oluşturdugumuz chartı burada sayfaya göndereceğiz
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        //Char işlemlerini yaptık
        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }

        //BlogList bir metod içini doldurduk sınıfımızın
        public List<CategoryClass> BlogList()
        {
            List<CategoryClass> ct = new List<CategoryClass>();
            ct.Add(new CategoryClass()
            {
                CategoryName = "Yazılım",
                CategoryCount = 8
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Seyehat",
                CategoryCount = 4
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Teknoloji",
                CategoryCount = 7
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Spor",
                CategoryCount = 1
            });
            return ct;
        }


       
        public ActionResult CategoryLineChart()
        {
            return View();
        }
        public ActionResult CategoryColumnChart()
        {
            return View();
        }
        public ActionResult CategoryChart2()
        {
            return Json(CategoryListChart(), JsonRequestBehavior.AllowGet);
        }

        public List<CategoryClass> CategoryListChart()
        {
            List<CategoryClass> categoryClasses = new List<CategoryClass>();
            using (var _context = new Context())
            {
                categoryClasses = _context.Categories.Select(x => new CategoryClass
                {
                    CategoryName = x.CategoryName,
                    CategoryCount = x.CategoryName.Length
                }).ToList();
            }

            return categoryClasses;
        }
    }
}