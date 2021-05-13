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
    public class PublicationServices : BaseServices
    {
        private readonly STRepository<Publication> _repository;
        public PublicationServices(STUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new STRepository<Publication>(unitOfWork);
        }


        public void Add(PublicationViewModel viewModel)
        {
            _repository.Add(new Publication
            {
                CreationDate = DateTime.Now,
                IsItDeleted = false,
                Status = true,
                SiteLanguage = viewModel.SiteLanguage,

                Name = viewModel.Name,
                Description = viewModel.Description,
                Image = "/Areas/Login/Assets/images/" + viewModel.Image
             

            });
        }


        public PublicationViewModel Get(int? Id)
        {
            var publication = _repository.Get(x => x.Id == Id);

            return new PublicationViewModel
            {
                CreationDate = publication.CreationDate,
                Status = publication.Status,
                IsItDeleted = publication.IsItDeleted,
                DateOfUpdate = publication.DateOfUpdate,
                Id = publication.Id,
                 SiteLanguage = publication.SiteLanguage,

                Name = publication.Name,
                Description = publication.Description,
                Image =  publication.Image

            };
        }


        public void Delete(int id)
        {
            _repository.Delete(x => x.Id == id);
        }


        public IQueryable<PublicationViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new PublicationViewModel
                {
                    Id = x.Id,
                    Status = x.Status,
                    DateOfUpdate = x.DateOfUpdate,
                    CreationDate = x.CreationDate,
                    IsItDeleted = x.IsItDeleted,
                    SiteLanguage = x.SiteLanguage,
                    Name = x.Name,
                    Description = x.Description,
                    Image = x.Image,
           

                });
        }

        public IQueryable<PublicationViewModel> GetAllTR()
        {
            return _repository.GetList()
                .Select(x => new PublicationViewModel
                {
                    Id = x.Id,
                    Status = x.Status,
                    DateOfUpdate = x.DateOfUpdate,
                    CreationDate = x.CreationDate,
                    IsItDeleted = x.IsItDeleted,
                    SiteLanguage = x.SiteLanguage,
                    Name = x.Name,
                    Description = x.Description,
                    Image = x.Image,

                }).Where(x => x.SiteLanguage == (SiteLanguages)1);
        }

        public IQueryable<PublicationViewModel> GetAllFR()
        {
            return _repository.GetList()
                .Select(x => new PublicationViewModel
                {
                    Id = x.Id,
                    Status = x.Status,
                    DateOfUpdate = x.DateOfUpdate,
                    CreationDate = x.CreationDate,
                    IsItDeleted = x.IsItDeleted,
                    SiteLanguage = x.SiteLanguage,
                    Name = x.Name,
                    Description = x.Description,
                    Image = x.Image,

                }).Where(x => x.SiteLanguage == (SiteLanguages)2);
        }

        public void Update(PublicationViewModel viewModel)
        {
            var publication = _repository.Get(x => x.Id == viewModel.Id);

            publication.Status = viewModel.Status;
            publication.DateOfUpdate = DateTime.Now;
            publication.IsItDeleted = viewModel.IsItDeleted;
            publication.SiteLanguage = viewModel.SiteLanguage;

            publication.Name = viewModel.Name;
            publication.Image = viewModel.Image;
            publication.Description = viewModel.Description;

            _repository.Update(publication);
        }
    }
}
