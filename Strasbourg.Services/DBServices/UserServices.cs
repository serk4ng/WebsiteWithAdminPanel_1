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
    public class UsersServices : BaseServices
    {
        private readonly STRepository<Users> _repository;

        public UsersServices(STUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new STRepository<Users>(unitOfWork);
        }

        public void Add(UsersViewModel viewModel)
        {
            _repository.Add(new Users
            {
                CreationDate = DateTime.Now,
                IsItDeleted = false,
                Status = true,
 
                Email = viewModel.Email,
                NameSurname = viewModel.NameSurname,
                Password = viewModel.Password,
                Degree = viewModel.Degree,
                UserType = viewModel.UserType
            });
        }

        public UsersViewModel Get(int? Id)
        {
            var users = _repository.Get(x => x.Id == Id);

            return new UsersViewModel
            {
                CreationDate = users.CreationDate,
                Status = users.Status,
                IsItDeleted = users.IsItDeleted,
                DateOfUpdate = users.DateOfUpdate,
                Id = users.Id,
                UserType = users.UserType,
                Password = users.Password,
                Degree = users.Degree,
                NameSurname = users.NameSurname,
                Email = users.Email,
           
            };
        }

        public void Delete(int id)
        {
            _repository.Delete(x => x.Id == id);
        }

        public IQueryable<UsersViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new UsersViewModel
                {
                    Id = x.Id,
                    Status = x.Status,
                    DateOfUpdate = x.DateOfUpdate,
                    CreationDate = x.CreationDate,
                    IsItDeleted = x.IsItDeleted,
                    Degree = x.Degree,
                    Email = x.Email,
                    NameSurname = x.NameSurname,
                    Password = x.Password,
                    UserType = x.UserType
                });
        }

        public void Update(UsersViewModel viewModel)
        {
            var users = _repository.Get(x => x.Id == viewModel.Id);

            users.Status = viewModel.Status;
            users.DateOfUpdate = DateTime.Now;
            users.IsItDeleted = viewModel.IsItDeleted;
            users.Degree = viewModel.Degree;
            users.Email = viewModel.Email;
            users.NameSurname = viewModel.NameSurname;
            users.Password = viewModel.Password;
            users.UserType = viewModel.UserType;

            _repository.Update(users);
        }

        public UsersViewModel SignIn(UsersViewModel viewModel)
        {
            var model = _repository.Get(x => x.Status && x.Email == viewModel.Email && x.Password == viewModel.Password);

            if (model == null)
            {
                return null;
            }

            return new UsersViewModel
            {
                Id = model.Id,
                NameSurname = model.NameSurname,
                UserType = model.UserType,
                Status = model.Status,
                Password = model.Password,
                IsItDeleted = model.IsItDeleted,
                Email = model.Email,
                Degree = viewModel.Degree,
                CreationDate = model.CreationDate,
                DateOfUpdate = model.DateOfUpdate
            };
        }
    }
}
