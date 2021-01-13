using CoolCareSystem.DataLayer;
using CoolCareSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoolCareSystem.Controllers
{

    public class UserServiceController : Controller
    {
        ServiceDAL data = new ServiceDAL();

        CoolCareSystemEntities db = new CoolCareSystemEntities();

        [HttpGet]
        public ActionResult Service()
        {
            List<ServiceModel> servicesList;

            string username = User.Identity.Name;

            int userId = 0;

            using (CoolCareSystemEntities db = new CoolCareSystemEntities())
            {
                var q = db.Users.FirstOrDefault(x => x.UserName == username);
                userId = q.Id;
            }

            servicesList = data.GetServicesForUser(userId);

            return View(servicesList);
        }

        [HttpGet]
        public ActionResult ServiceDetails(int id)
        {
            ServiceModel serviceList;

            serviceList = data.GetServiceById(id);

            return View(serviceList);
        }

        public int RateService(int id, int Rating)
        {
            int status = data.RateService(id, Rating);

            return status;
        }

        public int InsertService(string Name,string Issue)
        {
             string username = User.Identity.Name;

            int userId = 0;

            using (CoolCareSystemEntities db = new CoolCareSystemEntities())
            {
                var q = db.Users.FirstOrDefault(x => x.UserName == username);
                userId = q.Id;
            }

            int status = data.InsertService(userId, Name, Issue);

            return status;
        }
    }
}