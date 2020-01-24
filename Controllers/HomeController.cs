using DAL.Context;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dz_mvc_intro.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        CategoryRepository repoCategory =
            new CategoryRepository(new ShopContext());

        GoodRepository repoGood = 
            new GoodRepository(new ShopContext());

        ManufacturerRepository repoManufacturer =
            new ManufacturerRepository(new ShopContext());

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Categories()
        {
            ViewBag.Categories = repoCategory.GetAll();
            return View();
        }

        public ActionResult Goods()
        {
            ViewBag.Goods = repoGood.GetAll();
            return View();
        }

        public ActionResult Manufacturers()
        {
            ViewBag.Manufacturers = repoManufacturer.GetAll();
            return View();
        }

    }
}