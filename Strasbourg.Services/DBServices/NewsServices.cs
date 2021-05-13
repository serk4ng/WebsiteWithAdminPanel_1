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
    public class NewsServices : BaseServices
    {
        private readonly STRepository<News> _repository;

        public NewsServices(STUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new STRepository<News>(unitOfWork);
        }



        public void Add(NewsViewModel viewModel)
        {
         
            _repository.Add(new News
            {
                CreationDate = DateTime.Now,
                IsItDeleted = false,
                Status = true,
                SiteLanguage = viewModel.SiteLanguage,

                Title = viewModel.Title,
                Content = viewModel.Content,
                Image = "/Areas/Login/Assets/images/" + viewModel.Image,
                Category = viewModel.Category,
                NewsType = viewModel.NewsType
                 
                
                
            });

            
        }


        public NewsViewModel Get(int? Id)
        {
            var news = _repository.Get(x => x.Id == Id);

            return new NewsViewModel
            {
                CreationDate = news.CreationDate,
                Status = news.Status,
                IsItDeleted = news.IsItDeleted,
                DateOfUpdate = news.DateOfUpdate,
                Id = news.Id,
                SiteLanguage = news.SiteLanguage,
                Title = news.Title,
                Content = news.Content,   
                Image = news.Image,
                 Category = news.Category,
                  NewsType = news.NewsType

 


            };
        }


        public void Delete(int id)
        {
            _repository.Delete(x => x.Id == id);
        }

        public IQueryable<NewsViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new NewsViewModel
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
                     NewsType = x.NewsType,
                      Category = x.Category
   
                });
        }

        public IQueryable<NewsViewModel> GetAllTR()
        {
            return _repository.GetList()
                .Select(x => new NewsViewModel
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
                    NewsType = x.NewsType,
                    Category = x.Category

                }).Where(x => x.SiteLanguage == (SiteLanguages)1); ;
        }

        public IQueryable<NewsViewModel> GetAllFR()
        {
            return _repository.GetList()
                .Select(x => new NewsViewModel
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
                    NewsType = x.NewsType,
                    Category = x.Category

                }).Where(x => x.SiteLanguage == (SiteLanguages)2); ;
        }



        public void Update(NewsViewModel viewModel)
        {
            var news = _repository.Get(x => x.Id == viewModel.Id);

            news.Status = viewModel.Status;
            news.DateOfUpdate = DateTime.Now;
            news.IsItDeleted = viewModel.IsItDeleted;
            news.SiteLanguage = viewModel.SiteLanguage;

            news.Title = viewModel.Title;
            news.Content = viewModel.Content;
            news.Image = viewModel.Image;
            news.Category = viewModel.Category;
            news.NewsType = viewModel.NewsType;
 
            _repository.Update(news);
        }



    }
}
