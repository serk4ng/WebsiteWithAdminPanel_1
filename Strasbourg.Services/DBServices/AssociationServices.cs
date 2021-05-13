using Strasbourg.DAL.Models;
using Strasbourg.DAL.Repository;
using Strasbourg.DAL.UnitOfWork;
using Strasbourg.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.Services.DBServices
{

    public class AssociationServices : BaseServices
    {
        private readonly STRepository<Association> _repository;

        public AssociationServices(STUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new STRepository<Association>(unitOfWork);
        }

        public void Add(AssociationViewModel viewModel)
        {
            _repository.Add(new Association
            {
                CreationDate = DateTime.Now,
                IsItDeleted = false,
                Status = true,

                Name = viewModel.Name,
                Image = "/Areas/Login/Assets/images/" + viewModel.Image,
                Adress = viewModel.Adress,
                Count = (viewModel.Count)+1
                
            });
        }

        public AssociationViewModel Get(int? Id)
        {
            var associations = _repository.Get(x => x.Id == Id);

            return new AssociationViewModel
            {
                CreationDate = associations.CreationDate,
                Status = associations.Status,
                IsItDeleted = associations.IsItDeleted,
                DateOfUpdate = associations.DateOfUpdate,
                Id = associations.Id,

                Name = associations.Name,
                Image = associations.Image,
                Adress = associations.Adress,
                Count = associations.Count,

            };
        }

        public void Delete(int id)
        {
            _repository.Delete(x => x.Id == id);
        }

        public IQueryable<AssociationViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new AssociationViewModel
                {
                    Id = x.Id,
                    Status = x.Status,
                    DateOfUpdate = x.DateOfUpdate,
                    CreationDate = x.CreationDate,
                    IsItDeleted = x.IsItDeleted,

                    Name = x.Name,
                    Count = x.Count,
                    Adress = x.Adress,
                    Image = x.Image,
                });
        }

        public void Update(AssociationViewModel viewModel)
        {
            var associations = _repository.Get(x => x.Id == viewModel.Id);

            associations.Status = viewModel.Status;
            associations.DateOfUpdate = DateTime.Now;
            associations.IsItDeleted = viewModel.IsItDeleted;

            associations.Name = viewModel.Name;
            associations.Adress = viewModel.Adress;
            associations.Count = viewModel.Count;
            associations.Image = viewModel.Image;

            _repository.Update(associations);
        }


    }
}
