using FluentValidation;
using Strasbourg.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.Domain.Validations
{

    public class BaseValidator<TValidate>
     : AbstractValidator<TValidate> where TValidate
     : BaseViewModel
    {

    }

}
