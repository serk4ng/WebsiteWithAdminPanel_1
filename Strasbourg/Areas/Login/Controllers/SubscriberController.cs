using Strasbourg.Services.DBServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Strasbourg.UI.Areas.Login.Controllers
{
    public class SubscriberController : BaseController
    {
        private readonly SubscriberServices _SubscriberServices;

        public SubscriberController()
        {
            _SubscriberServices = new SubscriberServices(_unitOfWork);
 
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SubscriberList()
        {
            SessionKontrol();
            if (_users != null)
            {
                var serviceResult = _SubscriberServices.GetAll().OrderByDescending(x => x.CreationDate);

                return View(serviceResult);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }


        public ActionResult SubscriberDelete(int Id)
        {
            SessionKontrol();
            if (_users != null)
            {

                _SubscriberServices.Delete(Id);
                _unitOfWork.SaveChanges();
                return RedirectToAction("SubscriberList", "Subscriber");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

    }
}