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
    public class SubscriberServices : BaseServices
    {
        private readonly STRepository<Subscriber> _repository;

        public SubscriberServices(STUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new STRepository<Subscriber>(unitOfWork);
        }

        public void Add(SubscriberViewModel viewModel)
        {
            _repository.Add(new Subscriber
            {
                CreationDate = DateTime.Now,
                IsItDeleted = false,
                Status = true,

                Email = viewModel.Email

            });
        }

        public SubscriberViewModel Get(int? Id)
        {
            var subscriber = _repository.Get(x => x.Id == Id);

            return new SubscriberViewModel
            {
                CreationDate = subscriber.CreationDate,
                Status = subscriber.Status,
                IsItDeleted = subscriber.IsItDeleted,
                DateOfUpdate = subscriber.DateOfUpdate,
                Id = subscriber.Id,

                Email = subscriber.Email 
            };
        }


        public void Delete(int id)
        {
            _repository.Delete(x => x.Id == id);
        }

        public IQueryable<SubscriberViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new SubscriberViewModel
                {
                    Id = x.Id,
                    Status = x.Status,
                    DateOfUpdate = x.DateOfUpdate,
                    CreationDate = x.CreationDate,
                    IsItDeleted = x.IsItDeleted,

                    Email = x.Email
                });
        }
        public void Update(SubscriberViewModel viewModel)
        {
            var subscriber = _repository.Get(x => x.Id == viewModel.Id);

            subscriber.Status = viewModel.Status;
            subscriber.DateOfUpdate = DateTime.Now;
            subscriber.IsItDeleted = viewModel.IsItDeleted;


            subscriber.Email = viewModel.Email;

            _repository.Update(subscriber);
        }

    }
}
