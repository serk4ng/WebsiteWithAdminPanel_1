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
    public class SMSTemplatesServices : BaseServices
    {
        private readonly STRepository<SMSTemplates> _repository;

        public SMSTemplatesServices(STUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new STRepository<SMSTemplates>(unitOfWork);
        }

        public void Add(SMSTemplatesViewModel viewModel)
        {
            _repository.Add(new SMSTemplates
            {
                CreationDate = DateTime.Now,
                IsItDeleted = false,
                Status = true,
                SiteLanguage = viewModel.SiteLanguage,

                Subject = viewModel.Subject,
                Message = viewModel.Message

            });
        }


        public SMSTemplatesViewModel Get(int? Id)
        {
            var smstemplates = _repository.Get(x => x.Id == Id);

            return new SMSTemplatesViewModel
            {
                CreationDate = smstemplates.CreationDate,
                Status = smstemplates.Status,
                IsItDeleted = smstemplates.IsItDeleted,
                DateOfUpdate = smstemplates.DateOfUpdate,
                Id = smstemplates.Id,
                SiteLanguage = smstemplates.SiteLanguage,

                Subject = smstemplates.Subject,
                Message = smstemplates.Message
            };
        }

        public void Delete(int id)
        {
            _repository.Delete(x => x.Id == id);
        }


        public IQueryable<SMSTemplatesViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new SMSTemplatesViewModel
                {
                    Id = x.Id,
                    Status = x.Status,
                    DateOfUpdate = x.DateOfUpdate,
                    CreationDate = x.CreationDate,
                    IsItDeleted = x.IsItDeleted,
                    SiteLanguage = x.SiteLanguage,

                    Subject = x.Subject,
                    Message = x.Message
                });
        }


        public void Update(SMSTemplatesViewModel viewModel)
        {
            var smstemplates = _repository.Get(x => x.Id == viewModel.Id);

            smstemplates.Status = viewModel.Status;
            smstemplates.DateOfUpdate = DateTime.Now;
            smstemplates.IsItDeleted = viewModel.IsItDeleted;
            smstemplates.SiteLanguage = viewModel.SiteLanguage;

            smstemplates.Subject = viewModel.Subject;
            smstemplates.Message = viewModel.Message;
            _repository.Update(smstemplates);
        }


    }
}
