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
    public class EmailHistoryServices : BaseServices
    {
        private readonly STRepository<EmailHistory> _repository;

        public EmailHistoryServices(STUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new STRepository<EmailHistory>(unitOfWork);
        }

        public void Add(EmailHistoryViewModel viewModel)
        {
            _repository.Add(new EmailHistory
            {
                CreationDate = DateTime.Now,
                IsItDeleted = false,
                Status = true,
                SiteLanguage = viewModel.SiteLanguage,

                Subject = viewModel.Subject,
                ReceiverMail = viewModel.ReceiverMail,
                Message = viewModel.Message


            });
        }

        public EmailHistoryViewModel Get(int? Id)
        {
            var emailhistories = _repository.Get(x => x.Id == Id);

            return new EmailHistoryViewModel
            {
                CreationDate = emailhistories.CreationDate,
                Status = emailhistories.Status,
                IsItDeleted = emailhistories.IsItDeleted,
                DateOfUpdate = emailhistories.DateOfUpdate,
                Id = emailhistories.Id,
                SiteLanguage = emailhistories.SiteLanguage,

                Subject = emailhistories.Subject,
                ReceiverMail = emailhistories.ReceiverMail,
                Message = emailhistories.Message
            };
        }


        public void Delete(int id)
        {
            _repository.Delete(x => x.Id == id);
        }

        public IQueryable<EmailHistoryViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new EmailHistoryViewModel
                {
                    Id = x.Id,
                    Status = x.Status,
                    DateOfUpdate = x.DateOfUpdate,
                    CreationDate = x.CreationDate,
                    IsItDeleted = x.IsItDeleted,

                    SiteLanguage = x.SiteLanguage,

                    Subject = x.Subject,
                    ReceiverMail = x.ReceiverMail,
                    Message = x.Message
                });
        }




    }
}
