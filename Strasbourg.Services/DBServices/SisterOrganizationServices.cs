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
    public class SisterOrganizationServices : BaseServices
    {
        private readonly STRepository<SisterOrganization> _repository;

        public SisterOrganizationServices(STUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new STRepository<SisterOrganization>(unitOfWork);
        }

        public void Add(SisterOrganizationViewModel viewModel)
        {
            _repository.Add(new SisterOrganization
            {
                CreationDate = DateTime.Now,
                IsItDeleted = false,
                Status = true,
                

                Name = viewModel.Name,
                EstablishmentYear = viewModel.EstablishmentYear,
                Adress = viewModel.Adress,
                Website = viewModel.Website
        
            });
        }

        public SisterOrganizationViewModel Get(int? Id)
        {
            var sisterorganizations = _repository.Get(x => x.Id == Id);

            return new SisterOrganizationViewModel
            {
                CreationDate = sisterorganizations.CreationDate,
                Status = sisterorganizations.Status,
                IsItDeleted = sisterorganizations.IsItDeleted,
                DateOfUpdate = sisterorganizations.DateOfUpdate,
                Id = sisterorganizations.Id,

                Name = sisterorganizations.Name,
                EstablishmentYear = sisterorganizations.EstablishmentYear,
                Adress = sisterorganizations.Adress,
                Website = sisterorganizations.Website,

            };
        }

        public void Delete(int id)
        {
            _repository.Delete(x => x.Id == id);
        }

        public IQueryable<SisterOrganizationViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new SisterOrganizationViewModel
                {
                    Id = x.Id,
                    Status = x.Status,
                    DateOfUpdate = x.DateOfUpdate,
                    CreationDate = x.CreationDate,
                    IsItDeleted = x.IsItDeleted,
  
                           Name = x.Name,
                    EstablishmentYear = x.EstablishmentYear,
                    Adress = x.Adress,
                    Website = x.Website,
                });
        }

        public void Update(SisterOrganizationViewModel viewModel)
        {
            var sisterorganizations = _repository.Get(x => x.Id == viewModel.Id);

            sisterorganizations.Status = viewModel.Status;
            sisterorganizations.DateOfUpdate = DateTime.Now;
            sisterorganizations.IsItDeleted = viewModel.IsItDeleted;



            sisterorganizations.Name = viewModel.Name;
            sisterorganizations.EstablishmentYear = viewModel.EstablishmentYear;
            sisterorganizations.Adress = viewModel.Adress;
            sisterorganizations.Website = viewModel.Website;

            _repository.Update(sisterorganizations);
        }

 
    }
}
