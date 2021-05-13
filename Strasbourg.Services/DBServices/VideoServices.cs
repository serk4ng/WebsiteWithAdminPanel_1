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
    public class VideoServices : BaseServices
    {
        private readonly STRepository<Video> _repository;

        public VideoServices(STUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new STRepository<Video>(unitOfWork);
        }


        public void Add(VideoViewModel viewModel)
        {

            _repository.Add(new Video
            {
                CreationDate = DateTime.Now,
                IsItDeleted = false,
                Status = true,
                SiteLanguage = viewModel.SiteLanguage,

                Title = viewModel.Title,
                Thumbnail = "/Areas/Login/Assets/images/" + viewModel.Thumbnail,
                Url = viewModel.Url

            });


        }

        public VideoViewModel Get(int? Id)
        {
            var videos = _repository.Get(x => x.Id == Id);

            return new VideoViewModel
            {
                CreationDate = videos.CreationDate,
                Status = videos.Status,
                IsItDeleted = videos.IsItDeleted,
                DateOfUpdate = videos.DateOfUpdate,
                Id = videos.Id,
                SiteLanguage = videos.SiteLanguage,

                Title = videos.Title,
                Thumbnail = videos.Thumbnail,
                Url = videos.Url

            };
        }

        public void Delete(int id)
        {
            _repository.Delete(x => x.Id == id);
        }


        public IQueryable<VideoViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new VideoViewModel
                {
                    Id = x.Id,
                    Status = x.Status,
                    DateOfUpdate = x.DateOfUpdate,
                    CreationDate = x.CreationDate,
                    IsItDeleted = x.IsItDeleted,
                    SiteLanguage = x.SiteLanguage,


                    Title = x.Title,
                    Thumbnail = x.Thumbnail,
                    Url = x.Url

                });
        }

        public IQueryable<VideoViewModel> GetAllTR()
        {
            return _repository.GetList()
                .Select(x => new VideoViewModel
                {
                    Id = x.Id,
                    Status = x.Status,
                    DateOfUpdate = x.DateOfUpdate,
                    CreationDate = x.CreationDate,
                    IsItDeleted = x.IsItDeleted,
                    SiteLanguage = x.SiteLanguage,


                    Title = x.Title,
                    Thumbnail = x.Thumbnail,
                    Url = x.Url

                }).Where(x => x.SiteLanguage == (SiteLanguages)1);
        }

        public IQueryable<VideoViewModel> GetAllFR()
        {
            return _repository.GetList()
                .Select(x => new VideoViewModel
                {
                    Id = x.Id,
                    Status = x.Status,
                    DateOfUpdate = x.DateOfUpdate,
                    CreationDate = x.CreationDate,
                    IsItDeleted = x.IsItDeleted,
                    SiteLanguage = x.SiteLanguage,


                    Title = x.Title,
                    Thumbnail = x.Thumbnail,
                    Url = x.Url

                }).Where(x => x.SiteLanguage == (SiteLanguages)2);
        }

        public void Update(VideoViewModel viewModel)
        {
            var sermons = _repository.Get(x => x.Id == viewModel.Id);

            sermons.Status = viewModel.Status;
            sermons.DateOfUpdate = DateTime.Now;
            sermons.IsItDeleted = viewModel.IsItDeleted;
            sermons.SiteLanguage = viewModel.SiteLanguage;

            sermons.Title = viewModel.Title;
            sermons.Thumbnail = viewModel.Thumbnail;
            sermons.Url = viewModel.Url;
            _repository.Update(sermons);
        }
    }
}
