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
    public class GeneralDonationServices : BaseServices
    {
        private readonly STRepository<GeneralDonation> _repository;
        private readonly STRepository<SacrificeDonation> _repository2;
        private readonly STRepository<FitreDonation> _repository3;
        private readonly STRepository<RansomDonation> _repository4;
        private readonly STRepository<AlmsDonation> _repository5;
        private readonly STRepository<AidToMosques> _repository6;
        public GeneralDonationServices(STUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new STRepository<GeneralDonation>(unitOfWork);
            _repository2 = new STRepository<SacrificeDonation>(unitOfWork);
            _repository3 = new STRepository<FitreDonation>(unitOfWork);
            _repository4 = new STRepository<RansomDonation>(unitOfWork);
            _repository5 = new STRepository<AlmsDonation>(unitOfWork);
            _repository6 = new STRepository<AidToMosques>(unitOfWork);
        }

        public void Add(GeneralDonationViewModel viewModel)
        {
            _repository.Add(new GeneralDonation
            {
                CreationDate = DateTime.Now,
                IsItDeleted = false,
                Status = true,

                Name = viewModel.Name,
                Surname = viewModel.Surname,
                Email = viewModel.Email,
                City = viewModel.City,
                Adress =viewModel.Adress,
                PhoneNumber = viewModel.PhoneNumber,
                ZipCode = viewModel.ZipCode,
                Description = viewModel.Description,
                DonationAmount = viewModel.DonationAmount


            });
        }

        public GeneralDonationViewModel Get(int? Id)
        {
            var generaldonations = _repository.Get(x => x.Id == Id);

            return new GeneralDonationViewModel
            {
                CreationDate = generaldonations.CreationDate,
                Status = generaldonations.Status,
                IsItDeleted = generaldonations.IsItDeleted,
                DateOfUpdate = generaldonations.DateOfUpdate,
                Id = generaldonations.Id,

                Name = generaldonations.Name,
                Surname = generaldonations.Surname,
                Email = generaldonations.Email,
                City = generaldonations.City,
                Adress =generaldonations.Adress,
                PhoneNumber = generaldonations.PhoneNumber,
                ZipCode = generaldonations.ZipCode,
                Description = generaldonations.Description,
                DonationAmount = generaldonations.DonationAmount

            };
        }


        public void Delete(int id)
        {
            _repository.Delete(x => x.Id == id);
        }

        public IQueryable<GeneralDonationViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new GeneralDonationViewModel
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
                    Description = x.Description,
                    DonationAmount = x.DonationAmount
                });
        }


        public void Update(GeneralDonationViewModel viewModel) // Gerek yok aslında 
        {
            var generaldonates = _repository.Get(x => x.Id == viewModel.Id);

            generaldonates.Status = viewModel.Status;
            generaldonates.DateOfUpdate = DateTime.Now;
            generaldonates.IsItDeleted = viewModel.IsItDeleted;


            generaldonates.Name = viewModel.Name;
            generaldonates.Surname = viewModel.Surname;
            generaldonates.Email = viewModel.Email;
            generaldonates.City = viewModel.City;
            generaldonates.Adress = viewModel.Adress;
            generaldonates.PhoneNumber = viewModel.PhoneNumber;
            generaldonates.ZipCode = viewModel.ZipCode;
            generaldonates.Description = viewModel.Description;
            generaldonates.DonationAmount = viewModel.DonationAmount;
            _repository.Update(generaldonates);
        
        }


        public IQueryable<AllDonationsViewModel> GetAllDonations()
        {
            return _repository.GetList()
                .Select(x => new AllDonationsViewModel
                {
                    Id = x.Id,
                    Status = x.Status,
                    DateOfUpdate = x.DateOfUpdate,
                    CreationDate = x.CreationDate,
                    IsItDeleted = x.IsItDeleted,

                    Name = x.Name,
                    Surname = x.Surname,
                     DonationType = "Genel Bağış",
                      Phone = x.PhoneNumber,
                       Price = x.DonationAmount
                      

                }).Union(
                 _repository2.GetList()
                .Select(x => new AllDonationsViewModel
                {
                    Id = x.Id,
                    Status = x.Status,
                    DateOfUpdate = x.DateOfUpdate,
                    CreationDate = x.CreationDate,
                    IsItDeleted = x.IsItDeleted,

                    Name = x.Name,
                    Surname = x.Surname,
                    DonationType = "Kurban",
                    Phone = x.PhoneNumber, 
                    Price = x.Total
                })
                .Union(
                 _repository3.GetList()
                .Select(x => new AllDonationsViewModel
                {
                    Id = x.Id,
                    Status = x.Status,
                    DateOfUpdate = x.DateOfUpdate,
                    CreationDate = x.CreationDate,
                    IsItDeleted = x.IsItDeleted,

                    Name = x.Name,
                    Surname = x.Surname,
                    DonationType = "Fitre",
                    Phone = x.PhoneNumber,
                     Price = x.FitreAmount
                })
                .Union(
                 _repository4.GetList()
                .Select(x => new AllDonationsViewModel
                {
                    Id = x.Id,
                    Status = x.Status,
                    DateOfUpdate = x.DateOfUpdate,
                    CreationDate = x.CreationDate,
                    IsItDeleted = x.IsItDeleted,

                    Name = x.Name,
                    Surname = x.Surname,
                    DonationType = "Fidye",
                    Phone = x.PhoneNumber,
                     Price = x.RansomAmount
                })
                 .Union(
                 _repository5.GetList()
                .Select(x => new AllDonationsViewModel
                {
                    Id = x.Id,
                    Status = x.Status,
                    DateOfUpdate = x.DateOfUpdate,
                    CreationDate = x.CreationDate,
                    IsItDeleted = x.IsItDeleted,

                    Name = x.Name,
                    Surname = x.Surname,
                    DonationType = "Zekat",
                    Phone = x.PhoneNumber,
                     Price = x.AlmsAmount
                })
                 .Union(
                 _repository6.GetList()
                .Select(x => new AllDonationsViewModel
                {
                    Id = x.Id,
                    Status = x.Status,
                    DateOfUpdate = x.DateOfUpdate,
                    CreationDate = x.CreationDate,
                    IsItDeleted = x.IsItDeleted,

                    Name = x.Name,
                    Surname = x.Surname,
                    DonationType = "Camilere Yardım",
                    Phone = x.PhoneNumber,
                    Price = x.DonationAmount
                })))))).OrderByDescending(x=>x.CreationDate);
        }

    }
}
