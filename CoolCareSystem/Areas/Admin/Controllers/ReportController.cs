using CoolCareSystem.DataLayer;
using CoolCareSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoolCareSystem.Areas.Admin.Controllers
{
    public class ReportController : Controller
    {
        ServiceDAL data = new ServiceDAL();

        public ActionResult GenerateReport(int Month)
        {
            List<RatingModel> ratingsList;

            ratingsList = data.GetRating(Month,2020);

            return View(ratingsList);
        }
    }
}