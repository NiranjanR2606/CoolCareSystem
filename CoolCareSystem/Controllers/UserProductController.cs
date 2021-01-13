using CoolCareSystem.DataLayer;
using CoolCareSystem.Models;
using System;
using System.Collections.Generic;
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

            #region Upload Image

            var originalDirectory = new DirectoryInfo(string.Format("{0}Images\\Uploads", Server.MapPath(@"\")));

            var pathString1 = Path.Combine(originalDirectory.ToString(), "Products");
            var pathString2 = Path.Combine(originalDirectory.ToString(), "Products\\" + id.ToString());
            var pathString3 = Path.Combine(originalDirectory.ToString(), "Products\\" + id.ToString() + "\\Thumbs");
            var pathString4 = Path.Combine(originalDirectory.ToString(), "Products\\" + id.ToString() + "\\Gallery");
            var pathString5 = Path.Combine(originalDirectory.ToString(), "Products\\" + id.ToString() + "\\Gallery\\Thumbs");

            if (!Directory.Exists(pathString1))
                Directory.CreateDirectory(pathString1);

            if (!Directory.Exists(pathString2))
                Directory.CreateDirectory(pathString2);

            if (!Directory.Exists(pathString3))
                Directory.CreateDirectory(pathString3);

            if (!Directory.Exists(pathString4))
                Directory.CreateDirectory(pathString4);

            if (!Directory.Exists(pathString5))
                Directory.CreateDirectory(pathString5);

            if (fileData != null && fileData.ContentLength > 0)
            {
                string ext = fileData.ContentType.ToLower();

                if (ext != "image/jpg" &&
                    ext != "image/jpeg" &&
                    ext != "image/pjpeg" &&
                    ext != "image/gif" &&
                    ext != "image/x-png" &&
                    ext != "image/png")
                {
                    ModelState.AddModelError("", "The image was not uploaded - wrong image extension.");
                    return View(model);
                }

                string imageName = fileData.FileName;

                data.InsertImage(id, imageName);

                var path = string.Format("{0}\\{1}", pathString2, imageName);
                var path2 = string.Format("{0}\\{1}", pathString3, imageName);

                fileData.SaveAs(path);

                DirectoryInfo di = new DirectoryInfo(pathString2);
                FileAttributes f = di.Attributes;
                f -= FileAttributes.ReadOnly;

                WebImage img = new WebImage(fileData.InputStream);
                img.Resize(200, 200);
                img.Save(path2);
            }

            #endregion

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