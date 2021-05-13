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
    public class FitreDonationServices : BaseServices
    {
        private readonly STRepository<FitreDonation> _repository;

        public FitreDonationServices(STUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new STRepository<FitreDonation>(unitOfWork);
        }

        public void Add(FitreDonationViewModel viewModel)
        {
            _repository.Add(new FitreDonation
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
                FitreAmount = viewModel.FitreAmount

            });
        }


        public FitreDonationViewModel Get(int? Id)
        {
            var fitredonations = _repository.Get(x => x.Id == Id);

            return new FitreDonationViewModel
            {
                CreationDate = fitredonations.CreationDate,
                Status = fitredonations.Status,
                IsItDeleted = fitredonations.IsItDeleted,
                DateOfUpdate = fitredonations.DateOfUpdate,
                Id = fitredonations.Id,

                Name = fitredonations.Name,
                Surname = fitredonations.Surname,
                Email = fitredonations.Email,
                City = fitredonations.City,
                Adress = fitredonations.Adress,
                PhoneNumber = fitredonations.PhoneNumber,
                ZipCode = fitredonations.ZipCode,
                 AdditionalInfo = fitredonations.AdditionalInfo,
                 FitreAmount = fitredonations.FitreAmount

            };
        }


        public void Delete(int id)
        {
            _repository.Delete(x => x.Id == id);
        }


        public IQueryable<FitreDonationViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new FitreDonationViewModel
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
                    FitreAmount = x.FitreAmount
                });
        }


        public void Update(FitreDonationViewModel viewModel) // Gerek yok aslında 
        {
            var fitredonations = _repository.Get(x => x.Id == viewModel.Id);

            fitredonations.Status = viewModel.Status;
            fitredonations.DateOfUpdate = DateTime.Now;
            fitredonations.IsItDeleted = viewModel.IsItDeleted;



            fitredonations.Name = viewModel.Name;
            fitredonations.Surname = viewModel.Surname;
            fitredonations.Email = viewModel.Email;
            fitredonations.City = viewModel.City;
            fitredonations.Adress = viewModel.Adress;
            fitredonations.PhoneNumber = viewModel.PhoneNumber;
            fitredonations.ZipCode = viewModel.ZipCode;
            fitredonations.AdditionalInfo = viewModel.AdditionalInfo;
            fitredonations.FitreAmount = viewModel.FitreAmount;
      
            _repository.Update(fitredonations);
        }
    }
}
