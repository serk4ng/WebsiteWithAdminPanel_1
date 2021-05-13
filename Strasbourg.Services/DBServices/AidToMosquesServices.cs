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
    public class AidToMosquesServices : BaseServices
    {
        private readonly STRepository<AidToMosques> _repository;

        public AidToMosquesServices(STUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new STRepository<AidToMosques>(unitOfWork);
        }

        public void Add(AidToMosquesViewModel viewModel)
        {
            _repository.Add(new AidToMosques
            {
                CreationDate = DateTime.Now,
                IsItDeleted = false,
                Status = true,

                Name = viewModel.Name,
                Surname = viewModel.Surname,
                Email = viewModel.Email,
                City = viewModel.City,
                Adress = viewModel.Adress,
                PhoneNumber = viewModel.PhoneNumber,
                ZipCode = viewModel.ZipCode,
           
                DonationAmount = viewModel.DonationAmount,
                Description = viewModel.Description
                  
            });
        }

        public AidToMosquesViewModel Get(int? Id)
        {
            var aidtomosques = _repository.Get(x => x.Id == Id);

            return new AidToMosquesViewModel
            {
                CreationDate = aidtomosques.CreationDate,
                Status = aidtomosques.Status,
                IsItDeleted = aidtomosques.IsItDeleted,
                DateOfUpdate = aidtomosques.DateOfUpdate,
                Id = aidtomosques.Id,

                Name = aidtomosques.Name,
                Surname = aidtomosques.Surname,
                Email = aidtomosques.Email,
                City = aidtomosques.City,
                Adress = aidtomosques.Adress,
                PhoneNumber = aidtomosques.PhoneNumber,
                ZipCode = aidtomosques.ZipCode,
                DonationAmount = aidtomosques.DonationAmount,
                Description = aidtomosques.Description

            };
        }

        public void Delete(int id)
        {
            _repository.Delete(x => x.Id == id);
        }

        public IQueryable<AidToMosquesViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new AidToMosquesViewModel
                {
                    Id = x.Id,
                    Status = x.Status,
                    DateOfUpdate = x.DateOfUpdate,
                    CreationDate = x.CreationDate,
                    IsItDeleted = x.IsItDeleted,

                    Name = x.Name,
                    Surname = x.Surname,
                    Email = x.Email,
                    City = x.City,
                    Adress = x.Adress,
                    PhoneNumber = x.PhoneNumber,
                    ZipCode = x.ZipCode,
                    DonationAmount = x.DonationAmount,
                    Description = x.Description
                });
        }


        public void Update(AidToMosquesViewModel viewModel) // Gerek yok aslında 
        {
            var almsdonations = _repository.Get(x => x.Id == viewModel.Id);

            almsdonations.Status = viewModel.Status;
            almsdonations.DateOfUpdate = DateTime.Now;
            almsdonations.IsItDeleted = viewModel.IsItDeleted;


            almsdonations.Name = viewModel.Name;
            almsdonations.Surname = viewModel.Surname;
            almsdonations.Email = viewModel.Email;
            almsdonations.City = viewModel.City;
            almsdonations.Adress = viewModel.Adress;
            almsdonations.PhoneNumber = viewModel.PhoneNumber;
            almsdonations.ZipCode = viewModel.ZipCode;
            almsdonations.DonationAmount = viewModel.DonationAmount;
            almsdonations.Description = viewModel.Description;

            _repository.Update(almsdonations);
        }

    }
}
