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
    public  class SermonServices : BaseServices
    {
        private readonly STRepository<Sermon> _repository;

        public SermonServices(STUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new STRepository<Sermon>(unitOfWork);
        }

        public void Add(SermonViewModel viewModel)
        {

            _repository.Add(new Sermon
            {
                CreationDate = DateTime.Now,
                IsItDeleted = false,
                Status = true,
                SiteLanguage = viewModel.SiteLanguage,

                Title = viewModel.Title,
                Content = viewModel.Content,
                Image = "/Areas/Login/Assets/images/" + viewModel.Image,

            });


        }


        public SermonViewModel Get(int? Id)
        {
            var sermons = _repository.Get(x => x.Id == Id);

            return new SermonViewModel
            {
                CreationDate = sermons.CreationDate,
                Status = sermons.Status,
                IsItDeleted = sermons.IsItDeleted,
                DateOfUpdate = sermons.DateOfUpdate,
                Id = sermons.Id,
                SiteLanguage = sermons.SiteLanguage,
                Title = sermons.Title,
                Content = sermons.Content,
                Image = sermons.Image,



            };
        }


        public void Delete(int id)
        {
            _repository.Delete(x => x.Id == id);
        }


        public IQueryable<SermonViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new SermonViewModel
                {
                    Id = x.Id,
                    Status = x.Status,
                    DateOfUpdate = x.DateOfUpdate,
                    CreationDate = x.CreationDate,
                    IsItDeleted = x.IsItDeleted,
                    SiteLanguage = x.SiteLanguage,
                    Title = x.Title,
                    Content = x.Content,
                    Image = x.Image,

                });
        }

        public IQueryable<SermonViewModel> GetAllTR()
        {
            return _repository.GetList()
                .Select(x => new SermonViewModel
                {
                    Id = x.Id,
                    Status = x.Status,
                    DateOfUpdate = x.DateOfUpdate,
                    CreationDate = x.CreationDate,
                    IsItDeleted = x.IsItDeleted,
                    SiteLanguage = x.SiteLanguage,
                    Title = x.Title,
                    Content = x.Content,
                    Image = x.Image,

                }).Where(x => x.SiteLanguage == (SiteLanguages)1); ;
        }

        public IQueryable<SermonViewModel> GetAllFR()
        {
            return _repository.GetList()
                .Select(x => new SermonViewModel
                {
                    Id = x.Id,
                    Status = x.Status,
                    DateOfUpdate = x.DateOfUpdate,
                    CreationDate = x.CreationDate,
                    IsItDeleted = x.IsItDeleted,
                    SiteLanguage = x.SiteLanguage,
                    Title = x.Title,
                    Content = x.Content,
                    Image = x.Image,

                }).Where(x => x.SiteLanguage == (SiteLanguages)2); ;
        }

        public void Update(SermonViewModel viewModel)
        {
            var sermons = _repository.Get(x => x.Id == viewModel.Id);

            sermons.Status = viewModel.Status;
            sermons.DateOfUpdate = DateTime.Now;
            sermons.IsItDeleted = viewModel.IsItDeleted;
            sermons.SiteLanguage = viewModel.SiteLanguage;

            sermons.Title = viewModel.Title;
            sermons.Content = viewModel.Content;
            sermons.Image = viewModel.Image;

            _repository.Update(sermons);
        }



    }
}
