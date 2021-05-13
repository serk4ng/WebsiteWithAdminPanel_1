using Strasbourg.Domain.Enums;
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
    public class NewsController : BaseController
    {
        private readonly NewsServices _NewsServices;
        private readonly NewsCategoryServices _NewsCategoryServices;
        private readonly string ViewForm = "Edit";
        public string imagename;
     

        public NewsController()
        {
            _NewsServices = new NewsServices(_unitOfWork);
            _NewsCategoryServices = new NewsCategoryServices(_unitOfWork);
        }
        public ActionResult NewsList()
        {
            SessionKontrol();
            if (_users != null)
            {
                var serviceResult = _NewsServices.GetAll().OrderByDescending(x => x.CreationDate);

                return View(serviceResult);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult NewsDetail(int? Id, string type)
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
                    var viewModel = _NewsServices.Get(Id);
                    ViewBag.Image = _NewsServices.Get(Id).Image;

                    var viewCategoryModel = _NewsCategoryServices.GetAll();
               
                    return View(new Tuple<NewsViewModel, IQueryable<NewsCategoryViewModel>>(viewModel, viewCategoryModel));
                
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

        public ActionResult NewsAdd()
        {
            SessionKontrol();
            if (_users != null)
            {
                var viewCategoryModel = _NewsCategoryServices.GetAll();
                NewsViewModel nvm = new NewsViewModel();
                return View(new Tuple<NewsViewModel, IQueryable<NewsCategoryViewModel>>(nvm, viewCategoryModel));
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult NewsCategoryAdd()
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

        public ActionResult NewsSave(NewsViewModel viewModel , HttpPostedFileBase Image)
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
                    var isValid = Validate(viewModel, new NewsValidator(), ModelState);
                    if (isValid)
                    {

                        if (viewModel.Id == 0)
                        {
                            UploadFiles(Image);
                            viewModel.Image = imagename;
                            viewModel.Status = true;

                            _NewsServices.Add(viewModel);
                        }
                        else
                        {
                            var getimg = _NewsServices.Get(viewModel.Id).Image;
                            if (viewModel.Image == "0")
                            {
                                viewModel.Image = getimg;
                                viewModel.Status = true;
                                _NewsServices.Update(viewModel);
                            }
                            else
                            {
                                UploadFiles(Image);
                                viewModel.Image = "/Areas/Login/Assets/images/" + imagename;
                                _NewsServices.Update(viewModel);
                            }

                        }
                    }
                    else
                    {
                        if (viewModel.Id == 0)
                        {
                            return View("newsadd", viewModel);
                        }
                        else
                        {
                            return View("newsdetail", viewModel);
                        }
                    }
                }
                catch (Exception)
                {
                    return View(ViewForm, viewModel);
                }
                _unitOfWork.SaveChanges();
                return RedirectToAction("NewsList", "News");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult NewsDelete(int Id)
        {
            SessionKontrol();
            if (_users != null)
            {
       
                _NewsServices.Delete(Id);

                _unitOfWork.SaveChanges();
                return RedirectToAction("NewsList", "News");
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

        // News Category

        public ActionResult NewsCategoryList()
        {
            SessionKontrol();
            if (_users != null)
            {
                var serviceResult = _NewsCategoryServices.GetAll().OrderByDescending(x => x.SiteLanguage);

                return View(serviceResult);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }


        public ActionResult NewsCategoryDelete(int Id)
        {
            SessionKontrol();
            if (_users != null)
            {

                _NewsCategoryServices.Delete(Id);

                _unitOfWork.SaveChanges();
                return RedirectToAction("NewsCategoryList", "News");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult NewsCategorySave(NewsCategoryViewModel viewModel)
        {
            SessionKontrol();
            if (_users != null)
            {
                try
                {
                    var isValid = Validate(viewModel, new NewsCategoryValidator(), ModelState);
                    if (isValid)
                    {
                        if (viewModel.Id == 0)
                        {
                            viewModel.Status = true;
                            _NewsCategoryServices.Add(viewModel);
                        }
                        else
                        {
                            viewModel.Status = true;
                            _NewsCategoryServices.Update(viewModel);
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
                return RedirectToAction("NewsCategoryList", "News");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }


        public ActionResult NewsCategoryDetail(int? Id)
        {
            SessionKontrol();
            if (_users != null)
            {
   
                if (Id != null)
                {
                    var viewModel = _NewsCategoryServices.Get(Id);
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

    }
}