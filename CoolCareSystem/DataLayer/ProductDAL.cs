using CoolCareSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoolCareSystem.DataLayer
{
    public class ProductDAL
    {

        public List<ProductModel> GetProducts()
        {
            CoolCareSystemEntities db = new CoolCareSystemEntities();
            try
            {
                var status = db.GetAllProducts().ToList();

                List<ProductModel> model = new List<ProductModel>();


                foreach (var item in status)
                {
                    ProductModel product = new ProductModel();
                    product.Id = item.Id;
                    product.UserName = item.UserName;
                    product.ProductName = item.ProductName;
                    product.Description = item.Description;
                    product.RequestedAt = (DateTime)item.RequestedAt;
                    product.BilledYear = (int)item.BilledYear;
                    product.Price = item.Price;
                    product.IsApproved = (bool)item.IsApproved;
                    model.Add(product);
                }

                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db = null;
            }

        }

        public ProductModel GetProductById(int Id)
        {
            CoolCareSystemEntities db = new CoolCareSystemEntities();
            try
            {
                var status = db.GetProductById(Id).ToList();

                ProductModel product = new ProductModel();

                foreach (var item in status)
                {                    
                    product.Id = item.Id;
                    product.UserName = item.UserName;
                    product.MobileNumber = (decimal)item.MobileNumber;
                    product.ProductName = item.ProductName;
                    product.Description = item.Description;
                    product.RequestedAt = (DateTime)item.RequestedAt;
                    product.BilledYear = (int)item.BilledYear;
                    product.Price = item.Price;
                    product.IsApproved = (bool)item.IsApproved;
                    product.ImageName = item.ImageName;
                }

                return product;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db = null;
            }

        }

        public int ApproveProduct(int Id)
        {
            CoolCareSystemEntities db = new CoolCareSystemEntities();
            try
            {
                var status = db.ApproveProduct(Id);

                return status;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db = null;
            }

        }

        public List<ProductModel> GetProductsForUser()
        {
            CoolCareSystemEntities db = new CoolCareSystemEntities();
            try
            {
                var status = db.GetAllProductsForUser().ToList();

                List<ProductModel> model = new List<ProductModel>();


                foreach (var item in status)
                {
                    ProductModel product = new ProductModel();
                    product.Id = item.Id;
                    product.UserName = item.UserName;
                    product.ProductName = item.ProductName;
                    product.Description = item.Description;
                    product.RequestedAt = (DateTime)item.RequestedAt;
                    product.BilledYear = (int)item.BilledYear;
                    product.Price = item.Price;
                    model.Add(product);
                }

                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db = null;
            }

        }

        public int InsertProduct(int userId,ProductModel model)
        {
            CoolCareSystemEntities db = new CoolCareSystemEntities();
            System.Data.Entity.Core.Objects.ObjectParameter ReturnId = new System.Data.Entity.Core.Objects.ObjectParameter("ReturnId", typeof(Int32));
            try
            {
                db.InsertProduct(userId,model.ProductName, model.Description, (int)model.BilledYear, (decimal)model.Price, ReturnId);
                int productId = Convert.ToInt32(ReturnId.Value);
                return productId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db = null;
            }
        }

        public void InsertImage(int id, string filename)
        {
            CoolCareSystemEntities db = new CoolCareSystemEntities();
            try
            {
                db.InsertImage(id, filename);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db = null;
            }
        }

        public List<ProductModel> GetProductsByUserId(int UserId)
        {
            CoolCareSystemEntities db = new CoolCareSystemEntities();
            try
            {
                var status = db.GetProductsByUserId(UserId).ToList();

                List<ProductModel> model = new List<ProductModel>();

                foreach (var item in status)
                {
                    ProductModel product = new ProductModel();
                    product.Id = item.Id;
                    product.UserName = item.UserName;
                    product.ProductName = item.ProductName;
                    product.Description = item.Description;
                    product.RequestedAt = (DateTime)item.RequestedAt;
                    product.BilledYear = (int)item.BilledYear;
                    product.Price = item.Price;
                    product.IsAvailable = (bool)item.IsAvailable;
                    product.IsApproved = (bool)item.IsApproved;
                    model.Add(product);
                }

                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db = null;
            }

        }

        public int UpdateProductAvailable(int Id)
        {
            CoolCareSystemEntities db = new CoolCareSystemEntities();
            try
            {
                var status = db.UpdateProductAvailable(Id);

                return status;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db = null;
            }

        }

    }
}