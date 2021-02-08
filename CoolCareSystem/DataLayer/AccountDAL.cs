using CoolCareSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoolCareSystem.DataLayer
{
    public class AccountDAL
    {
        public int AddUser(UserModel model)
        {
            CoolCareSystemEntities db = new CoolCareSystemEntities();

            try
            {
                var status = db.AddUser(model.FirstName, model.LastName, model.EmailAddress,model.MobileNumber,model.UserName, model.Password);

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

        public LoginVM LoginUser(LoginVM Login)
        {
            CoolCareSystemEntities db = new CoolCareSystemEntities();

            try
            {

                var status = db.CheckUserCredentials(Login.Username, Login.Password).ToList();

                LoginVM model = new LoginVM();

                foreach (var item in status)
                {
                    model.Username = item.UserName;
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

        public UserNavPartialVM GetUserDetails(string Username)
        {
            CoolCareSystemEntities db = new CoolCareSystemEntities();

            try
            {

                var status = db.GetUserDetails(Username).ToList();

                UserNavPartialVM model = new UserNavPartialVM();

                foreach (var item in status)
                {
                    model.FirstName = item.FirstName;
                    model.LastName = item.LastName;
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

        public UserProfileVM GetUserProfile(string Username)
        {
            CoolCareSystemEntities db = new CoolCareSystemEntities();

            try
            {
                var status = db.GetUserDetails(Username).ToList();

                UserProfileVM model = new UserProfileVM();

                foreach (var item in status)
                {
                    model.Id = item.Id;
                    model.FirstName = item.FirstName;
                    model.LastName = item.LastName;
                    model.EmailAddress = item.EmailAddress;
                    model.MobileNumber = (decimal)item.MobileNumber;
                    model.UserName = item.UserName;
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

        public int UpdateUser(UserProfileVM model)
        {
            CoolCareSystemEntities db = new CoolCareSystemEntities();

            try
            {
                int status;

                if (model.Password != null)
                {
                    status = db.UpdateUserProfile(model.Id, model.FirstName, model.LastName, model.EmailAddress,model.MobileNumber, model.UserName, model.Password);
                }
                else
                {
                    status = db.UpdateUserProfile(model.Id, model.FirstName, model.LastName, model.EmailAddress,model.MobileNumber, model.UserName, null);
                }

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