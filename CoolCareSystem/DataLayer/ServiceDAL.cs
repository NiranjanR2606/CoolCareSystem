using CoolCareSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoolCareSystem.DataLayer
{
    public class ServiceDAL
    {
        CoolCareSystemEntities db = new CoolCareSystemEntities();

        public List<ServiceModel> GetServices()
        {
            try
            {
                var status = db.GetAllServices().ToList();

                List<ServiceModel> model = new List<ServiceModel>();


                foreach (var item in status)
                {
                    ServiceModel service = new ServiceModel();
                    service.Id = item.Id;
                    service.UserName = item.UserName;
                    service.ProductName = item.ProductName;
                    service.Service_Issue = item.Service_Issue;
                    service.RequestedAt = item.RequestedAt;
                    service.IsApproved = (bool)item.IsApproved;
                    model.Add(service);
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

        public ServiceModel GetServiceById(int Id)
        {
            try
            {
                var status = db.GetServiceById(Id).ToList();

                ServiceModel service = new ServiceModel();

                foreach (var item in status)
                {
                    service.Id = item.Id;
                    service.UserName = item.UserName;
                    service.ProductName = item.ProductName;
                    service.MobileNumber = (decimal)item.MobileNumber;
                    service.Service_Issue = item.Service_Issue;
                    service.RequestedAt = item.RequestedAt;
                    service.IsApproved = (bool)item.IsApproved;
                    service.WorkerName = item.Worker_Name;
                    service.WorkerId = item.WorkerId;
                    service.Status = item.Status;
                    service.Price = item.Price;
                    service.Rating = (int)item.Rating;
                }

                return service;
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

        public int ApproveService(int Id, int WorkerId, decimal price)
        {
            try
            {
                var status = db.ApproveService(Id, WorkerId, price);

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

        public int UpdateServiceStatus(int Id, string servicestatus, decimal price)
        {
            try
            {
                var status = db.UpdateServiceStatus(Id, servicestatus, price);

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

        public List<ServiceModel> GetServiceStatus()
        {
            try
            {
                var status = db.GetAllServicesStatus().ToList();

                List<ServiceModel> model = new List<ServiceModel>();


                foreach (var item in status)
                {
                    ServiceModel service = new ServiceModel();
                    service.Id = item.Id;
                    service.UserName = item.UserName;
                    service.Status = item.Status;
                    model.Add(service);
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

        public List<ServiceModel> GetServicesForUser(int userid)
        {
            try
            {
                var status = db.GetServicesByUserId(userid).ToList();

                List<ServiceModel> model = new List<ServiceModel>();


                foreach (var item in status)
                {
                    ServiceModel service = new ServiceModel();
                    service.Id = item.Id;
                    service.UserName = item.UserName;
                    service.ProductName = item.ProductName;
                    service.Service_Issue = item.Service_Issue;
                    service.RequestedAt = item.RequestedAt;
                    service.IsApproved = (bool)item.IsApproved;
                    service.Status = item.Status;
                    service.Rating = (int)item.Rating;
                    model.Add(service);
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

        public int RateService(int Id, int Rating)
        {
            try
            {
                var status = db.RateService(Id, Rating);

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

        public int InsertService(int UserId,string ProductName,string Issue)
        {
            try
            {
                var status = db.InsertService(UserId, ProductName, Issue);

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

        public List<RatingModel> GetRating(int month,int year)
        {
            try
            {
                var status = db.GetReports(month,year).ToList();

                List<RatingModel> model = new List<RatingModel>();

                foreach (var item in status)
                {
                    RatingModel rating = new RatingModel();
                    rating.WorkerId = (int)item.WorkerId;
                    rating.WorkerName = item.Worker_Name;
                    rating.Rating = (int)item.Rating;
                    model.Add(rating);
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
    }
}