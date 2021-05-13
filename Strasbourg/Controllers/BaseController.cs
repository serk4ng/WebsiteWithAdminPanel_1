using FluentValidation;
using Strasbourg.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentValidation.Results;
using Strasbourg.Domain.Enums;
using System.Web.Routing;
using Strasbourg.Services.DBServices;

namespace Strasbourg.UI.Controllers
{

    public class BaseController : Controller
    {
        public readonly STUnitOfWork _unitOfWork;
        public static int counter = 0;
 
        private readonly SiteSettingsServices _siteSettingsServices;
        public BaseController()
        {
            _unitOfWork = new STUnitOfWork();
            _siteSettingsServices = new SiteSettingsServices(_unitOfWork);
      
          
        }

        protected override void Initialize(RequestContext requestContext)
        {
            
            base.Initialize(requestContext);
            if (counter == 0)
            {
                Session["selectedlang"] = "1";
                counter++;
            }

            if (Session["selectedlang"].ToString() == "1")
            {
                ViewBag.siteSettings = _siteSettingsServices.Get(2);
            }
            else
            {
                ViewBag.siteSettings = _siteSettingsServices.Get(14);
            }

        }
        public bool Validate<TModel, TValidator>(TModel model, TValidator validator, ModelStateDictionary modelState)
        where TValidator : AbstractValidator<TModel>
        {
            FluentValidation.Results.ValidationResult result = validator.Validate(model);

            foreach (var error in result.Errors)
            {
                modelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }

            return result.IsValid;
        }

        public ActionResult Language(int lang)
        {
            Session["selectedlang"] = lang;
            return RedirectToAction("Index","Strasbourg");
        }
         
 

    }
}