using Strasbourg.DAL.Models;
using Strasbourg.DAL.Repository;
using Strasbourg.DAL.UnitOfWork;
using Strasbourg.Domain.Enums;
using Strasbourg.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.Services.DBServices
{ 
    public class RelatedOrganizationServices : BaseServices
    {
        private readonly STRepository<RelatedOrganization> _repository;

        public RelatedOrganizationServices(STUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new STRepository<RelatedOrganization>(unitOfWork);
        }

        public void Add(RelatedOrganizationViewModel viewModel)
        {
            _repository.Add(new RelatedOrganization
            {
                CreationDate = DateTime.Now,
                IsItDeleted = false,
                Status = true,
              SiteLanguage = viewModel.SiteLanguage,
                Name = viewModel.Name,
                Adress = viewModel.Adress, 
                Website = viewModel.Website

            });
        }

        public RelatedOrganizationViewModel Get(int? Id)
        {
            var relatedorganizations = _repository.Get(x => x.Id == Id);

            return new RelatedOrganizationViewModel
            {
                CreationDate = relatedorganizations.CreationDate,
                Status = relatedorganizations.Status,
                IsItDeleted = relatedorganizations.IsItDeleted,
                DateOfUpdate = relatedorganizations.DateOfUpdate,
                Id = relatedorganizations.Id,
                SiteLanguage = relatedorganizations.SiteLanguage,
                Name = relatedorganizations.Name,
                Adress = relatedorganizations.Adress,
                Website = relatedorganizations.Website,

            };
        }

        public void Delete(int id)
        {
            _repository.Delete(x => x.Id == id);
        }

        public IQueryable<RelatedOrganizationViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new RelatedOrganizationViewModel
                {
                    Id = x.Id,
                    Status = x.Status,
                    DateOfUpdate = x.DateOfUpdate,
                    CreationDate = x.CreationDate,
                    IsItDeleted = x.IsItDeleted,
                    SiteLanguage = x.SiteLanguage,

                    Name = x.Name,
                    Adress = x.Adress,
                    Website = x.Website,
                });
        }

        public IQueryable<RelatedOrganizationViewModel> GetAllTR()
        {
            return _repository.GetList()
                .Select(x => new RelatedOrganizationViewModel
                {
                    Id = x.Id,
                    Status = x.Status,
                    DateOfUpdate = x.DateOfUpdate,
                    CreationDate = x.CreationDate,
                    IsItDeleted = x.IsItDeleted,
                    SiteLanguage = x.SiteLanguage,

                    Name = x.Name,
                    Adress = x.Adress,
                    Website = x.Website,
                }).Where(x => x.SiteLanguage == (SiteLanguages)1);
        }
        public IQueryable<RelatedOrganizationViewModel> GetAllFR()
        {
            return _repository.GetList()
                .Select(x => new RelatedOrganizationViewModel
                {
                    Id = x.Id,
                    Status = x.Status,
                    DateOfUpdate = x.DateOfUpdate,
                    CreationDate = x.CreationDate,
                    IsItDeleted = x.IsItDeleted,
                    SiteLanguage = x.SiteLanguage,

                    Name = x.Name,
                    Adress = x.Adress,
                    Website = x.Website,
                }).Where(x=>x.SiteLanguage ==(SiteLanguages)2);
        }

        public void Update(RelatedOrganizationViewModel viewModel)
        {
            var relatedorganizations = _repository.Get(x => x.Id == viewModel.Id);

            relatedorganizations.Status = viewModel.Status;
            relatedorganizations.DateOfUpdate = DateTime.Now;
            relatedorganizations.IsItDeleted = viewModel.IsItDeleted;
            relatedorganizations.SiteLanguage = viewModel.SiteLanguage;
            relatedorganizations.Name = viewModel.Name;
            relatedorganizations.Adress = viewModel.Adress;
            relatedorganizations.Website = viewModel.Website;

            _repository.Update(relatedorganizations);
        }


    }
}
