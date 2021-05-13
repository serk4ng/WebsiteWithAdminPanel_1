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
    public class NewsCategoryServices : BaseServices
    {
        private readonly STRepository<NewsCategory> _repository;


        public NewsCategoryServices(STUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new STRepository<NewsCategory>(unitOfWork);
        }



        public void Add(NewsCategoryViewModel viewModel)
        {

            _repository.Add(new NewsCategory
            {
                CreationDate = DateTime.Now,
                IsItDeleted = false,
                Status = true,
                SiteLanguage = viewModel.SiteLanguage,
                CategoryName = viewModel.Category,

            });


        }

        public void Update(NewsCategoryViewModel viewModel)
        {
            var newscategory = _repository.Get(x => x.Id == viewModel.Id);

            newscategory.Status = viewModel.Status;
            newscategory.DateOfUpdate = DateTime.Now;
            newscategory.IsItDeleted = viewModel.IsItDeleted;
            newscategory.CategoryName = viewModel.Category;
            newscategory.SiteLanguage = viewModel.SiteLanguage;

            _repository.Update(newscategory);
        }

        public NewsCategoryViewModel Get(int? Id)
        {
            var newscategory = _repository.Get(x => x.Id == Id);

            return new NewsCategoryViewModel
            {
                CreationDate = newscategory.CreationDate,
                Status = newscategory.Status,
                IsItDeleted = newscategory.IsItDeleted,
                DateOfUpdate = newscategory.DateOfUpdate,
                Id = newscategory.Id,
                SiteLanguage = newscategory.SiteLanguage,
                Category = newscategory.CategoryName
               
            };
        }

        public void Delete(int id)
        {
            _repository.Delete(x => x.Id == id);
        }

        public IQueryable<NewsCategoryViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new NewsCategoryViewModel
                {
                    Id = x.Id,
                    Status = x.Status,
                    DateOfUpdate = x.DateOfUpdate,
                    CreationDate = x.CreationDate,
                    IsItDeleted = x.IsItDeleted,
                    SiteLanguage = x.SiteLanguage,
                    Category = x.CategoryName
          

                });
        }


    }
}
