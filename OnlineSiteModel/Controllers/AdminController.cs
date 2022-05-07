using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;
using System.IO;
using DbConnect;

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
        [HttpGet]
        public ActionResult ProductAdd()
        {
            ViewBag.Category = rep.GetCategories();
            return View();
        }
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
                productAdded = false;
            }
            else
            {
                productAdded = false;
            }

            string path = "D:\\html\\iimage\\" + ImgPath;
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
                imageAdded = false;
            }
            else
            {
                imageAdded = false;
            }
            ViewBag.status = false;
            if (productAdded && imageAdded)
            {
                ViewBag.status = true;
            }

            return View();
        }
    }
}