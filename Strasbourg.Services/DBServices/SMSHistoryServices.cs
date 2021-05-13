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
    public class SMSHistoryServices : BaseServices
    {
        private readonly STRepository<SMSHistory> _repository;

        public SMSHistoryServices(STUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new STRepository<SMSHistory>(unitOfWork);
        }

        public void Add(SMSHistoryViewModel viewModel)
        {
            _repository.Add(new SMSHistory
            {
                CreationDate = DateTime.Now,
                IsItDeleted = false,
                Status = true,
                SiteLanguage = viewModel.SiteLanguage,

 
                Phone = viewModel.Phone,
                Message = viewModel.Message


            });
        }


        public SMSHistoryViewModel Get(int? Id)
        {
            var smshistories = _repository.Get(x => x.Id == Id);

            return new SMSHistoryViewModel
            {
                CreationDate = smshistories.CreationDate,
                Status = smshistories.Status,
                IsItDeleted = smshistories.IsItDeleted,
                DateOfUpdate = smshistories.DateOfUpdate,
                Id = smshistories.Id,
                SiteLanguage = smshistories.SiteLanguage,

         
                Phone = smshistories.Phone,
                Message = smshistories.Message
            };
        }
          
        public void Delete(int id)
        {
            _repository.Delete(x => x.Id == id);
        }

        public IQueryable<SMSHistoryViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new SMSHistoryViewModel
                {
                    Id = x.Id,
                    Status = x.Status,
                    DateOfUpdate = x.DateOfUpdate,
                    CreationDate = x.CreationDate,
                    IsItDeleted = x.IsItDeleted,

                    SiteLanguage = x.SiteLanguage,

            
                    Phone = x.Phone,
                    Message = x.Message
                });
        }





    }
}
