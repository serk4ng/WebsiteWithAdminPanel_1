using Strasbourg.DAL.Models;
using Strasbourg.DAL.Repository;
using Strasbourg.DAL.UnitOfWork;
using Strasbourg.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.Services.DBServices
{
    public class SMSSettingsServices : BaseServices
    {
        private readonly STRepository<SMSSettings> _repository;

        public SMSSettingsServices(STUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new STRepository<SMSSettings>(unitOfWork);
        }



        public void Add(SMSSettingsViewModel viewModel)
        {
            _repository.Add(new SMSSettings
            {
                CreationDate = DateTime.Now,
                IsItDeleted = false,
                Status = true,

                 AppKey = viewModel.AppKey,
                 Secret = viewModel.Secret,
                 ConsumerKey = viewModel.ConsumerKey,
                 ServiceName = viewModel.ServiceName

            });
        }

        public SMSSettingsViewModel Get(int? Id)
        {
            var smssettings = _repository.Get(x => x.Id == Id);

            return new SMSSettingsViewModel
            {
                CreationDate = smssettings.CreationDate,
                Status = smssettings.Status,
                IsItDeleted = smssettings.IsItDeleted,
                DateOfUpdate = smssettings.DateOfUpdate,
                Id = smssettings.Id,

                AppKey = smssettings.AppKey,
                Secret = smssettings.Secret,
                ConsumerKey = smssettings.ConsumerKey,
                ServiceName = smssettings.ServiceName
            };
        }


        public void Delete(int id)
        {
            _repository.Delete(x => x.Id == id);
        }


        public void Update(SMSSettingsViewModel viewModel)
        {
            var smssettings = _repository.Get(x => x.Id == viewModel.Id);

            smssettings.Status = viewModel.Status;
            smssettings.DateOfUpdate = DateTime.Now;
            smssettings.IsItDeleted = viewModel.IsItDeleted;


            smssettings.Secret = viewModel.Secret;
            smssettings.AppKey = viewModel.AppKey;
            smssettings.ConsumerKey = viewModel.ConsumerKey;
            smssettings.ServiceName = viewModel.ServiceName;
 
 
            _repository.Update(smssettings);
        }
    }
}
