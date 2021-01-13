using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoolCareSystem.Areas.Admin.Controllers
{
    public class AdminErrorController : Controller
    {
        //[Authorize(Roles = "Admin")]
        public ActionResult NotFound()
        {
            return View();
        }
    }
}