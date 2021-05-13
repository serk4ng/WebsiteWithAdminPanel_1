using Strasbourg.Domain.Validations;
using Strasbourg.Domain.ViewModels;
using Strasbourg.Services.DBServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Strasbourg.UI.Controllers
{
    public class ContactController : BaseController
    {
        // GET: Contact
        private readonly SisterOrganizationServices _SisterOrganizationServices;
        private readonly RelatedOrganizationServices _RelatedOrganizationServices;
        private readonly AssociationServices _AssociationServices;
        private readonly ContactRequestsServices _ContactRequestsServices;


        private BaseViewModel basevm;
        private readonly string ViewForm = "Edit";
        public IQueryable<RelatedOrganizationViewModel> serviceResult;
        public ContactController()
        {
            _SisterOrganizationServices = new SisterOrganizationServices(_unitOfWork);
            _RelatedOrganizationServices = new RelatedOrganizationServices(_unitOfWork);
            _AssociationServices = new AssociationServices(_unitOfWork);
            _ContactRequestsServices = new ContactRequestsServices(_unitOfWork);
        


        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ContactRequestSave(ContactRequestsViewModel viewModel)
        {

            try
            {
                var isValid = Validate(viewModel, new ContactRequestsValidator(), ModelState);
                if (isValid)
                {

                    viewModel.Status = true;
                    _ContactRequestsServices.Add(viewModel);

                }
                else
                {
                    return RedirectToAction("Contact", "Contact");
                }
            }
            catch (Exception)
            {
                return View(ViewForm, viewModel);
            }
            _unitOfWork.SaveChanges();
            return RedirectToAction("Contact", "Contact");


        }
    public ActionResult Contact()
        {
        return View();

    }
    
      
        public ActionResult OurAssociations()
        {
            var serviceResult = _AssociationServices.GetAll().OrderBy(x => x.Count);
            return View(new Tuple<IQueryable<AssociationViewModel>, BaseViewModel>(serviceResult, basevm));
        }
        public ActionResult SisterOrganizations()
        {

            var serviceResult = _SisterOrganizationServices.GetAll();

            return View(serviceResult);

        }
        public ActionResult RelatedOrganizations()
        {
          
            if (Session["selectedlang"].ToString() == "1")
	        {
                serviceResult = _RelatedOrganizationServices.GetAllTR();
            }
            else
            {
               serviceResult = _RelatedOrganizationServices.GetAllFR();
            }
          

            return View(new Tuple<IQueryable<RelatedOrganizationViewModel>, BaseViewModel>(serviceResult, basevm));
        }

    }
 
}