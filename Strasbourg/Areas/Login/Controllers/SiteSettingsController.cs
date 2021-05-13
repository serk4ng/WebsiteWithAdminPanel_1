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
    public class SiteSettingsController : BaseController
    {
        private readonly SiteSettingsServices _SiteSettingsServices;
        private readonly string ViewForm = "Edit";
        public string logo;
        public string slider1;
        public string slider2;
        public string slider3;
        public string slider4;
        public SiteSettingsController()
        {
            _SiteSettingsServices = new SiteSettingsServices(_unitOfWork);
  

        }
        public ActionResult Index(int? Id)
        {
            SessionKontrol();
            if (_users != null)
            {
                if (Id != null)
                {
                    var viewModel = _SiteSettingsServices.Get(Id);
                    ViewBag.Logo = _SiteSettingsServices.Get(Id).Logo;
                    ViewBag.Slider1 = _SiteSettingsServices.Get(Id).Slider1;
                    ViewBag.Slider2 = _SiteSettingsServices.Get(Id).Slider2;
                    ViewBag.Slider3 = _SiteSettingsServices.Get(Id).Slider3;
                    ViewBag.Slider4 = _SiteSettingsServices.Get(Id).Slider4;
                    ViewBag.SiteLanguage = _SiteSettingsServices.Get(Id).SiteLanguage;
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

        public ActionResult SiteSettingsList()
        {
            SessionKontrol();
            if (_users != null)
            {
                var serviceResult = _SiteSettingsServices.GetAll();

                return View(serviceResult);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }





        public ActionResult SiteSettingsSave(SiteSettingsViewModel viewModel, HttpPostedFileBase Logo, HttpPostedFileBase Slider1, HttpPostedFileBase Slider2, HttpPostedFileBase Slider3, HttpPostedFileBase Slider4)
        {
            SessionKontrol();
            if (_users != null)
            {

                try
                {
                    if (viewModel.Logo == null)
                    {
                        viewModel.Logo = "0";
                    }
                    if (viewModel.Slider1 == null)
                    {
                        viewModel.Slider1 = "0";
                    }
                    if (viewModel.Slider2 == null)
                    {
                        viewModel.Slider2 = "0";
                    }
                    if (viewModel.Slider3 == null)
                    {
                        viewModel.Slider3 = "0";
                    }
                    if (viewModel.Slider4 == null)
                    {
                        viewModel.Slider4 = "0";
                    }
                    var isValid = Validate(viewModel, new SiteSettingsValidator(), ModelState);
                    if (isValid)
                    {
                        if (viewModel.Id == 0)
                        {
                            UploadFiles(Logo,Slider1,Slider2,Slider3);
                            viewModel.Logo = logo;
                            viewModel.Slider1 = slider1;
                            viewModel.Slider2 = slider2;
                            viewModel.Slider3 = slider3;
                            viewModel.Slider4 = slider4;
                            viewModel.Status = true;
                            
 


                            _SiteSettingsServices.Add(viewModel);
                        }
                        else
                        {
                            var getlogo = _SiteSettingsServices.Get(viewModel.Id).Logo;
                            var getslider1 = _SiteSettingsServices.Get(viewModel.Id).Slider1;
                            var getslider2 = _SiteSettingsServices.Get(viewModel.Id).Slider2;
                            var getslider3 = _SiteSettingsServices.Get(viewModel.Id).Slider3;
                            var getslider4 = _SiteSettingsServices.Get(viewModel.Id).Slider4;
                            if (viewModel.Logo == "0")
                            {
                                viewModel.Logo = getlogo;
                                viewModel.Status = true;
                                _SiteSettingsServices.Update(viewModel);
                            }
                            else
                            {
                                UploadFiles_Logo(Logo);
                                viewModel.Logo = "/Areas/Login/Assets/images/" + logo;
                                
                               _SiteSettingsServices.Update(viewModel);
                            }

                            if (viewModel.Slider1 == "0")
                            {
                                viewModel.Slider1 = getslider1;
                                viewModel.Status = true;
                                _SiteSettingsServices.Update(viewModel);
                            }
                            else
                            {
                                UploadFiles_Slider1(Slider1);
                                viewModel.Slider1 = "/Areas/Login/Assets/images/" + slider1;

                                _SiteSettingsServices.Update(viewModel);
                            }

                            if (viewModel.Slider2 == "0")
                            {
                                viewModel.Slider2 = getslider2;
                                viewModel.Status = true;
                                _SiteSettingsServices.Update(viewModel);
                            }
                            else
                            {
                                UploadFiles_Slider2(Slider2);
                                viewModel.Slider2 = "/Areas/Login/Assets/images/" + slider2;

                                _SiteSettingsServices.Update(viewModel);
                            }

                            if (viewModel.Slider3 == "0")
                            {
                                viewModel.Slider3 = getslider3;
                                viewModel.Status = true;
                                _SiteSettingsServices.Update(viewModel);
                            }
                            else
                            {
                                UploadFiles_Slider3(Slider3);
                                viewModel.Slider3 = "/Areas/Login/Assets/images/" + slider3;

                                _SiteSettingsServices.Update(viewModel);
                            }

                            if (viewModel.Slider4 == "0")
                            {
                                viewModel.Slider4 = getslider4;
                                viewModel.Status = true;
                                _SiteSettingsServices.Update(viewModel);
                            }
                            else
                            {
                                UploadFiles_Slider4(Slider4);
                                viewModel.Slider4 = "/Areas/Login/Assets/images/" + slider4;

                                _SiteSettingsServices.Update(viewModel);
                            }

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
                return RedirectToAction("SiteSettingsList", "SiteSettings");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }







        public void UploadFiles(HttpPostedFileBase Logo, HttpPostedFileBase Slider1, HttpPostedFileBase Slider2, HttpPostedFileBase Slider3)
        {
            if (Logo != null)
            {
                Guid id = Guid.NewGuid();

                string path = Path.Combine(Server.MapPath("/Areas/Login/Assets/images"), id + Logo.FileName);
                Logo.SaveAs(path);
                logo = id + Logo.FileName;
            }

            if (Slider1 != null)
            {
                Guid id = Guid.NewGuid();

                string path = Path.Combine(Server.MapPath("/Areas/Login/Assets/images"), id + Slider1.FileName);
                Slider1.SaveAs(path);
                slider1 = id + Slider1.FileName;
            }
            if (Slider2 != null)
            {
                Guid id = Guid.NewGuid();

                string path = Path.Combine(Server.MapPath("/Areas/Login/Assets/images"), id + Slider2.FileName);
                Slider2.SaveAs(path);
                slider2 = id + Slider2.FileName;
            }

            if (Slider3 != null)
            {
                Guid id = Guid.NewGuid();

                string path = Path.Combine(Server.MapPath("/Areas/Login/Assets/images"), id + Slider3.FileName);
                Slider3.SaveAs(path);
                slider3 = id + Slider3.FileName;
            }


        }

        public void UploadFiles_Logo(HttpPostedFileBase Image)
        {
            if (Image != null)
            {
                Guid id = Guid.NewGuid();

                string path = Path.Combine(Server.MapPath("/Areas/Login/Assets/images"), id + Image.FileName);
                Image.SaveAs(path);
                logo = id + Image.FileName;
            }

        }
        public void UploadFiles_Slider1(HttpPostedFileBase Image)
        {
            if (Image != null)
            {
                Guid id = Guid.NewGuid();

                string path = Path.Combine(Server.MapPath("/Areas/Login/Assets/images"), id + Image.FileName);
                Image.SaveAs(path);
                slider1 = id + Image.FileName;
            }

        }
        public void UploadFiles_Slider2(HttpPostedFileBase Image)
        {
            if (Image != null)
            {
                Guid id = Guid.NewGuid();

                string path = Path.Combine(Server.MapPath("/Areas/Login/Assets/images"), id + Image.FileName);
                Image.SaveAs(path);
                slider2 = id + Image.FileName;
            }

        }
        public void UploadFiles_Slider3(HttpPostedFileBase Image)
        {
            if (Image != null)
            {
                Guid id = Guid.NewGuid();

                string path = Path.Combine(Server.MapPath("/Areas/Login/Assets/images"), id + Image.FileName);
                Image.SaveAs(path);
                slider3 = id + Image.FileName;
            }

        }

        public void UploadFiles_Slider4(HttpPostedFileBase Image)
        {
            if (Image != null)
            {
                Guid id = Guid.NewGuid();

                string path = Path.Combine(Server.MapPath("/Areas/Login/Assets/images"), id + Image.FileName);
                Image.SaveAs(path);
                slider4 = id + Image.FileName;
            }

        }
    }
}