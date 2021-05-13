using Newtonsoft.Json;
using Strasbourg.DAL.Models;
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
    public class SMSController : BaseController
    {
        private readonly SMSHelpers _SMSHelpers;
        private readonly SMSSettingsServices _SMSSettingsServices;
        private readonly SMSTemplatesServices _SMSTemplatesServices;
        private readonly SMSHistoryServices _SMSHistoryServices;
        private readonly string ViewForm = "Edit";

        public SMSController()
        {
            _SMSHelpers = new SMSHelpers();
            _SMSSettingsServices = new SMSSettingsServices(_unitOfWork);
            _SMSTemplatesServices = new SMSTemplatesServices(_unitOfWork);
            _SMSHistoryServices = new SMSHistoryServices(_unitOfWork);
        }

        public ActionResult Index()
        {
            SessionKontrol();
            if (_users != null)
            {

                var serviceResult = _SMSTemplatesServices.GetAll().OrderByDescending(x => x.CreationDate);

                return View(serviceResult);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }


        public ActionResult SMSSettings()
        {
            SessionKontrol();
            if (_users != null)
            {

                var viewModel = _SMSSettingsServices.Get(1);
                return View(viewModel);

            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }


        public ActionResult Send(string message, string phone)
        {
            SessionKontrol();
            if (_users != null)
            {
                var smssettings = _SMSSettingsServices.Get(1);
                
             //   bool IsItSended = _SMSHelpers.Send2(smssettings.ApiLink,smssettings.Account,smssettings.Login,smssettings.Password,smssettings.From,phone,message);
               string val =  _SMSHelpers.sendSms(smssettings.AppKey, smssettings.Secret, smssettings.ConsumerKey, smssettings.ServiceName ,message,phone);

                SMSRequest smsrqst = JsonConvert.DeserializeObject<SMSRequest>(val);
                string httpcd = smsrqst.httpCode.Substring(0, 3);

                if (httpcd ==  "200")
                {
                    SMSHistoryViewModel smsvm = new SMSHistoryViewModel();
                    smsvm.Phone = phone;
                    smsvm.Message = message;
                    _SMSHistoryServices.Add(smsvm);
                      
                    _unitOfWork.SaveChanges();
                    return RedirectToAction("Index", "SMS");
                }
                else
                {
                    return RedirectToAction("SmsNotSended", "SMS", new { errorCode = smsrqst.errorCode });
                }

             

            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult SMSNotSended(string errorCode)
        {
            if (errorCode == "INVALID_KEY")
            {
                ViewBag.error = "App Key hatalı olduğu için SMS gönderilemedi.";
                return View();
            }
            else if (errorCode == "INVALID_SIGNATURE")
            {
                ViewBag.error = "App Secret hatalı olduğu için SMS gönderilemedi.";
                return View();
            }
            else if (errorCode == "NOT_CREDENTIAL")
            {
                ViewBag.error = "Kimlik bilgisi hatalı olduğu için SMS gönderilemedi.";
                return View();
            }

            return View();
        }
 
        public ActionResult SMSSettingsSave(SMSSettingsViewModel viewModel)
        {
            SessionKontrol();
            if (_users != null)
            {
                _SMSSettingsServices.Update(viewModel);
                _unitOfWork.SaveChanges();
                return RedirectToAction("SMSSettings", "SMS");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult SMSTemplateList()
        {
            SessionKontrol();
            if (_users != null)
            {

                var serviceResult = _SMSTemplatesServices.GetAll().OrderByDescending(x => x.CreationDate);

                return View(serviceResult);

            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult SMSTemplateDetail(int? Id)
        {
            SessionKontrol();
            if (_users != null)
            {

                if (Id != null)
                {
                    var viewModel = _SMSTemplatesServices.Get(Id);

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


        public ActionResult SMSTemplateSave(SMSTemplatesViewModel viewModel)
        {
            SessionKontrol();
            if (_users != null)
            {

                try
                {

                    var isValid = Validate(viewModel, new SMSTemplatesValidator(), ModelState);
                    if (isValid)
                    {
                        viewModel.Status = true;
                        if (viewModel.Id == 0)
                        {
                            _SMSTemplatesServices.Add(viewModel);
                        }
                        else
                        {
                            _SMSTemplatesServices.Update(viewModel);
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
                return RedirectToAction("SMSTemplateList", "SMS");
            }
            else
            {

                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult SMSTemplateDelete(int Id)
        {
            SessionKontrol();
            if (_users != null)
            {

                _SMSTemplatesServices.Delete(Id);
                _unitOfWork.SaveChanges();
                return RedirectToAction("SMSTemplateList", "SMS");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }


        public ActionResult SMSHistoryList()
        {
            SessionKontrol();
            if (_users != null)
            {

                var serviceResult = _SMSHistoryServices.GetAll().OrderByDescending(x => x.CreationDate);

                return View(serviceResult);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }



        public ActionResult SMSHistoryDetail(int? Id)
        {
            SessionKontrol();
            if (_users != null)
            {

                if (Id != null)
                {
                    var viewModel = _SMSHistoryServices.Get(Id);


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

        public ActionResult SMSHistoryDelete(int Id)
        {
            SessionKontrol();
            if (_users != null)
            {

                _SMSHistoryServices.Delete(Id);

                _unitOfWork.SaveChanges();
                return RedirectToAction("SMSHistoryList", "SMS");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

      
     

    }
}