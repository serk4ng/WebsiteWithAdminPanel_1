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
    public class RansomDonationServices : BaseServices
    {
        private readonly STRepository<RansomDonation> _repository;

        public RansomDonationServices(STUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new STRepository<RansomDonation>(unitOfWork);
        }

        public void Add(RansomDonationViewModel viewModel)
        {
            _repository.Add(new RansomDonation
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
                 RansomAmount = viewModel. RansomAmount

            });
        }


        public RansomDonationViewModel Get(int? Id)
        {
            var ransomdonations = _repository.Get(x => x.Id == Id);

            return new RansomDonationViewModel
            {
                CreationDate = ransomdonations.CreationDate,
                Status = ransomdonations.Status,
                IsItDeleted = ransomdonations.IsItDeleted,
                DateOfUpdate = ransomdonations.DateOfUpdate,
                Id = ransomdonations.Id,

                Name = ransomdonations.Name,
                Surname = ransomdonations.Surname,
                Email = ransomdonations.Email,
                City = ransomdonations.City,
                Adress = ransomdonations.Adress,
                PhoneNumber = ransomdonations.PhoneNumber,
                ZipCode = ransomdonations.ZipCode,
                AdditionalInfo = ransomdonations.AdditionalInfo,
                 RansomAmount = ransomdonations.RansomAmount

            };
        }

        public void Delete(int id)
        {
            _repository.Delete(x => x.Id == id);
        }


        public IQueryable<RansomDonationViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new RansomDonationViewModel
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
                    RansomAmount = x.RansomAmount
                });
        }
        public void Update(RansomDonationViewModel viewModel) // Gerek yok aslında 
        {
            var ransomdonations = _repository.Get(x => x.Id == viewModel.Id);

            ransomdonations.Status = viewModel.Status;
            ransomdonations.DateOfUpdate = DateTime.Now;
            ransomdonations.IsItDeleted = viewModel.IsItDeleted;


            ransomdonations.Name = viewModel.Name;
            ransomdonations.Surname = viewModel.Surname;
            ransomdonations.Email = viewModel.Email;
            ransomdonations.City = viewModel.City;
            ransomdonations.Adress = viewModel.Adress;
            ransomdonations.PhoneNumber = viewModel.PhoneNumber;
            ransomdonations.ZipCode = viewModel.ZipCode;
            ransomdonations.AdditionalInfo = viewModel.AdditionalInfo;
            ransomdonations.RansomAmount = viewModel.RansomAmount;

            _repository.Update(ransomdonations);
        }

    }
}
