using CoolCareSystem.DataLayer;
using CoolCareSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoolCareSystem.Areas.Admin.Controllers
{
    public class ServiceController : Controller
    {
        ServiceDAL data = new ServiceDAL();

        CoolCareSystemEntities db = new CoolCareSystemEntities();

        [HttpGet]
        public ActionResult Service()
        {
            List<ServiceModel> servicesList;

            servicesList = data.GetServices();

            return View(servicesList);
        }

        [HttpGet]
        public ActionResult ServiceDetails(int id)
        {
            ServiceModel serviceList;

            serviceList = data.GetServiceById(id);

            if(serviceList.WorkerId == 0)
            {
                serviceList.Workers = new SelectList(db.Workers.ToList(), "Id", "Worker_Name");
            }

            return View(serviceList);
        }

        public int ApproveService(int id, int WorkerId,decimal price)
        {
            int status = data.ApproveService(id, WorkerId,price);
            return status;
        }

        public int UpdateServiceStatus(int id,string servicestatus,decimal price)
        {
            int status = data.UpdateServiceStatus(id, servicestatus, price);
            return status;
        }

        [HttpGet]
        public ActionResult ServiceStatus()
        {
            List<ServiceModel> servicesList;

            servicesList = data.GetServiceStatus();

            return View(servicesList);
        }

        [HttpGet]
        public ActionResult ServiceStatusDetail(int id)
        {
            ServiceModel serviceList;

            serviceList = data.GetServiceById(id);

            return View(serviceList);
        }

    }
}