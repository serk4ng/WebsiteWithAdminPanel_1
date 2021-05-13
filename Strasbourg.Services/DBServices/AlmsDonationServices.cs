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
    public class AlmsDonationServices : BaseServices
    {
        private readonly STRepository<AlmsDonation> _repository;
 
        public AlmsDonationServices(STUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new STRepository<AlmsDonation>(unitOfWork);
        }

        public void Add(AlmsDonationViewModel viewModel)
        {
            _repository.Add(new AlmsDonation
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
                AdditionalInfo = viewModel.AdditionalInfo,
                AlmsAmount = viewModel.AlmsAmount

            });
        }


        public AlmsDonationViewModel Get(int? Id)
        {
            var almsdonations = _repository.Get(x => x.Id == Id);

            return new AlmsDonationViewModel
            {
                CreationDate = almsdonations.CreationDate,
                Status = almsdonations.Status,
                IsItDeleted = almsdonations.IsItDeleted,
                DateOfUpdate = almsdonations.DateOfUpdate,
                Id = almsdonations.Id,

                Name = almsdonations.Name,
                Surname = almsdonations.Surname,
                Email = almsdonations.Email,
                City = almsdonations.City,
                Adress = almsdonations.Adress,
                PhoneNumber = almsdonations.PhoneNumber,
                ZipCode = almsdonations.ZipCode,
                AdditionalInfo = almsdonations.AdditionalInfo,
                 AlmsAmount = almsdonations.AlmsAmount

            };
        }


        public void Delete(int id)
        {
            _repository.Delete(x => x.Id == id);
        }


        public IQueryable<AlmsDonationViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new AlmsDonationViewModel
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
                    AdditionalInfo = x.AdditionalInfo,
                    AlmsAmount = x.AlmsAmount
                });
        }

        public void Update(AlmsDonationViewModel viewModel) // Gerek yok aslında 
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
            almsdonations.AdditionalInfo = viewModel.AdditionalInfo;
            almsdonations.AlmsAmount = viewModel.AlmsAmount;

            _repository.Update(almsdonations);
        }
    }
}
