using Strasbourg.DAL.UnitOfWork;
using Strasbourg.Domain.ViewModels;
using Strasbourg.Services.DBServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Strasbourg.UI.Areas.Login.Controllers;
namespace Strasbourg.UI.Areas.Login.Controllers
{
    public class LoginController : Controller
    {
        private readonly STUnitOfWork _unitOfWork;
        private readonly UsersServices _usersServices;

        public LoginController()
        {
            _unitOfWork = new STUnitOfWork();
            _usersServices = new UsersServices(_unitOfWork);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignIn(UsersViewModel viewModel)
        {
            var user = _usersServices.SignIn(viewModel);
            if (user == null)
            {
                TempData["Error"] = "Girmiş olduğunuz kullanıcı sistemde mevcut değil veya email şifre hatalı";
                return Redirect("/Admin/");
            }
            else
            {
                Session.Add("user", user);
                Session.Timeout = 800;

                HttpCookie cookie = new HttpCookie("user");
                cookie.Values.Add("logintime", DateTime.Now.ToString());
                cookie.Expires = DateTime.Now.AddHours(60);
                Response.Cookies.Add(cookie);

                return Redirect("/Admin/Home");
            }
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return Redirect("/Admin");
        }

        //Todo: Şifremi unuttum alanı sorulacak ona göre yapılacak girecek kullanıcılar sabit olduğu için gerek var mı?
        public ActionResult ForgetPassword()
        {
            return View();
        }
    }
}