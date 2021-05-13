using Strasbourg.DAL.Models;
using Strasbourg.DAL.Repository;
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
    public class VideoController : BaseController
    {
        private readonly VideoServices _VideoServices;
        private readonly string ViewForm = "Edit";
        public string imagename;

        public VideoController()
        {
            _VideoServices = new VideoServices(_unitOfWork);
        }

        public ActionResult VideoAdd()
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

        public ActionResult VideoList()
        {
            SessionKontrol();
            if (_users != null)
            {
                var serviceResult = _VideoServices.GetAll().OrderByDescending(x => x.CreationDate);

                return View(serviceResult);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult VideoDetail(int? Id, string type)
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
                    var viewModel = _VideoServices.Get(Id);
                    ViewBag.Image = _VideoServices.Get(Id).Thumbnail;
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

        public ActionResult VideoSave(VideoViewModel viewModel, HttpPostedFileBase Thumbnail)
        {
            SessionKontrol();
            if (_users != null)
            {

                try
                {
                    if (viewModel.Thumbnail == null)
                    {
                        viewModel.Thumbnail = "0";
                    }
                    var isValid = Validate(viewModel, new VideoValidator(), ModelState);
                    if (isValid)
                    {

                        if (viewModel.Id == 0)
                        {
                            UploadFiles(Thumbnail);
                            viewModel.Thumbnail = imagename;
                            viewModel.Status = true;

                            _VideoServices.Add(viewModel);
                        }
                        else
                        {
                            var getimg = _VideoServices.Get(viewModel.Id).Thumbnail;
                            if (viewModel.Thumbnail == "0")
                            {
                                viewModel.Thumbnail = getimg;
                                viewModel.Status = true;
                                _VideoServices.Update(viewModel);
                            }
                            else
                            {
                                UploadFiles(Thumbnail);
                                viewModel.Thumbnail = "/Areas/Login/Assets/images/" + imagename;
                                _VideoServices.Update(viewModel);
                            }

                        }
                    }
                    else
                    {
                        if (viewModel.Id == 0)
                        {
                            return View("videoadd", viewModel);
                        }
                        else
                        {
                            return View("videodetail", viewModel);
                        }
                    }
                }
                catch (Exception)
                {
                    return View(ViewForm, viewModel);
                }
                _unitOfWork.SaveChanges();
                return RedirectToAction("VideoList", "Video");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult VideoDelete(int Id)
        {
            SessionKontrol();
            if (_users != null)
            {

                _VideoServices.Delete(Id);
                _unitOfWork.SaveChanges();
                return RedirectToAction("VideoList", "Video");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public void UploadFiles(HttpPostedFileBase Thumbnail)
        {
            if (Thumbnail != null)
            {
                Guid id = Guid.NewGuid();

                string path = Path.Combine(Server.MapPath("/Areas/Login/Assets/images"), id + Thumbnail.FileName);
                Thumbnail.SaveAs(path);
                imagename = id + Thumbnail.FileName;
            }

        }
    }
}