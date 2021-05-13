using Newtonsoft.Json;
using Strasbourg.DAL.Models;
using Strasbourg.Domain.Validations;
using Strasbourg.Domain.ViewModels;
using Strasbourg.Services.DBServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Strasbourg.UI.Controllers
{
    public class DonateController : BaseController
    {
        private readonly GeneralDonationServices _GeneralDonationServices;
        private readonly FitreDonationServices _FitreDonationServices;
        private readonly RansomDonationServices _RansomDonationServices;
        private readonly AlmsDonationServices _AlmsDonationServices;
        private readonly AidToMosquesServices _AidToMosquesServices;
        private readonly SacrificeDonationServices _SacrificeDonationServices;
        private readonly SacrificePriceServices _SacrificePriceServices;


        private BaseViewModel basevm;
        private readonly string ViewForm = "Edit";

        public DonateController()
        {
            _GeneralDonationServices = new GeneralDonationServices(_unitOfWork);
            _FitreDonationServices = new FitreDonationServices(_unitOfWork);
            _RansomDonationServices = new RansomDonationServices(_unitOfWork);
            _SacrificeDonationServices = new SacrificeDonationServices(_unitOfWork);
            _SacrificePriceServices = new SacrificePriceServices(_unitOfWork);
            _AlmsDonationServices = new AlmsDonationServices(_unitOfWork);
            _AidToMosquesServices = new AidToMosquesServices(_unitOfWork);
        }
        public ActionResult Index()
        {
            return View();
        }
  
        public ActionResult SacrificeDonation()
        {
            var serviceResult = _SacrificePriceServices.Get(1);
            return View(new Tuple<SacrificePriceViewModel, BaseViewModel>(serviceResult, basevm));
        }
        public ActionResult AlmsDonation()
        {
            return View();
        }
        public ActionResult FitreDonation()
        {
            return View();
        }
        public ActionResult RansomDonation()
        {
            return View();
        }
        public ActionResult GeneralDonation()
        {
            return View();
        }
        public ActionResult AidToMosques()
        {
            return View();
        }


        public ActionResult GeneralDonationPost(GeneralDonationViewModel viewModel, Monetico m)
        {
            try
            {
                var isValid = Validate(viewModel, new GeneralDonationValidator(), ModelState);
                if (isValid)
                {

                    JsonResult json  = Json(new JavaScriptSerializer().Serialize(viewModel));
                    viewModel.Status = true;
                    ViewBag.name = viewModel.Name;
                    Session.Add("generaldonationjson", json.Data);
                    Session.Add("generaldonationname", viewModel.Name);
                    Session.Add("generaldonationsurname", viewModel.Surname);
                    Session.Add("generaldonationemail", viewModel.Email);
                    Session.Add("generaldonationadress", viewModel.Adress);
                    Session.Add("generaldonationcity", viewModel.City);
                    Session.Add("generaldonationphonenumber", viewModel.PhoneNumber);
                    Session.Add("generaldonationzipcode", viewModel.ZipCode);
                    Session.Add("generaldonationdescription", viewModel.Description);
                    Session.Add("generaldonationdonateamount", viewModel.DonationAmount);
                    //https://p.monetico-services.com/paiement.cgi?version="+m.Version+"&TPE="+m.TPE+"&date="+DateTime.Now+"&montant="+viewModel.DonationAmount+"EUR&reference="+m.Reference+"&MAC="+m.MAC+"&url_retour_ok="+m.Url_Retour_Ok + "&url_retour_err=" + m.Url_Retour_Err+"&lgue="+m.Lgue+"&societe="+m.Societe+"&contexte_commande="+m.Contexte_Commande+"&text-libre="+m.Text_Libre+"&mail="+viewModel.Email
                    return Redirect("https://p.monetico-services.com/paiement.cgi?version="+m.Version+"&TPE="+m.TPE+"&date="+DateTime.Now+"&montant="+viewModel.DonationAmount+"EUR&reference="+m.Reference+"&MAC="+m.MAC+ "&lgue="+m.Lgue+"&societe="+m.Societe+"&contexte_commande="+m.Contexte_Commande+"&mail="+viewModel.Email);
                }
                else
                {
                    return RedirectToAction("GeneralDonation", "Donate");
                }
            }
            catch (Exception)
            {
                return View(ViewForm, viewModel);
            }

        }

        public ActionResult FitreDonationPost(FitreDonationViewModel viewModel)
        {
            try
            {
                var isValid = Validate(viewModel, new FitreDonationValidator(), ModelState);
                if (isValid)
                {
                    JsonResult json = Json(new JavaScriptSerializer().Serialize(viewModel));
                    viewModel.Status = true;
                    ViewBag.name = viewModel.Name;
                    Session.Add("fitredonationjson", json.Data);
                    Session.Add("fitredonationname", viewModel.Name);
                    Session.Add("fitredonationsurname", viewModel.Surname);
                    Session.Add("fitredonationemail", viewModel.Email);
                    Session.Add("fitredonationadress", viewModel.Adress);
                    Session.Add("fitredonationcity", viewModel.City);
                    Session.Add("fitredonationphonenumber", viewModel.PhoneNumber);
                    Session.Add("fitredonationzipcode", viewModel.ZipCode);
                    Session.Add("fitredonationadditionalinfo", viewModel.AdditionalInfo);
                    Session.Add("fitredonationfitreamount", viewModel.FitreAmount);


                }
                else
                {
                    return RedirectToAction("FitreDonation", "Donate");
                }
            }
            catch (Exception)
            {
                return View(ViewForm, viewModel);
            }
            return RedirectToAction("FitreDonation", "Donate");

        }

        public ActionResult RansomDonationPost(RansomDonationViewModel viewModel)
        {
            try
            {
                var isValid = Validate(viewModel, new RansomDonationValidator(), ModelState);
                if (isValid)
                {
                    JsonResult json = Json(new JavaScriptSerializer().Serialize(viewModel));
                    viewModel.Status = true;
                    ViewBag.name = viewModel.Name;
                    Session.Add("ransomdonationjson", json.Data);
                    Session.Add("ransomdonationname", viewModel.Name);
                    Session.Add("ransomdonationsurname", viewModel.Surname);
                    Session.Add("ransomdonationemail", viewModel.Email);
                    Session.Add("ransomdonationadress", viewModel.Adress);
                    Session.Add("ransomdonationcity", viewModel.City);
                    Session.Add("ransomdonationphonenumber", viewModel.PhoneNumber);
                    Session.Add("ransomdonationzipcode", viewModel.ZipCode);
                    Session.Add("ransomdonationadditionalinfo", viewModel.AdditionalInfo);
                    Session.Add("ransomdonationransomamount", viewModel.RansomAmount);
      

                }
                else
                {
                    return RedirectToAction("RansomDonation", "Donate");
                }
            }
            catch (Exception)
            {
                return View(ViewForm, viewModel);
            }
            return RedirectToAction("RansomDonation", "Donate");

        }

        public ActionResult AlmsDonationPost(AlmsDonationViewModel viewModel)
        {
            try
            {
                var isValid = Validate(viewModel, new AlmsDonationValidator(), ModelState);
                if (isValid)
                {
                    JsonResult json = Json(new JavaScriptSerializer().Serialize(viewModel));
                    viewModel.Status = true;
                    ViewBag.name = viewModel.Name;
                    Session.Add("almsdonationjson", json.Data);
                    Session.Add("almsdonationname", viewModel.Name);
                    Session.Add("almsdonationsurname", viewModel.Surname);
                    Session.Add("almsdonationemail", viewModel.Email);
                    Session.Add("almsdonationadress", viewModel.Adress);
                    Session.Add("almsdonationcity", viewModel.City);
                    Session.Add("almsdonationphonenumber", viewModel.PhoneNumber);
                    Session.Add("almsdonationzipcode", viewModel.ZipCode);
                    Session.Add("almsdonationadditionalinfo", viewModel.AdditionalInfo);
                    Session.Add("almsdonationalmsamount", viewModel.AlmsAmount);


                }
                else
                {
                    return RedirectToAction("AlmsDonation", "Donate");
                }
            }
            catch (Exception)
            {
                return View(ViewForm, viewModel);
            }
            return RedirectToAction("AlmsDonation", "Donate");

        }

        public ActionResult SacrificeDonationPost(SacrificeDonationViewModel viewModel)
        {
            try
            {
                var isValid = Validate(viewModel, new SacrificeDonationValidator(), ModelState);
                if (isValid)
                {
                    JsonResult json = Json(new JavaScriptSerializer().Serialize(viewModel));
                    viewModel.Status = true;
                    ViewBag.name = viewModel.Name;
                    Session.Add("sacrificedonationjson", json.Data);
                    Session.Add("sacrificedonationname", viewModel.Name);
                    Session.Add("sacrificedonationsurname", viewModel.Surname);
                    Session.Add("sacrificedonationemail", viewModel.Email);
                    Session.Add("sacrificedonationadress", viewModel.Adress);
                    Session.Add("sacrificedonationcity", viewModel.City);
                    Session.Add("sacrificedonationphonenumber", viewModel.PhoneNumber);
                    Session.Add("sacrificedonationzipcode", viewModel.ZipCode);
                    Session.Add("sacrificedonationother", viewModel.Other);
                    Session.Add("sacrificedonationsacrificecount", viewModel.SacrificeCount);
                    Session.Add("sacrificedonationsacrificetype", viewModel.SacrificeType);
                    Session.Add("sacrificedonationsacrificetotal", viewModel.Total);
                }
                else
                {
                    return RedirectToAction("SacrificeDonation", "Donate");
                }
            }
            catch (Exception)
            {
                return View(ViewForm, viewModel);
            }
            return RedirectToAction("SacrificeDonation", "Donate");

        }

        public ActionResult AidToMosquesPost(AidToMosquesViewModel viewModel)
        {
            try
            {
                var isValid = Validate(viewModel, new AidToMosquesValidator(), ModelState);
                if (isValid)
                {
                    JsonResult json = Json(new JavaScriptSerializer().Serialize(viewModel));
                    viewModel.Status = true;
                    ViewBag.name = viewModel.Name;
                    Session.Add("aidtomosquesjson", json.Data);
                    Session.Add("aidtomosquesname", viewModel.Name);
                    Session.Add("aidtomosquessurname", viewModel.Surname);
                    Session.Add("aidtomosquesemail", viewModel.Email);
                    Session.Add("aidtomosquesadress", viewModel.Adress);
                    Session.Add("aidtomosquescity", viewModel.City);
                    Session.Add("aidtomosquesphonenumber", viewModel.PhoneNumber);
                    Session.Add("aidtomosqueszipcode", viewModel.ZipCode);
                    Session.Add("aidtomosquesdonationamount", viewModel.DonationAmount);
                    Session.Add("aidtomosquesdescription", viewModel.Description);
                }
                else
                {
                    return RedirectToAction("AidToMosques", "Donate");
                }
            }
            catch (Exception)
            {
                return View(ViewForm, viewModel);
            }
            return RedirectToAction("AidToMosques", "Donate");

        }

        public void StripeConnection()
        {
            
        }
    }
}