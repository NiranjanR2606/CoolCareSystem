using CoolCareSystem.DataLayer;
using CoolCareSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoolCareSystem.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ProductController : Controller
    {
        ProductDAL data = new ProductDAL();

        [HttpGet]
        public ActionResult Product()
        {
            List<ProductModel> productsList;

            productsList = data.GetProducts();

            return View(productsList);
        }

        [HttpGet]
        public ActionResult ProductDetails(int id)
        {
            ProductModel productList;

            productList = data.GetProductById(id);
            
            return View(productList);
        }

        public int ApproveProduct(int id)
        {
            int status = data.ApproveProduct(id);
            return status;
        }
    }
}