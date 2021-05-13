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
    public class SacrificePriceServices : BaseServices
    {
        private readonly STRepository<SacrificePrice> _repository;

        public SacrificePriceServices(STUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new STRepository<SacrificePrice>(unitOfWork);
        }


        public void Add(SacrificePriceViewModel viewModel)
        {
            _repository.Add(new SacrificePrice
            {
                CreationDate = DateTime.Now,
                IsItDeleted = false,
                Status = true,

                Price = viewModel.Price

            });
        }


        public SacrificePriceViewModel Get(int? Id)
        {
            var boards = _repository.Get(x => x.Id == Id);

            return new SacrificePriceViewModel
            {
                CreationDate = boards.CreationDate,
                Status = boards.Status,
                IsItDeleted = boards.IsItDeleted,
                DateOfUpdate = boards.DateOfUpdate,
                Id = boards.Id,

                 Price = boards.Price
 

            };
        }


        public void Delete(int id)
        {
            _repository.Delete(x => x.Id == id);
        }


        public IQueryable<SacrificePriceViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new SacrificePriceViewModel
                {
                    Id = x.Id,
                    Status = x.Status,
                    DateOfUpdate = x.DateOfUpdate,
                    CreationDate = x.CreationDate,
                    IsItDeleted = x.IsItDeleted,

                     Price = x.Price
                });
        }


        public void Update(SacrificePriceViewModel viewModel)
        {
            var sacrificeprice = _repository.Get(x => x.Id == viewModel.Id);

            sacrificeprice.Status = viewModel.Status;
            sacrificeprice.DateOfUpdate = DateTime.Now;
            sacrificeprice.IsItDeleted = viewModel.IsItDeleted;

            sacrificeprice.Price = viewModel.Price;
            _repository.Update(sacrificeprice);
        }
    }
}
