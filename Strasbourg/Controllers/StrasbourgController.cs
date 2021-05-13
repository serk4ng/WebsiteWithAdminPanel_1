using Strasbourg.Domain.ViewModels;
using Strasbourg.Services.DBServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Strasbourg.UI.Controllers
{
    public class StrasbourgController : BaseController
    {
        private readonly NewsServices _NewsServices;
        private readonly SermonServices _SermonServices;
        private readonly VideoServices _VideoServices;
        private BaseViewModel basevm;
        private readonly string ViewForm = "Edit";
        public IQueryable<NewsViewModel> serviceResultNews;
        public IQueryable<SermonViewModel> serviceResultSermon;
        public IQueryable<VideoViewModel> serviceResultVideo;
        public StrasbourgController()
        {
            _NewsServices = new NewsServices(_unitOfWork);
            _SermonServices = new SermonServices(_unitOfWork);
            _VideoServices = new VideoServices(_unitOfWork);
        }
        public ActionResult Index()
        {
            if (Session["selectedlang"].ToString() == "1")
            {
                serviceResultNews = _NewsServices.GetAllTR().OrderByDescending(x=>x.CreationDate).Skip(Math.Max(0, _NewsServices.GetAllTR().Count() - 4));
                serviceResultSermon = _SermonServices.GetAllTR().OrderByDescending(x => x.CreationDate).Skip(Math.Max(0, _SermonServices.GetAllTR().Count() - 4));
                serviceResultVideo = _VideoServices.GetAllTR().OrderByDescending(x => x.CreationDate).Skip(Math.Max(0, _VideoServices.GetAllTR().Count() - 5));

                ViewBag.LastVideo = _VideoServices.GetAllTR().OrderByDescending(x => x.CreationDate).ToList().FirstOrDefault() ;

                
            }
            else
            {
                serviceResultNews = _NewsServices.GetAllFR().OrderByDescending(x => x.CreationDate).Skip(Math.Max(0, _NewsServices.GetAllTR().Count() - 4));
                serviceResultSermon = _SermonServices.GetAllFR().OrderByDescending(x => x.CreationDate).Skip(Math.Max(0, _SermonServices.GetAllTR().Count() - 4));
                serviceResultVideo = _VideoServices.GetAllFR().OrderByDescending(x => x.CreationDate).Skip(Math.Max(0, _VideoServices.GetAllTR().Count() - 5));
                ViewBag.LastVideo = _VideoServices.GetAllFR().OrderByDescending(x => x.CreationDate).ToList().FirstOrDefault();
            }
            return View(new Tuple<IQueryable<NewsViewModel>,IQueryable<SermonViewModel>, IQueryable<VideoViewModel>, BaseViewModel >(serviceResultNews,serviceResultSermon, serviceResultVideo, basevm));
        }

        public ActionResult WhatIsFF()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult NeedToKnowFF()
        {
            return View();
        }
        public ActionResult PurposeFF()
        {
            return View();
        }

        public ActionResult ServicesFF()
        {
            return View();
        }
        
        public ActionResult MembershipDirectiveFF()
        {
            return View();
        }
        public ActionResult InCaseOfDeathFF()
        {
            return View();
        }

        public ActionResult NewsDetail(int id)
        {
           var serviceResult = _NewsServices.Get(id);
           
            return View(serviceResult);
        }
    }
}