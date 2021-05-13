using Strasbourg.Domain.Validations;
using Strasbourg.Domain.ViewModels;
using Strasbourg.Services.DBServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Strasbourg.UI.Areas.Login.Controllers
{
    public class PublicationController : BaseController
    {
        private readonly PublicationServices _PublicationServices;
        public string imagename;
        public PublicationController()
        {
            _PublicationServices = new PublicationServices(_unitOfWork);
 
        }
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult PublicationList()
        {
            SessionKontrol();
            if (_users != null)
            {
                var serviceResult = _PublicationServices.GetAll().OrderByDescending(x => x.CreationDate);

                return View(serviceResult);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult PublicationDetail(int? Id)
        {
            SessionKontrol();
            if (_users != null)
            {
             
                if (Id != null)
                {
                    var viewModel = _PublicationServices.Get(Id);
                    ViewBag.Image = _PublicationServices.Get(Id).Image;
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

        public ActionResult PublicationAdd()
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
        public ActionResult PublicationSave(PublicationViewModel viewModel, HttpPostedFileBase Image)
        {
            SessionKontrol();
            if (_users != null)
            {

                try
                {
                    if (viewModel.Image == null)
                    {
                        viewModel.Image = "0";
                    }
                    var isValid = Validate(viewModel, new PublicationValidator(), ModelState);
                    if (isValid)
                    {

                        if (viewModel.Id == 0)
                        {
                            UploadFiles(Image);
                            viewModel.Image = imagename;
                            viewModel.Status = true;

                            _PublicationServices.Add(viewModel);
                        }
                        else
                        {
                            var getimg = _PublicationServices.Get(viewModel.Id).Image;
                            if (viewModel.Image == "0")
                            {
                                viewModel.Image = getimg;
                                viewModel.Status = true;
                                _PublicationServices.Update(viewModel);
                            }
                            else
                            {
                                UploadFiles(Image);
                                viewModel.Image = "/Areas/Login/Assets/images/" + imagename;
                                _PublicationServices.Update(viewModel);
                            }

                        }
                    }
                    else
                    {
                        if (viewModel.Id == 0)
                        {
                            return View("publicationadd", viewModel);
                        }
                        else
                        {
                            return View("publicationdetail", viewModel);
                        }
                    }
                }
                catch (Exception)
                {
                    if (viewModel.Id == 0)
                    {
                        return View("publicationadd", viewModel);
                    }
                    else
                    {
                        return View("publicationdetail", viewModel);
                    }
                }
                _unitOfWork.SaveChanges();
                return RedirectToAction("PublicationList", "Publication");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult PublicationDelete(int Id)
        {
            SessionKontrol();
            if (_users != null)
            {

                _PublicationServices.Delete(Id);

                _unitOfWork.SaveChanges();
                return RedirectToAction("PublicationList", "Publication");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public void UploadFiles(HttpPostedFileBase Image)
        {
            if (Image != null)
            {
                Guid id = Guid.NewGuid();

                string path = Path.Combine(Server.MapPath("/Areas/Login/Assets/images"), id + Image.FileName);
                Image.SaveAs(path);
                imagename = id + Image.FileName;
            }

        }
    }
}