using Strasbourg.Services.DBServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Strasbourg.UI.Areas.Login.Controllers
{
    public class ContactRequestController : BaseController
    {
        private readonly ContactRequestsServices _ContactRequestsServices;
        private readonly string ViewForm = "Edit";

        public ContactRequestController()
        {
            _ContactRequestsServices = new ContactRequestsServices(_unitOfWork);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ContactRequestList()
        {
            SessionKontrol();
            if (_users != null)
            {
                var serviceResult = _ContactRequestsServices.GetAll().OrderByDescending(x=>x.CreationDate).OrderByDescending(x=>x.CreationDate);

                return View(serviceResult);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult ContactRequestDelete(int Id)
        {
            SessionKontrol();
            if (_users != null)
            {

                _ContactRequestsServices.Delete(Id);

                _unitOfWork.SaveChanges();
                return RedirectToAction("ContactRequestList", "ContactRequest");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult ContactRequestDetail(int Id)
        {
            SessionKontrol();
            if (_users != null)
            {
 
                if (Id != null)
                {
                    var viewModel = _ContactRequestsServices.Get(Id);
 
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