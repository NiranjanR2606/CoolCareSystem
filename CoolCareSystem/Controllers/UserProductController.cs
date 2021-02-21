using CoolCareSystem.DataLayer;
using CoolCareSystem.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace CoolCareSystem.Controllers
{
    [Authorize(Roles = "User")]
    public class UserProductController : Controller
    {
        ProductDAL data = new ProductDAL();

        [HttpGet]
        public ActionResult Product()
        {

            List<ProductModel> productsList;

            productsList = data.GetProductsForUser();

            return View(productsList);
        }

        [HttpGet]
        public ActionResult ProductDetails(int id)
        {
            ProductModel productList;

            productList = data.GetProductById(id);

            return View(productList);
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            ProductModel product = new ProductModel();

            return View(product);
        }

        [HttpPost]
        public ActionResult AddProduct(ProductModel model, HttpPostedFileBase fileData)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string username = User.Identity.Name;

            int userId = 0;

            using (CoolCareSystemEntities db = new CoolCareSystemEntities())
            {
                var q = db.Users.FirstOrDefault(x => x.UserName == username);
                userId = q.Id;
            }

            int id = data.InsertProduct(userId, model);

            if (id != 0)
            {
                TempData["SuccessMessage"] = "You have added a new product !";
            }

            if (fileData != null && fileData.ContentLength > 0)
            {
                try
                {
                    Stream fs = fileData.InputStream;
                    BinaryReader br = new System.IO.BinaryReader(fs);
                    Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                    string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                    string imageName = "data:image/png;base64," + base64String;
                    data.InsertImage(id, imageName);
                }
                catch(Exception ex)
                {
                    string error = ex.Message;
                }

                
            }

            return RedirectToAction("AddProduct");
        }

        [HttpGet]
        public ActionResult UserProduct()
        {

            List<ProductModel> productsList;

            string username = User.Identity.Name;

            int userId = 0;

            using (CoolCareSystemEntities db = new CoolCareSystemEntities())
            {
                var q = db.Users.FirstOrDefault(x => x.UserName == username);
                userId = q.Id;
            }

            productsList = data.GetProductsByUserId(userId);

            return View(productsList);
        }

        
        public ActionResult UpdateProductAvailable(int id)
        {
            data.UpdateProductAvailable(id);

            List<ProductModel> productsList;

            string username = User.Identity.Name;

            int userId = 0;

            using (CoolCareSystemEntities db = new CoolCareSystemEntities())
            {
                var q = db.Users.FirstOrDefault(x => x.UserName == username);
                userId = q.Id;
            }

            productsList = data.GetProductsByUserId(userId);

            return View("UserProduct", productsList);
        }
    }
}