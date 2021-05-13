using Strasbourg.Services.DBServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Strasbourg.UI.Controllers
{

    public class CorporateController : BaseController
    {

        private readonly BoardServices _BoardServices;

        public CorporateController()
        {
            _BoardServices = new BoardServices(_unitOfWork);
        }
        // GET: Corporate
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult OurGoals()
        {
            return View();
        }
        public ActionResult OurPrinciples()
        {
            return View();
        }
        public ActionResult OrgStructure()
        {
            return View();
        }
        public ActionResult BoardOfDirectors()

        {
            var serviceResult = _BoardServices.GetAllDirector().OrderBy(x=>x.Count);
            return View(serviceResult);
        }
        public ActionResult BoardOfAuditors()
        {
            var serviceResult = _BoardServices.GetAllAuditor().OrderBy(x => x.Count);
            return View(serviceResult);
        }
    }
}