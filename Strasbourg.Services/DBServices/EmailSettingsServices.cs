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
    public class EmailSettingsServices : BaseServices
    {
        private readonly STRepository<EmailSettings> _repository;
        public EmailSettingsServices(STUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new STRepository<EmailSettings>(unitOfWork);
        }

        public void Add(EmailSettingsViewModel viewModel)
        {
            _repository.Add(new EmailSettings
            {
                CreationDate = DateTime.Now,
                IsItDeleted = false,
                Status = true,

                Username = viewModel.Username,
                Password = viewModel.Password,
                Host = viewModel.Host,
                Port = viewModel.Port,
                Mail = viewModel.Mail

            });
        }


        public EmailSettingsViewModel Get(int? Id)
        {
            var emailsettings = _repository.Get(x => x.Id == Id);

            return new EmailSettingsViewModel
            {
                CreationDate = emailsettings.CreationDate,
                Status = emailsettings.Status,
                IsItDeleted = emailsettings.IsItDeleted,
                DateOfUpdate = emailsettings.DateOfUpdate,
                Id = emailsettings.Id,


                Username = emailsettings.Username,
                Password = emailsettings.Password,
                Host = emailsettings.Host,
                Port = emailsettings.Port,
                Mail = emailsettings.Mail
            };
        }


        public void Delete(int id)
        {
            _repository.Delete(x => x.Id == id);
        }



        public void Update(EmailSettingsViewModel viewModel)
        {
            var emailsettings = _repository.Get(x => x.Id == viewModel.Id);

            emailsettings.Status = viewModel.Status;
            emailsettings.DateOfUpdate = DateTime.Now;
            emailsettings.IsItDeleted = viewModel.IsItDeleted;


            emailsettings.Username = viewModel.Username;
            emailsettings.Password = viewModel.Password;
            emailsettings.Host = viewModel.Host;
            emailsettings.Port = viewModel.Port;
            emailsettings.Mail = viewModel.Mail;

            _repository.Update(emailsettings);
        }

    }
}
