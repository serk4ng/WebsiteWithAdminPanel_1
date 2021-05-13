using Strasbourg.Domain.Validations;
using Strasbourg.Domain.ViewModels;
using Strasbourg.Services.DBServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Strasbourg.UI.Areas.Login.Controllers
{
    public class UserController : BaseController
    {
        private readonly UsersServices _UsersServices;
        private readonly string ViewForm = "Edit";
        public UserController()
        {
            _UsersServices = new UsersServices(_unitOfWork);
        }

        public ActionResult Index()
        {
            var serviceResult = _UsersServices.GetAll();

            return View(serviceResult);
        }

        public ActionResult UserList()
        {
            SessionKontrol();
            if (_users != null)
            {
                var serviceResult = _UsersServices.GetAll().Where(x => x.Id != _users.Id);

                return View(serviceResult);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult UserDetail(int? Id, string type)
        {
            SessionKontrol();
            if (_users != null)
            {
                if (type != null)
                {
                    ViewBag.incele = "incele";
                }
                if (Id != null)
                {
                    var viewModel = _UsersServices.Get(Id);
                    return View(viewModel);
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult UserAdd()
        {
            SessionKontrol();
            if (_users != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }



        public ActionResult Edit(int Id)
        {
            SessionKontrol();
            if (_users != null)
            {
                var viewModel = _UsersServices.Get(Id);
                return View(viewModel);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult Save(UsersViewModel viewModel)
        {
            SessionKontrol();
            if (_users != null)
            {
                try
                {
                    var isValid = Validate(viewModel, new UserValidator(), ModelState);
                    if (isValid)
                    {
                        if (viewModel.Id == 0)
                        {
                            viewModel.Status = true;
                            _UsersServices.Add(viewModel);
                        }
                        else
                        {
                            viewModel.Status = true;
                            _UsersServices.Update(viewModel);
                        }
                    }
                    else
                    {
                        return View(ViewForm, viewModel);
                    }
                }
                catch (Exception)
                {
                    return View(ViewForm, viewModel);
                }
                _unitOfWork.SaveChanges();
                return RedirectToAction("UserList", "User");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult Delete(int Id)
        {
            SessionKontrol();
            if (_users != null)
            {
                _UsersServices.Delete(Id);

                _unitOfWork.SaveChanges();
                return RedirectToAction("UserList", "User");

            }

            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}