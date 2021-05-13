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
    public class BoardServices : BaseServices
    {
        private readonly STRepository<Board> _repository;
        public BoardServices(STUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new STRepository<Board>(unitOfWork);
        }


        public void Add(BoardViewModel viewModel)
        {
            _repository.Add(new Board
            {
                CreationDate = DateTime.Now,
                IsItDeleted = false,
                Status = true,



                BoardType = viewModel.BoardType,
                Degree = viewModel.Degree,
                NameSurname = viewModel.NameSurname,
                Image = "/Areas/Login/Assets/images/" + viewModel.Image,
                Count = viewModel.Count + 1

            }) ; 
        }

        public BoardViewModel Get(int? Id)
        {
            var boards = _repository.Get(x => x.Id == Id);

            return new BoardViewModel
            {
                CreationDate = boards.CreationDate,
                Status = boards.Status,
                IsItDeleted = boards.IsItDeleted,
                DateOfUpdate = boards.DateOfUpdate,
                Id = boards.Id,

                NameSurname = boards.NameSurname,
                BoardType = boards.BoardType,
                Degree = boards.Degree,
                Image = boards.Image,
                Count = boards.Count

            };
        }


        public void Delete(int id)
        {
            _repository.Delete(x => x.Id == id);
        }

        public IQueryable<BoardViewModel> GetAllDirector()
        {
            return _repository.GetList()
                .Select(x => new BoardViewModel
                {
                    Id = x.Id,
                    Status = x.Status,
                    DateOfUpdate = x.DateOfUpdate,
                    CreationDate = x.CreationDate,
                    IsItDeleted = x.IsItDeleted,

                    NameSurname = x.NameSurname,
                    BoardType = x.BoardType,
                    Degree = x.Degree,
                    Image = x.Image,
                    Count = x.Count
                }).Where(x=>x.BoardType == (BoardType)1);
        }

        public IQueryable<BoardViewModel> GetAllAuditor()
        {
            return _repository.GetList()
                .Select(x => new BoardViewModel
                {
                    Id = x.Id,
                    Status = x.Status,
                    DateOfUpdate = x.DateOfUpdate,
                    CreationDate = x.CreationDate,
                    IsItDeleted = x.IsItDeleted,

                    NameSurname = x.NameSurname,
                    BoardType = x.BoardType,
                    Degree = x.Degree,
                    Image = x.Image,
                    Count = x.Count
                }).Where(x => x.BoardType == (BoardType)2);
        }


        public void Update(BoardViewModel viewModel)
        {
            var boards = _repository.Get(x => x.Id == viewModel.Id);

            boards.Status = viewModel.Status;
            boards.DateOfUpdate = DateTime.Now;
            boards.IsItDeleted = viewModel.IsItDeleted;



            boards.NameSurname = viewModel.NameSurname;
            boards.Degree = viewModel.Degree;
            boards.BoardType = viewModel.BoardType;
            boards.Image = viewModel.Image;
            boards.Count = viewModel.Count;
            _repository.Update(boards);
        }
    }
}
