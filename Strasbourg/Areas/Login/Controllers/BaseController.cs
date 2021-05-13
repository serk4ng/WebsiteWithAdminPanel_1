using FluentValidation;
using Strasbourg.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentValidation.Results;
using Strasbourg.Domain.ViewModels;
using System.Globalization;

namespace Strasbourg.UI.Areas.Login.Controllers
{
    public class BaseController : Controller
    {
        public readonly STUnitOfWork _unitOfWork;
        public UsersViewModel _users;

        public  BaseController()
        {
            _unitOfWork = new STUnitOfWork();
        }

        public UsersViewModel SessionKontrol()
        {
            _users = (UsersViewModel)Session["user"];
            return _users;
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

 

    }
}