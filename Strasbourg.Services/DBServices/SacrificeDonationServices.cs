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
    public class SacrificeDonationServices : BaseServices
    {
        private readonly STRepository<SacrificeDonation> _repository;

        public SacrificeDonationServices(STUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new STRepository<SacrificeDonation>(unitOfWork);
        }

        public void Add(SacrificeDonationViewModel viewModel)
        {
            _repository.Add(new SacrificeDonation
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
                Other = viewModel.Other,
                SacrificeCount = viewModel.SacrificeCount,
                SacrificeType = viewModel.SacrificeType,
                Total = viewModel.Total,
                   

            });
        }


        public SacrificeDonationViewModel Get(int? Id)
        {
            var sacrificedonations = _repository.Get(x => x.Id == Id);

            return new SacrificeDonationViewModel
            {
                CreationDate = sacrificedonations.CreationDate,
                Status = sacrificedonations.Status,
                IsItDeleted = sacrificedonations.IsItDeleted,
                DateOfUpdate = sacrificedonations.DateOfUpdate,
                Id = sacrificedonations.Id,

                Name = sacrificedonations.Name,
                Surname = sacrificedonations.Surname,
                Email = sacrificedonations.Email,
                City = sacrificedonations.City,
                Adress = sacrificedonations.Adress,
                PhoneNumber = sacrificedonations.PhoneNumber,
                ZipCode = sacrificedonations.ZipCode,
                Other = sacrificedonations.Other,
                SacrificeCount = sacrificedonations.SacrificeCount,
                SacrificeType = sacrificedonations.SacrificeType,
                Total = sacrificedonations.Total
                

            };
        }

        public void Delete(int id)
        {
            _repository.Delete(x => x.Id == id);
        }



        public IQueryable<SacrificeDonationViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new SacrificeDonationViewModel
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
                    Other = x.Other,
                    SacrificeCount = x.SacrificeCount,
                    SacrificeType = x.SacrificeType,
                    Total = x.Total
                    

                });
        }

        public void Update(SacrificeDonationViewModel viewModel) // Gerek yok aslında 
        {
            var sacrificedonations = _repository.Get(x => x.Id == viewModel.Id);

            sacrificedonations.Status = viewModel.Status;
            sacrificedonations.DateOfUpdate = DateTime.Now;
            sacrificedonations.IsItDeleted = viewModel.IsItDeleted;


            sacrificedonations.Name = viewModel.Name;
            sacrificedonations.Surname = viewModel.Surname;
            sacrificedonations.Email = viewModel.Email;
            sacrificedonations.City = viewModel.City;
            sacrificedonations.Adress = viewModel.Adress;
            sacrificedonations.PhoneNumber = viewModel.PhoneNumber;
            sacrificedonations.ZipCode = viewModel.ZipCode;
            sacrificedonations.Other = viewModel.Other;
            sacrificedonations.SacrificeCount = viewModel.SacrificeCount;
            sacrificedonations.SacrificeType = viewModel.SacrificeType;
            sacrificedonations.Total = viewModel.Total;
          
            _repository.Update(sacrificedonations);
        }

    }
}
