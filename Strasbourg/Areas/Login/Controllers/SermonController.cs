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
    public class SermonController : BaseController
    {
        private readonly SermonServices _SermonServices;
        private readonly string ViewForm = "Edit";
        public string imagename;

        public SermonController()
        {
            _SermonServices = new SermonServices(_unitOfWork);
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SermonAdd()
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
        public ActionResult SermonList()
        {
            SessionKontrol();
            if (_users != null)
            {
                var serviceResult = _SermonServices.GetAll().OrderByDescending(x => x.CreationDate);

                return View(serviceResult);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult SermonDetail(int? Id, string type)
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
                    var viewModel = _SermonServices.Get(Id);
                    ViewBag.Image = _SermonServices.Get(Id).Image;
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
        public ActionResult SermonSave(SermonViewModel viewModel, HttpPostedFileBase Image)
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
                    var isValid = Validate(viewModel, new SermonValidator(), ModelState);
                    if (isValid)
                    {

                        if (viewModel.Id == 0)
                        {
                            UploadFiles(Image);
                            viewModel.Image = imagename;
                            viewModel.Status = true;

                            _SermonServices.Add(viewModel);
                        }
                        else
                        {
                            var getimg = _SermonServices.Get(viewModel.Id).Image;
                            if (viewModel.Image == "0")
                            {
                                viewModel.Image = getimg;
                                viewModel.Status = true;
                                _SermonServices.Update(viewModel);
                            }
                            else
                            {
                                UploadFiles(Image);
                                viewModel.Image = "/Areas/Login/Assets/images/" + imagename;
                                _SermonServices.Update(viewModel);
                            }

                        }
                    }
                    else
                    {
                        if (viewModel.Id == 0)
                        {
                            return View("sermonadd", viewModel);
                        }
                        else
                        {
                            return View("sermondetail", viewModel);
                        }
                    }
                }
                catch (Exception)
                {
                    return View(ViewForm, viewModel);
                }
                _unitOfWork.SaveChanges();
                return RedirectToAction("SermonList", "Sermon");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult SermonDelete(int Id)
        {
            SessionKontrol();
            if (_users != null)
            {

                _SermonServices.Delete(Id);

                _unitOfWork.SaveChanges();
                return RedirectToAction("SermonList", "Sermon");
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