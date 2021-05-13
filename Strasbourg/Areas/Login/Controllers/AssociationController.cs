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
    public class AssociationController : BaseController
    {
        private readonly AssociationServices _AssociationServices;
        private readonly string ViewForm = "associationdetail";
        public string imagename ;
        public AssociationController()
        {
            _AssociationServices = new AssociationServices(_unitOfWork);
        }

        public ActionResult AssociationList()
        {
            SessionKontrol();
            if (_users != null)
            {
                var serviceResult = _AssociationServices.GetAll();

                return View(serviceResult);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult AssociationDetail(int? Id, string type)
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
                    var viewModel = _AssociationServices.Get(Id);
                    ViewBag.Image = _AssociationServices.Get(Id).Image;
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

        public ActionResult AssociationAdd()
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

        public ActionResult AssociationSave(AssociationViewModel viewModel, HttpPostedFileBase Image)
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
                    var isValid = Validate(viewModel, new AssociationValidator(), ModelState);
                    if (isValid)
                    {
                        if (viewModel.Id == 0)
                        {
                            UploadFiles(Image);
                            viewModel.Image = imagename;
                            viewModel.Status = true;
                        
                            if (_AssociationServices.GetAll().Count() == 0)
                            {
                                viewModel.Count = 0 ;
                            }
  
                            else
                            {
                                viewModel.Count = _AssociationServices.GetAll().OrderByDescending(x => x.Count).First().Count;
                            }

                          
                            _AssociationServices.Add(viewModel);
                        }
                        else
                        {
                            var getimg = _AssociationServices.Get(viewModel.Id).Image;
                            if (viewModel.Image == "0")
                            {
                                viewModel.Image = getimg;
                                viewModel.Status = true;
                                _AssociationServices.Update(viewModel);
                            }
                            else
                            {
                                UploadFiles(Image);
                                viewModel.Image = "/Areas/Login/Assets/images/"+imagename;
                                _AssociationServices.Update(viewModel);
                            }
                       
                        }
                    }
                    else
                    {
                        if (viewModel.Id == 0)
                        {
                            return View("associationadd", viewModel);
                        }
                        else
                        {
                            return View("associationdetail", viewModel);
                        }
                  
                    }
                }
                catch (Exception)
                {
                    return View(ViewForm, viewModel);
                }
                _unitOfWork.SaveChanges();
                return RedirectToAction("AssociationList", "Association");
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

                string path = Path.Combine(Server.MapPath("/Areas/Login/Assets/images"), id+Image.FileName );
                Image.SaveAs(path);
                imagename = id + Image.FileName;
            }

        }


        public ActionResult AssociationDelete(int Id)
        {
            SessionKontrol();
            if (_users != null)
            {
                var serviceResult = _AssociationServices.Get(Id);
 
                var list = _AssociationServices.GetAll().Where(x=>x.Count >serviceResult.Count).ToList();

                foreach (var item in list)
                {
                    item.Count--;
                    _AssociationServices.Update(item);
                }
                _AssociationServices.Delete(Id);
             
                _unitOfWork.SaveChanges();
                return RedirectToAction("AssociationList", "Association");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult AssociationUp(int Id)
        {
            SessionKontrol();
            if (_users != null)
            {
                var serviceResultUp =  _AssociationServices.Get(Id);
                var serviceResultDown = _AssociationServices.GetAll().FirstOrDefault(x=>x.Count == (serviceResultUp.Count-1));

                if (serviceResultUp.Count>1)
                {
                    serviceResultUp.Count--;
                    serviceResultDown.Count++;
                    _AssociationServices.Update(serviceResultUp);
                    _AssociationServices.Update(serviceResultDown);
                }

                _unitOfWork.SaveChanges();
                return RedirectToAction("AssociationList", "Association");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult AssociationDown(int Id)
        {
            SessionKontrol();
            if (_users != null)
            {
                var serviceResultDown = _AssociationServices.Get(Id);

                var lastCount = _AssociationServices.GetAll().OrderByDescending(x=>x.Count).FirstOrDefault();
                if (serviceResultDown.Count < lastCount.Count)
                {
                    var serviceResultUp = _AssociationServices.GetAll().FirstOrDefault(x => x.Count == (serviceResultDown.Count + 1));
                    serviceResultDown.Count++;
                    serviceResultUp.Count--;
                    _AssociationServices.Update(serviceResultDown);
                    _AssociationServices.Update(serviceResultUp);
                }

                _unitOfWork.SaveChanges();
                return RedirectToAction("AssociationList", "Association");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
 

}
 