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
    public class BoardController : BaseController
    {
        // GET: Login/Board

        private readonly BoardServices _BoardServices;
        private readonly string ViewForm = "Edit";
        public string imagename;


        public BoardController()
        {
            _BoardServices = new BoardServices(_unitOfWork);
        }

        public ActionResult BoardOfDirectorList()
        {
            SessionKontrol();
            if (_users != null)
            {
                var serviceResult = _BoardServices.GetAllDirector();

                return View(serviceResult);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult BoardOfDirectorDetail(int? Id, string type)
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
                    var viewModel = _BoardServices.Get(Id);
                    ViewBag.Image = _BoardServices.Get(Id).Image;
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

        public ActionResult BoardOfDirectorAdd()
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
        public ActionResult BoardOfDirectorSave(BoardViewModel viewModel, HttpPostedFileBase Image)
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
                    var isValid = Validate(viewModel, new BoardValidator(), ModelState);
                    if (isValid)
                    {
                        if (viewModel.Id == 0)
                        {
                            UploadFiles(Image);
                            viewModel.Image = imagename;
                            viewModel.Status = true;
                            viewModel.BoardType = (BoardType)1;

                            if (_BoardServices.GetAllDirector().Count() == 0)
                            {
                                viewModel.Count = 0;
                            }

                            else
                            {
                                viewModel.Count = _BoardServices.GetAllDirector().OrderByDescending(x => x.Count).First().Count;
                            }

                            _BoardServices.Add(viewModel);
                        }
                        else
                        {
                            var getimg = _BoardServices.Get(viewModel.Id).Image;
                            if (viewModel.Image == "0")
                            {
                                viewModel.Image = getimg;
                                viewModel.Status = true;
                                _BoardServices.Update(viewModel);
                            }
                            else
                            {
                                UploadFiles(Image);
                                viewModel.Image = "/Areas/Login/Assets/images/" + imagename;
                                _BoardServices.Update(viewModel);
                            }

                        }
                    }
                    else
                    {
                        if (viewModel.Id == 0)
                        {
                            return View("boardofdirectoradd", viewModel);
                        }
                        else
                        {
                            return View("boardofdirectordetail", viewModel);
                        }
                    }
                }
                catch (Exception)
                {
                    return View(ViewForm, viewModel);
                }
                _unitOfWork.SaveChanges();
                return RedirectToAction("BoardOfDirectorList", "Board");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult BoardOfDirectorDelete(int Id)
        {
            SessionKontrol();
            if (_users != null)
            {
                var serviceResult = _BoardServices.Get(Id);

                var list = _BoardServices.GetAllDirector().Where(x => x.Count > serviceResult.Count).ToList();
                foreach (var item in list)
                {
                    item.Count--;
                    _BoardServices.Update(item);
                }

                _BoardServices.Delete(Id);

                _unitOfWork.SaveChanges();
                return RedirectToAction("BoardOfDirectorList", "Board");

            }

            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        /* -------------------------------------------------------------------------------- */
        public ActionResult BoardOfDirectorUp(int Id)
        {
            SessionKontrol();
            if (_users != null)
            {
                var serviceResultUp = _BoardServices.Get(Id);
                var serviceResultDown = _BoardServices.GetAllDirector().FirstOrDefault(x => x.Count == (serviceResultUp.Count - 1));

                if (serviceResultUp.Count > 1)
                {
                    serviceResultUp.Count--;
                    serviceResultDown.Count++;
                    _BoardServices.Update(serviceResultUp);
                    _BoardServices.Update(serviceResultDown);
                }

                _unitOfWork.SaveChanges();
                return RedirectToAction("BoardOfDirectorList", "Board");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        /* -------------------------------------------------------------------------------- */
        public ActionResult BoardOfDirectorDown(int Id)
        {
            SessionKontrol();
            if (_users != null)
            {
                var serviceResultDown = _BoardServices.Get(Id);

                var lastCount = _BoardServices.GetAllDirector().OrderByDescending(x => x.Count).FirstOrDefault();
                if (serviceResultDown.Count < lastCount.Count)
                {
                    var serviceResultUp = _BoardServices.GetAllDirector().FirstOrDefault(x => x.Count == (serviceResultDown.Count + 1));
                    serviceResultDown.Count++;
                    serviceResultUp.Count--;
                    _BoardServices.Update(serviceResultDown);
                    _BoardServices.Update(serviceResultUp);
                }

                _unitOfWork.SaveChanges();
                return RedirectToAction("BoardOfDirectorList", "Board");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        /* -------------------------------------------------------------------------------- */


        public ActionResult BoardOfAuditorList()
        {
            SessionKontrol();
            if (_users != null)
            {
                var serviceResult = _BoardServices.GetAllAuditor();

                return View(serviceResult);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult BoardOfAuditorDetail(int? Id, string type)
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
                    var viewModel = _BoardServices.Get(Id);
                    ViewBag.Image = _BoardServices.Get(Id).Image;
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

        public ActionResult BoardOfAuditorSave(BoardViewModel viewModel, HttpPostedFileBase Image)
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
                    var isValid = Validate(viewModel, new BoardValidator(), ModelState);
                    if (isValid)
                    {
                        if (viewModel.Id == 0)
                        {
                            UploadFiles(Image);
                            viewModel.Image = imagename;
                            viewModel.Status = true;
                            viewModel.BoardType = (BoardType)2;

                            if (_BoardServices.GetAllAuditor().Count() == 0)
                            {
                                viewModel.Count = 0;
                            }

                            else
                            {
                                viewModel.Count = _BoardServices.GetAllAuditor().OrderByDescending(x => x.Count).First().Count;
                            }


                            _BoardServices.Add(viewModel);
                        }
                        else
                        {
                            var getimg = _BoardServices.Get(viewModel.Id).Image;
                            if (viewModel.Image == "0")
                            {
                                viewModel.Image = getimg;
                                viewModel.Status = true;
                                _BoardServices.Update(viewModel);
                            }
                            else
                            {
                                UploadFiles(Image);
                                viewModel.Image = "/Areas/Login/Assets/images/" + imagename;
                                _BoardServices.Update(viewModel);
                            }

                        }
                    }
                    else
                    {
                        if (viewModel.Id == 0)
                        {
                            return View("boardofauditoradd", viewModel);
                        }
                        else
                        {
                            return View("boardofauditordetail", viewModel);
                        }
                    }
                }
                catch (Exception)
                {
                    return View(ViewForm, viewModel);
                }
                _unitOfWork.SaveChanges();
                return RedirectToAction("BoardOfAuditorList", "Board");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult BoardOfAuditorAdd()
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


        public ActionResult BoardOfAuditorUp(int Id)
        {
            SessionKontrol();
            if (_users != null)
            {
                var serviceResultUp = _BoardServices.Get(Id);
                var serviceResultDown = _BoardServices.GetAllAuditor().FirstOrDefault(x => x.Count == (serviceResultUp.Count - 1));

                if (serviceResultUp.Count > 1)
                {
                    serviceResultUp.Count--;
                    serviceResultDown.Count++;
                    _BoardServices.Update(serviceResultUp);
                    _BoardServices.Update(serviceResultDown);
                }

                _unitOfWork.SaveChanges();
                return RedirectToAction("BoardOfAuditorList", "Board");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }


        public ActionResult BoardOfAuditorDown(int Id)
        {
            SessionKontrol();
            if (_users != null)
            {
                var serviceResultDown = _BoardServices.Get(Id);

                var lastCount = _BoardServices.GetAllAuditor().OrderByDescending(x => x.Count).FirstOrDefault();
                if (serviceResultDown.Count < lastCount.Count)
                {
                    var serviceResultUp = _BoardServices.GetAllAuditor().FirstOrDefault(x => x.Count == (serviceResultDown.Count + 1));
                    serviceResultDown.Count++;
                    serviceResultUp.Count--;
                    _BoardServices.Update(serviceResultDown);
                    _BoardServices.Update(serviceResultUp);
                }

                _unitOfWork.SaveChanges();
                return RedirectToAction("BoardOfAuditorList", "Board");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }


        public ActionResult BoardOfAuditorDelete(int Id)
        {
            SessionKontrol();
            if (_users != null)
            {
                var serviceResult = _BoardServices.Get(Id);
               
                var list = _BoardServices.GetAllAuditor().Where(x => x.Count > serviceResult.Count).ToList();
                foreach (var item in list)
                {
                    item.Count--;
                    _BoardServices.Update(item);
                }

                _BoardServices.Delete(Id);

                _unitOfWork.SaveChanges();
                return RedirectToAction("BoardOfAuditorList", "Board");

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