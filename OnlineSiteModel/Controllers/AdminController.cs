using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DbConnect;
using System.Drawing;
using System.IO;

namespace OnlineSiteModel.Controllers
{
    public class AdminController : Controller
    {
        Repository rep;
        public AdminController()
        {
            rep = new Repository();
        }
        // GET: Admin
        public ActionResult ProductAdd()
        {
            ViewBag.Category = rep.GetCategories();
            return View();
        }
        [HttpPost]
        public ActionResult ProductAdd(string pname, Nullable<double> price, Nullable<int> Category, Nullable<double> weight, Nullable<int> stock, string desc, string ImgPath)
        {
            ViewBag.Category = rep.GetCategories();
            var prod = new DbConnect.Product()
            {
                productName = pname,
                price = price,
                CategoryId = Category,
                weight = weight,
                stock = stock,
                Description = desc,
            };
            bool productAdded = false;
            if (rep.ProductToDb(prod))
            {
                productAdded = true;
            }

            string path = "I:\\OSM\\images\\" + ImgPath;
            Image img = Image.FromFile(path);
            var Img = new DbConnect.ImageTable();
            Img.image_name = pname;
            Img.ProductID = rep.GetProductId(pname);
            using (var ms = new MemoryStream())
            {
                img.Save(ms, img.RawFormat);
                Img.image = ms.ToArray();
            }
            bool imageAdded = false;
            if (rep.ImageToDb(Img))
            {
                imageAdded = true;
            }

            ViewBag.status = false;
            if (productAdded && imageAdded)
            {
                TempData["status"] = true;
            }

            return View();
        }

        public ActionResult ProductDelete()
        {
            ViewBag.Products = rep.GetProdAll();
            return View();
        }

        [HttpPost]
        public ActionResult ProductDelete(int pid)
        {
            TempData["status"] = false;
            ViewBag.Products = rep.GetProdAll();
            if (rep.ProdDelete(pid))
            {
                TempData["status"] = true;
            }
            return View();
        }
    }
}