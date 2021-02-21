using CoolCareSystem.BusinessLayer;
using CoolCareSystem.DataLayer;
using CoolCareSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CoolCareSystem.Controllers
{
    public class AccountController : Controller
    {
        AccountBAL accounts = new AccountBAL();
        AccountDAL data = new AccountDAL();

        public ActionResult Index()
        {
            return Redirect("~/account/login");
        }

        [HttpGet]
        public ActionResult Login()
        {
            string username = User.Identity.Name;
            if (!string.IsNullOrEmpty(username))
                return RedirectToAction("welcome-page");

            LoginVM model = new LoginVM();
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var password = model.Password;
            bool isValid = false;

            LoginVM login = accounts.LoginUser(model);

            if (login.Username != null)
            {
                isValid = true;
            }

            if (!isValid)
            {
                TempData["Invalid"] = "Invalid username or password!";
                model.Password = password;
                return View(model);
            }
            else
            {
                FormsAuthentication.SetAuthCookie(model.Username, model.RememberMe);
                return Redirect(FormsAuthentication.GetRedirectUrl(model.Username, model.RememberMe));
            }
        }

        [ActionName("create-account")]
        [HttpGet]
        public ActionResult CreateAccount()
        {
            return View("CreateAccount");
        }

        [ActionName("create-account")]
        [HttpPost]
        public ActionResult CreateAccount(UserModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateAccount", model);
            }

            bool checkPassword = accounts.checkPassword(model);

            if (!checkPassword)
            {
                TempData["PasswordError"] = "Password do not match!";
                return View("CreateAccount", model);
            }

            int addedStatus = accounts.AddUser(model);

            if (addedStatus == 2)
            {
                TempData["SuccessMessage"] = "You are now registered and can Login!";
            }
            else
            {
                TempData["UserNameTaken"] = "Username " + model.UserName + " is taken!";
                model.UserName = "";
                return View("CreateAccount", model);
            }

            return Redirect("~/account/login");
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("~/Account/Login");
        }

        [Authorize]
        public ActionResult UserNavPartial()
        {
            string username = User.Identity.Name;

            UserNavPartialVM model;

            model = data.GetUserDetails(username);

            return PartialView(model);
        }

        [Authorize]
        [ActionName("user-profile")]
        [HttpGet]
        public ActionResult UserProfile()
        {
            string username = User.Identity.Name;

            UserProfileVM model;

            model = data.GetUserProfile(username);

            return View("UserProfile", model);
        }

        [Authorize]
        [ActionName("user-profile")]
        [HttpPost]
        public ActionResult UserProfile(UserProfileVM model)
        {
            if (!ModelState.IsValid)
            {
                return View("UserProfile", model);
            }

            if (!string.IsNullOrEmpty(model.Password))
            {
                bool checkPassword = accounts.passwordCheck(model);

                if (!checkPassword)
                {
                    TempData["PasswordError"] = "Password do not match!";
                    return View("UserProfile", model);
                }
            }

            int updatedStatus = accounts.UpdateUser(model);

            if (updatedStatus == 1)
            {
                TempData["SuccessMessage"] = "You have edited your profile!";
            }
            else
            {
                TempData["ErrorMessage"] = "Username " + model.UserName + " already exists!";
                model.UserName = "";
                return View("UserProfile", model);
            }

            return Redirect("~/Account/user-profile");
        }

        [Authorize]
        [ActionName("welcome-page")]
        [HttpGet]
        public ActionResult Welcome()
        {
            return View("Welcome");
        }
    }
}