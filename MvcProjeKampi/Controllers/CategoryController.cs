using BusinessLayer.Concrete;
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
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());

        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetCategoryList()
        {
            var categoryvalues = cm.GetList();
           
            return View(categoryvalues);
        }
        [HttpGet] //Sayfam yüklendiğinde çalışacak
        public ActionResult AddCategory()
        {
            return View();
        }


        [HttpPost] //Sayfamda bir şey post edildiğinde çalışacak
        public ActionResult AddCategory(Category p)
        {
            // cm.CategoryAddBL(p);
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(p);
            //results isminde bir değişken oluşturduk.CategorValidator sınıfından gelen değerlere göre parametreden gelen değeri kontrol et
            if (results.IsValid)
            {
                cm.CategoryAddBL(p);
                return RedirectToAction("GetCategoryList");
                
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(); 
            //Ekleme işlemini gerçekleştirdikten sonra beni GetCategoryList metoduna gönder
        }
    }
}