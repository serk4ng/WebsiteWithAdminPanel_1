using Strasbourg.Domain.Helpers;
using Strasbourg.Domain.Validations;
using Strasbourg.Domain.ViewModels;
using Strasbourg.Services.DBServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Strasbourg.UI.Areas.Login.Controllers
{
    public class EmailController : BaseController
    {
        private readonly MailHelpers _MailHelper;
        private readonly EmailSettingsServices _EmailSettingsServices;
        private readonly EmailTemplatesServices _EmailTemplatesServices;
        private readonly EmailHistoryServices _EmailHistoryServices;
        private readonly string ViewForm = "Edit";
        public EmailController()
        {

            _MailHelper = new MailHelpers();
            _EmailSettingsServices = new EmailSettingsServices(_unitOfWork);
            _EmailTemplatesServices = new EmailTemplatesServices(_unitOfWork);
            _EmailHistoryServices = new EmailHistoryServices(_unitOfWork);
        }

        public ActionResult Index()
        {
            SessionKontrol();
            if (_users != null)
            {

                var serviceResult = _EmailTemplatesServices.GetAll().OrderByDescending(x => x.CreationDate);

                return View(serviceResult);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult EmailSettings()
        {
            SessionKontrol();
            if (_users != null)
            {


                var viewModel = _EmailSettingsServices.Get(1);

                return View(viewModel);

            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }


        public ActionResult Send(string receivermail, string subject, string message, string cCMail)
        {
            SessionKontrol();
            if (_users != null)
            {
                var emailsettings = _EmailSettingsServices.Get(1);

               bool isItSended =  _MailHelper.Send(receivermail, subject, message, cCMail, emailsettings.Username, emailsettings.Password, emailsettings.Host, emailsettings.Port, emailsettings.Mail);

                if (isItSended)
                {
                    EmailHistoryViewModel ehvm = new EmailHistoryViewModel();
                    ehvm.ReceiverMail = receivermail;
                    ehvm.Subject = subject;
                    ehvm.Message = message;

                    _EmailHistoryServices.Add(ehvm);
                    _unitOfWork.SaveChanges();
                }
                

                return RedirectToAction("Index", "Email");

            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult EmailSettingsSave(EmailSettingsViewModel viewModel)
        {
            SessionKontrol();
            if (_users != null)
            {
                _EmailSettingsServices.Update(viewModel);
                _unitOfWork.SaveChanges();
                return RedirectToAction("EmailSettings", "Email");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }



        public ActionResult EmailTemplateList()
        {
            SessionKontrol();
            if (_users != null)
            {

                var serviceResult = _EmailTemplatesServices.GetAll().OrderByDescending(x => x.CreationDate);

                return View(serviceResult);

            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult EmailTemplateDetail(int? Id)
        {
            SessionKontrol();
            if (_users != null)
            {

                if (Id != null)
                {
                    var viewModel = _EmailTemplatesServices.Get(Id);

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


        public ActionResult EmailTemplateSave(EmailTemplatesViewModel viewModel)
        {
            SessionKontrol();
            if (_users != null)
            {

                try
                {

                    var isValid = Validate(viewModel, new EmailTemplatesValidator(), ModelState);
                    if (isValid)
                    {
                        viewModel.Status = true;
                        if (viewModel.Id == 0)
                        {
                            _EmailTemplatesServices.Add(viewModel);
                        }
                        else
                        {
                            _EmailTemplatesServices.Update(viewModel);
                        }
                    }
                    else
                    {
                        return View(ViewForm, viewModel);
                    }
                }
                catch (Exception)
                {
                    return View(ViewForm, viewModel);
                }
                _unitOfWork.SaveChanges();
                return RedirectToAction("EmailTemplateList", "Email");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult EmailTemplateDelete(int Id)
        {
            SessionKontrol();
            if (_users != null)
            {

                _EmailTemplatesServices.Delete(Id);

                _unitOfWork.SaveChanges();
                return RedirectToAction("EmailTemplateList", "Email");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }


        public ActionResult EmailHistoryList()
        {
            SessionKontrol();
            if (_users != null)
            {

                var serviceResult = _EmailHistoryServices.GetAll().OrderByDescending(x => x.CreationDate);
                
                return View(serviceResult);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult EmailHistoryDetail(int? Id)
        {
            SessionKontrol();
            if (_users != null)
            {

                if (Id != null)
                {
                    var viewModel = _EmailHistoryServices.Get(Id);
           
 
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


        public ActionResult EmailHistoryDelete(int Id)
        {
            SessionKontrol();
            if (_users != null)
            {

                _EmailHistoryServices.Delete(Id);

                _unitOfWork.SaveChanges();
                return RedirectToAction("EmailHistoryList", "Email");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

    }
}

