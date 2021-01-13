using CoolCareSystem.DataLayer;
using CoolCareSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace CoolCareSystem.BusinessLayer
{
    public class AccountBAL
    {
        public bool checkPassword(UserModel model)
        {
            AccountDAL accountData = new AccountDAL();

            try
            {

                if (model.Password.Equals(model.ConfirmPassword))
                {
                    return true;
                }

                return false;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accountData = null;
            }
        }

        public int AddUser(UserModel model)
        {
            AccountDAL accountData = new AccountDAL();

            try
            {
                model.Password =GetHashString(model.Password);
                return accountData.AddUser(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accountData = null;
            }
        }

        public LoginVM LoginUser(LoginVM model)
        {
            AccountDAL accountData = new AccountDAL();

            try
            {
                model.Password = GetHashString(model.Password);
                return accountData.LoginUser(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accountData = null;
            }
        }

        public bool passwordCheck(UserProfileVM model)
        {
            AccountDAL accountData = new AccountDAL();

            try
            {
                if (model.Password.Equals(model.ConfirmPassword))
                {
                    return true;
                }

                return false;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accountData = null;
            }
        }

        public int UpdateUser(UserProfileVM model)
        {
            AccountDAL accountData = new AccountDAL();

            try
            {
                if (model.Password != null)
                {
                    model.Password =GetHashString(model.Password);
                }
                return accountData.UpdateUser(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accountData = null;
            }
        }

        public static byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }
    }
}