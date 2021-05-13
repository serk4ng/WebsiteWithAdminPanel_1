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
    public class ContactRequestsServices : BaseServices
    {
        private readonly STRepository<ContactRequest> _repository;

        public ContactRequestsServices(STUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new STRepository<ContactRequest>(unitOfWork);
        }

        public void Add(ContactRequestsViewModel viewModel)
        {
            _repository.Add(new ContactRequest
            {
                CreationDate = DateTime.Now,
                IsItDeleted = false,
                Status = true,

                Email = viewModel.Email,
                Message = viewModel.Message,
                NameSurname = viewModel.NameSurname,
                Subject = viewModel.Subject
                
            });
        }

        public ContactRequestsViewModel Get(int Id)
        {
            var contactRequests = _repository.Get(x => x.Id == Id);

            return new ContactRequestsViewModel
            {
                CreationDate = contactRequests.CreationDate,
                Status = contactRequests.Status,
                IsItDeleted = contactRequests.IsItDeleted,
                DateOfUpdate = contactRequests.DateOfUpdate,
                Id = contactRequests.Id,
                Email = contactRequests.Email,
                Subject = contactRequests.Subject,
                NameSurname = contactRequests.NameSurname,
                Message = contactRequests.Message,
 
            };
        }

        public void Delete(int id)
        {
            _repository.Delete(x => x.Id == id);
        }

        public IQueryable<ContactRequestsViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new ContactRequestsViewModel
                {
                    Id = x.Id,
                    Status = x.Status,
                    DateOfUpdate = x.DateOfUpdate,
                    CreationDate = x.CreationDate,
                    IsItDeleted = x.IsItDeleted,
                    Email = x.Email,
 
                    Message = x.Message,
                    NameSurname = x.NameSurname,
                    Subject = x.Subject
                });
        }

        public void Update(ContactRequestsViewModel viewModel)
        {
            var contactRequests = _repository.Get(x => x.Id == viewModel.Id);

            contactRequests.Status = viewModel.Status;
            contactRequests.DateOfUpdate = DateTime.Now;
            contactRequests.IsItDeleted = viewModel.IsItDeleted;
            contactRequests.Email = viewModel.Email;
            contactRequests.Message = viewModel.Message;
            contactRequests.NameSurname = viewModel.NameSurname;
            contactRequests.Subject = viewModel.Subject;

            _repository.Update(contactRequests);
        }
    }
}
