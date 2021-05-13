using Strasbourg.DAL.Models;
using Strasbourg.Domain.ViewModels;
using Strasbourg.Services.DBServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace Strasbourg.UI.Areas.Login.Controllers
{
    public class DonationController : BaseController
    {
        private readonly GeneralDonationServices _GeneralDonationServices;
        private readonly FitreDonationServices _FitreDonationServices;
        private readonly RansomDonationServices _RansomDonationServices;
        private readonly AlmsDonationServices _AlmsDonationServices;
        private readonly SacrificeDonationServices _SacrificeDonationServices;
        private readonly AidToMosquesServices _AidToMosquesServices;

        private readonly SacrificePriceServices _SacrificePriceServices;
        public DonationController()
        {
            _GeneralDonationServices = new GeneralDonationServices(_unitOfWork);
            _FitreDonationServices = new FitreDonationServices(_unitOfWork);
            _RansomDonationServices = new RansomDonationServices(_unitOfWork);
            _AlmsDonationServices = new AlmsDonationServices(_unitOfWork);
            _SacrificeDonationServices = new SacrificeDonationServices(_unitOfWork);
            _AidToMosquesServices = new AidToMosquesServices(_unitOfWork);

            _SacrificePriceServices = new SacrificePriceServices(_unitOfWork);
        }

        public ActionResult SacrificeDonateList()
        {
            SessionKontrol();
            if (_users != null)
            {
                var serviceResult = _SacrificeDonationServices.GetAll().OrderByDescending(x => x.CreationDate);

                return View(serviceResult);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult SacrificeDonateDetail(int Id)
        {
            SessionKontrol();
            if (_users != null)
            {

                if (Id != null)
                {
                    var viewModel = _SacrificeDonationServices.Get(Id);

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

        public ActionResult SacrificeDonationDelete(int Id)
        {
            SessionKontrol();
            if (_users != null)
            {

                _SacrificeDonationServices.Delete(Id);

                _unitOfWork.SaveChanges();
                return RedirectToAction("SacrificeDonateList", "Donation");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult SacrificeDonatePrice()
        {
            SessionKontrol();
            if (_users != null)
            {
                    var viewModel = _SacrificePriceServices.Get(1);
                    return View(viewModel);            
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }


        public ActionResult SacrificeDonatePriceSave(SacrificePriceViewModel viewModel)
        {
            SessionKontrol();
            if (_users != null)
            { 
                _SacrificePriceServices.Update(viewModel);
                _unitOfWork.SaveChanges();
                return RedirectToAction("SacrificeDonatePrice", "Donation");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult AlmsDonationList()
        {
            SessionKontrol();
            if (_users != null)
            {
                var serviceResult = _AlmsDonationServices.GetAll().OrderByDescending(x => x.CreationDate);

                return View(serviceResult);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult AlmsDonationDetail(int Id)
        {
            SessionKontrol();
            if (_users != null)
            {

                if (Id != null)
                {
                    var viewModel = _AlmsDonationServices.Get(Id);

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

        public ActionResult AlmsDonationDelete(int Id)
        {
            SessionKontrol();
            if (_users != null)
            {

                _AlmsDonationServices.Delete(Id);

                _unitOfWork.SaveChanges();
                return RedirectToAction("AlmsDonationList", "Donation");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }


        public ActionResult FitreDonationList()
        {
            SessionKontrol();
            if (_users != null)
            {
                var serviceResult = _FitreDonationServices.GetAll().OrderByDescending(x => x.CreationDate);

                return View(serviceResult);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult FitreDonationDetail(int Id)
        {
            SessionKontrol();
            if (_users != null)
            {

                if (Id != null)
                {
                    var viewModel = _FitreDonationServices.Get(Id);

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

        public ActionResult FitreDonationDelete(int Id)
        {
            SessionKontrol();
            if (_users != null)
            {

                _FitreDonationServices.Delete(Id);

                _unitOfWork.SaveChanges();
                return RedirectToAction("FitreDonationList", "Donation");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult RansomDonationList()
        {
            SessionKontrol();
            if (_users != null)
            {
                var serviceResult = _RansomDonationServices.GetAll().OrderByDescending(x => x.CreationDate);

                return View(serviceResult);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult RansomDonationDetail(int Id)
        {
            SessionKontrol();
            if (_users != null)
            {

                if (Id != null)
                {
                    var viewModel = _RansomDonationServices.Get(Id);

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
        public ActionResult RansomDonationDelete(int Id)
        {
            SessionKontrol();
            if (_users != null)
            {

                _RansomDonationServices.Delete(Id);

                _unitOfWork.SaveChanges();
                return RedirectToAction("RansomDonationList", "Donation");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult GeneralDonationList()
        {
            SessionKontrol();
            if (_users != null)
            {
                var serviceResult = _GeneralDonationServices.GetAll().OrderByDescending(x => x.CreationDate);

                return View(serviceResult);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult GeneralDonationDetail(int Id)
        {
            SessionKontrol();
            if (_users != null)
            {

                if (Id != null)
                {
                    var viewModel = _GeneralDonationServices.Get(Id);

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

        public ActionResult GeneralDonationDelete(int Id)
        {
            SessionKontrol();
            if (_users != null)
            {

                _GeneralDonationServices.Delete(Id);

                _unitOfWork.SaveChanges();
                return RedirectToAction("GeneralDonationList", "Donation");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult AidToMosquesList()
        {
            SessionKontrol();
            if (_users != null)
            {
                var serviceResult = _AidToMosquesServices.GetAll().OrderByDescending(x => x.CreationDate);

                return View(serviceResult);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult AidToMosquesDetail(int Id)
        {
            SessionKontrol();
            if (_users != null)
            {

                if (Id != null)
                {
                    var viewModel = _AidToMosquesServices.Get(Id);

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

        public ActionResult AidToMosquesDelete(int Id)
        {
            SessionKontrol();
            if (_users != null)
            {

                _AidToMosquesServices.Delete(Id);

                _unitOfWork.SaveChanges();
                return RedirectToAction("AidToMosquesList", "Donation");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}