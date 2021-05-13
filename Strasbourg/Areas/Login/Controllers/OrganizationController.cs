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
    public class OrganizationController : BaseController
    {
        // GET: Login/Organization
        private readonly SisterOrganizationServices _SisterOrganizationServices;
        private readonly RelatedOrganizationServices _RelatedOrganizationServices;
        private BaseViewModel basevm;
        private readonly string ViewForm = "Edit";
        public OrganizationController()
        {
            _SisterOrganizationServices = new SisterOrganizationServices(_unitOfWork);
            _RelatedOrganizationServices = new RelatedOrganizationServices(_unitOfWork);
     
        }
        public ActionResult SisterOrganizationList()
        {
            SessionKontrol();
            if (_users != null)
            {
                var serviceResult = _SisterOrganizationServices.GetAll();

                return View(serviceResult);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult SisterOrganizationDetail(int? Id, string type)
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
                    var viewModel = _SisterOrganizationServices.Get(Id);
                    ViewBag.Count = _SisterOrganizationServices.GetAll().Count();
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


        public ActionResult SisterOrganizationSave(SisterOrganizationViewModel viewModel)
        {
            SessionKontrol();
            if (_users != null)
            {
                try
                {
                    var isValid = Validate(viewModel, new SisterOrganizationValidator(), ModelState);
                    if (isValid)
                    {
                        if (viewModel.Id == 0)
                        {
                            viewModel.Status = true;
                            _SisterOrganizationServices.Add(viewModel);
                        }
                        else
                        {
                            viewModel.Status = true;
                            _SisterOrganizationServices.Update(viewModel);
                        }
                    }
                    else
                    {
                        if (viewModel.Id == 0)
                        {
                            return View("sisterorganizationadd", viewModel);
                        }
                        else
                        {
                            return View("sisterorganizationdetail", viewModel);
                        }
                    }
                }
                catch (Exception)
                {
                    return View(ViewForm, viewModel);
                }
                _unitOfWork.SaveChanges();
                return RedirectToAction("SisterOrganizationList", "Organization");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult SisterOrganizationDelete(int Id)
        {
            SessionKontrol();
            if (_users != null)
            {
                _SisterOrganizationServices.Delete(Id);

                _unitOfWork.SaveChanges();
                return RedirectToAction("SisterOrganizationList", "Organization");

            }

            else
            {
                return RedirectToAction("Index", "Login");
            }
        }


        /* --------------------------------------------------------------------- */


        public ActionResult RelatedOrganizationList()
        {
            SessionKontrol();
            if (_users != null)
            {
                var serviceResult = _RelatedOrganizationServices.GetAll();

                return View(serviceResult);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }


        public ActionResult RelatedOrganizationDetail(int? Id, string type)
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
                    var viewModel = _RelatedOrganizationServices.Get(Id);
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

        public ActionResult RelatedOrganizationSave(RelatedOrganizationViewModel viewModel)
        {
            SessionKontrol();
            if (_users != null)
            {
                try
                {
                    var isValid = Validate(viewModel, new RelatedOrganizationValidator(), ModelState);
                    if (isValid)
                    {
                        if (viewModel.Id == 0)
                        {
                            viewModel.Status = true;
                            _RelatedOrganizationServices.Add(viewModel);
                        }
                        else
                        {
                            viewModel.Status = true;
                            _RelatedOrganizationServices.Update(viewModel);
                        }
                    }
                    else
                    {
                        if (viewModel.Id == 0)
                        {
                            return View("relatedorganizationadd", viewModel);
                        }
                        else
                        {
                            return View("relatedorganizationdetail", viewModel);
                        }
                    }
                }
                catch (Exception)
                {
                    return View(ViewForm, viewModel);
                }
                _unitOfWork.SaveChanges();
                return RedirectToAction("RelatedOrganizationList", "Organization");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult RelatedOrganizationDelete(int Id)
        {
            SessionKontrol();
            if (_users != null)
            {
                _RelatedOrganizationServices.Delete(Id);

                _unitOfWork.SaveChanges();
                return RedirectToAction("RelatedOrganizationList", "Organization");

            }

            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}