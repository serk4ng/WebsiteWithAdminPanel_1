using System;
using System.Web.Mvc;
using Strasbourg.Domain.ViewModels;
using Strasbourg.Services.DBServices;
using System.Linq;

namespace Strasbourg.UI.Areas.Login.Controllers
{
    public class HomeController : BaseController
    {
        public UsersViewModel _users;
        private readonly GeneralDonationServices _GeneralDonationServices;
        private readonly FitreDonationServices _FitreDonationServices;
        private readonly RansomDonationServices _RansomDonationServices;
        private readonly AlmsDonationServices _AlmsDonationServices;
        private readonly SacrificeDonationServices _SacrificeDonationServices;
        private readonly AidToMosquesServices _AidToMosquesServices;
        public HomeController()
        {
            _GeneralDonationServices = new GeneralDonationServices(_unitOfWork);
            _FitreDonationServices = new FitreDonationServices(_unitOfWork);
            _RansomDonationServices = new RansomDonationServices(_unitOfWork);
            _AlmsDonationServices = new AlmsDonationServices(_unitOfWork);
            _SacrificeDonationServices = new SacrificeDonationServices(_unitOfWork);
            _AidToMosquesServices = new AidToMosquesServices(_unitOfWork);

 
        }
        public ActionResult Index()
        {
           SessionKontrol();
            if (_users != null)
            {
                var serviceResult = _GeneralDonationServices.GetAllDonations().OrderBy(x=>x.CreationDate).Skip(Math.Max(0, _GeneralDonationServices.GetAllDonations().Count() - 5));
                ViewBag.generalcount = _GeneralDonationServices.GetAll().Count();
                ViewBag.fitrecount = _FitreDonationServices.GetAll().Count();
                ViewBag.almscount = _AlmsDonationServices.GetAll().Count();
                ViewBag.sacrificecount = _SacrificeDonationServices.GetAll().Count();
                ViewBag.aidtomosquecount = _AidToMosquesServices.GetAll().Count();
                ViewBag.ransomcount = _RansomDonationServices.GetAll().Count();

                ViewBag.alldonatecount = _GeneralDonationServices.GetAllDonations().Count();
                return View(serviceResult);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public void SessionKontrol()
        {
            _users = (UsersViewModel)Session["user"];
            
        }
    }
}