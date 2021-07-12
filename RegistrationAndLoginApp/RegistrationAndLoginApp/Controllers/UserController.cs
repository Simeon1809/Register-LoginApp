using Energy_Managers.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;
using RegistrationAndLoginApp.Models;
using RegistrationAndLoginApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationAndLoginApp.Controllers
{
    public class UserController : Controller
    {
      
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        [CustomAuthorization]
        public IActionResult PrivateSectionMustBeLoggedIn()
        {
            return Content("I am a protected method ");
        }
         
        public IActionResult ProcessingLogin(UserModel userModel)
        {
            HttpContext.Session.SetString("username", userModel.UserName);
            MyLogger.GetInstance().Info(userModel.toString());
            securityServices security = new securityServices();
            if (security.isValid(userModel))
            {
                MyLogger.GetInstance().Info("Login Successful");
                return View("LoginSuccess", userModel);
            }
            else
            {
                HttpContext.Session.Remove("username");
                MyLogger.GetInstance().Warning("Login Failure");
                return View("LoginFailure", userModel);
            }

        }
        public IActionResult RegistrationForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ProcessRegistration(UserModel userModel)
        {
            UserDataDAO usersDAO = new UserDataDAO();
            usersDAO.Insert(userModel);
            return View("Login");
        }
    }
}
