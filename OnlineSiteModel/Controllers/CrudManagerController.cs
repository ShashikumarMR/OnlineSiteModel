using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineSiteModel.Controllers
{
    public class CrudManagerController : Controller
    {
        // GET: CrudManager
        public ActionResult ProdCrud()
        {
            return View();
        }

        public ActionResult CatCrud()
        {
            return View();
        }
    }
}