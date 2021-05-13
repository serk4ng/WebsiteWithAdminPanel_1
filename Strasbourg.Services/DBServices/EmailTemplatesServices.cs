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
    public class EmailTemplatesServices : BaseServices
    {
        private readonly STRepository<EmailTemplates> _repository;
        public EmailTemplatesServices(STUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new STRepository<EmailTemplates>(unitOfWork);
        }


        public void Add(EmailTemplatesViewModel viewModel)
        {
            _repository.Add(new EmailTemplates
            {
                CreationDate = DateTime.Now,
                IsItDeleted = false,
                Status = true,
                SiteLanguage =viewModel.SiteLanguage,

                Subject = viewModel.Subject,
                Message = viewModel.Message

            });
        }



        public EmailTemplatesViewModel Get(int? Id)
        {
            var emailtemplates = _repository.Get(x => x.Id == Id);

            return new EmailTemplatesViewModel
            {
                CreationDate = emailtemplates.CreationDate,
                Status = emailtemplates.Status,
                IsItDeleted = emailtemplates.IsItDeleted,
                DateOfUpdate = emailtemplates.DateOfUpdate,
                Id = emailtemplates.Id,
                SiteLanguage = emailtemplates.SiteLanguage,

                 Subject = emailtemplates.Subject,
                  Message = emailtemplates.Message
            };
        }


        public void Delete(int id)
        {
            _repository.Delete(x => x.Id == id);
        }


        public IQueryable<EmailTemplatesViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new EmailTemplatesViewModel
                {
                    Id = x.Id,
                    Status = x.Status,
                    DateOfUpdate = x.DateOfUpdate,
                    CreationDate = x.CreationDate,
                    IsItDeleted = x.IsItDeleted,
                    SiteLanguage = x.SiteLanguage,

                    Subject = x.Subject,
                    Message =x.Message
                });
        }


        public void Update(EmailTemplatesViewModel viewModel)
        {
            var emailtemplates = _repository.Get(x => x.Id == viewModel.Id);

            emailtemplates.Status = viewModel.Status;
            emailtemplates.DateOfUpdate = DateTime.Now;
            emailtemplates.IsItDeleted = viewModel.IsItDeleted;
            emailtemplates.SiteLanguage = viewModel.SiteLanguage;

            emailtemplates.Subject = viewModel.Subject;
            emailtemplates.Message = viewModel.Message;
            _repository.Update(emailtemplates);
        }

    }
}
