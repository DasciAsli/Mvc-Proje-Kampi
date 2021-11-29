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
    public class StatisticController : Controller
    {
        Context context = new Context();
        // GET: Statistic
        public ActionResult Index()
        {
            //Toplam kategori sayısı
            ViewBag.KategoriSayisi = context.Categories.Count();


            //Başlık tablosunda "yazılım" kategorisine ait başlık sayısı
            ViewBag.BaslikSayisi = context.Headings.Where(h => h.Category.CategoryName == "Yazılım").Count();

            //Yazar adında 'a' harfi geçen yazar sayısı
            ViewBag.YazarSayisi = context.Writers.Where(y => y.WriterName.Contains("a")==true).Count();

            // En fazla başlığa sahip kategori adı
            ViewBag.EnFazlaBaslikSahibiKategori = context.Categories.Where(u => u.CategoryId == context.Headings.GroupBy(x => x.CategoryId).OrderByDescending(x => x.Count()).Select(x => x.Key).FirstOrDefault()).Select(x => x.CategoryName).FirstOrDefault();

            // Kategori tablosunda durumu true olan kategoriler ile false olan kategoriler arasındaki sayısal fark
            var aktif = context.Categories.Where(c => c.CategoryStatus == true).Count();
            var pasif = context.Categories.Where(c => c.CategoryStatus == false).Count();
            if (aktif > pasif)
            {
                ViewBag.Fark = aktif - pasif;
            }
            else
            {
                ViewBag.Fark = pasif - aktif;
            }


            return View();
        }
    }
}