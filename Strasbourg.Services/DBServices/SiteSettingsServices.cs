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
    public class SiteSettingsServices : BaseServices
    {
        private readonly STRepository<SiteSettings> _repository;

        public SiteSettingsServices(STUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = new STRepository<SiteSettings>(unitOfWork);
        }


        public void Add(SiteSettingsViewModel viewModel)
        {
            _repository.Add(new SiteSettings
            {
                CreationDate = DateTime.Now,
                IsItDeleted = false,
                Status = true,
                SiteLanguage = viewModel.SiteLanguage,

                AboutUs = viewModel.AboutUs,
                OurGoals = viewModel.OurGoals,
                Principle = viewModel.Principle,
                Logo = "/Areas/Login/Assets/images/" + viewModel.Logo,
                Map = viewModel.Map,
                Phone = viewModel.Phone,
                Adress = viewModel.Adress,
                Email = viewModel.Email,
                Fax = viewModel.Fax,


                Facebook = viewModel.Facebook,
                Twitter = viewModel.Twitter,
                Instagram = viewModel.Twitter,
                Youtube = viewModel.Youtube,

                Slider1 = "/Areas/Login/Assets/images/" + viewModel.Slider1,
                Slider2 = "/Areas/Login/Assets/images/" + viewModel.Slider2,
                Slider3 = "/Areas/Login/Assets/images/" + viewModel.Slider3,
                Slider4 = "/Areas/Login/Assets/images/" + viewModel.Slider4,



            });


        
        }

        public SiteSettingsViewModel Get(int? Id)
        {
            var settings = _repository.Get(x => x.Id == Id);

            return new SiteSettingsViewModel
            {
                CreationDate = settings.CreationDate,
                Status = settings.Status,
                IsItDeleted = settings.IsItDeleted,
                DateOfUpdate = settings.DateOfUpdate,
                Id = settings.Id,

                SiteLanguage = settings.SiteLanguage,

                AboutUs = settings.AboutUs,
                OurGoals = settings.OurGoals,
                Principle = settings.Principle,
                Logo = settings.Logo,
                Map = settings.Map,
                Phone = settings.Phone,
                Adress = settings.Adress,
                Email = settings.Email,
                Fax = settings.Fax,


                Facebook = settings.Facebook,
                Twitter = settings.Twitter,
                Instagram = settings.Twitter,
                Youtube = settings.Youtube,

                Slider1 = settings.Slider1,
                Slider2 = settings.Slider2,
                Slider3 = settings.Slider3,
                Slider4 = settings.Slider4,

            };
        }

        public void Delete(int id)
        {
            _repository.Delete(x => x.Id == id);
        }

        public IQueryable<SiteSettingsViewModel> GetAll()
        {
            return _repository.GetList()
                .Select(x => new SiteSettingsViewModel
                {
                    Id = x.Id,
                    Status = x.Status,
                    DateOfUpdate = x.DateOfUpdate,
                    CreationDate = x.CreationDate,
                    IsItDeleted = x.IsItDeleted,

                    SiteLanguage = x.SiteLanguage,

                    AboutUs = x.AboutUs,
                    OurGoals = x.OurGoals,
                    Principle = x.Principle,
                    Logo = x.Logo,
                    Map = x.Map,
                    Phone = x.Phone,
                    Adress = x.Adress,
                    Email = x.Email,
                    Fax = x.Fax,
                    

                    Facebook = x.Facebook,
                    Twitter = x.Twitter,
                    Instagram = x.Twitter,
                    Youtube = x.Youtube,

                    Slider1 = x.Slider1,
                    Slider2 = x.Slider2,
                    Slider3 = x.Slider3,
                    Slider4 = x.Slider4,
                });
        }

        public IQueryable<SiteSettingsViewModel> GetAllTr()
        {
            return _repository.GetList()
                .Select(x => new SiteSettingsViewModel
                {
                    Id = x.Id,
                    Status = x.Status,
                    DateOfUpdate = x.DateOfUpdate,
                    CreationDate = x.CreationDate,
                    IsItDeleted = x.IsItDeleted,

                    SiteLanguage = x.SiteLanguage,

                    AboutUs = x.AboutUs,
                    OurGoals = x.OurGoals,
                    Principle = x.Principle,
                    Logo = x.Logo,
                    Map = x.Map,
                    Phone = x.Phone,
                    Adress = x.Adress,
                    Email = x.Email,
                    Fax = x.Fax,


                    Facebook = x.Facebook,
                    Twitter = x.Twitter,
                    Instagram = x.Twitter,
                    Youtube = x.Youtube,

                    Slider1 = x.Slider1,
                    Slider2 = x.Slider2,
                    Slider3 = x.Slider3,
                    Slider4 = x.Slider4,
                }).Where(x => x.SiteLanguage == (SiteLanguages)1);
        }

        public IQueryable<SiteSettingsViewModel> GetAllFr()
        {
            return _repository.GetList()
                .Select(x => new SiteSettingsViewModel
                {
                    Id = x.Id,
                    Status = x.Status,
                    DateOfUpdate = x.DateOfUpdate,
                    CreationDate = x.CreationDate,
                    IsItDeleted = x.IsItDeleted,

                    SiteLanguage = x.SiteLanguage,

                    AboutUs = x.AboutUs,
                    OurGoals = x.OurGoals,
                    Principle = x.Principle,
                    Logo = x.Logo,
                    Map = x.Map,
                    Phone = x.Phone,
                    Adress = x.Adress,
                    Email = x.Email,
                    Fax = x.Fax,


                    Facebook = x.Facebook,
                    Twitter = x.Twitter,
                    Instagram = x.Twitter,
                    Youtube = x.Youtube,

                    Slider1 = x.Slider1,
                    Slider2 = x.Slider2,
                    Slider3 = x.Slider3,
                    Slider4 = x.Slider4,
                }).Where(x => x.SiteLanguage == (SiteLanguages)2);
        }



        public void Update(SiteSettingsViewModel viewModel)
        {
            var settings = _repository.Get(x => x.Id == viewModel.Id);

            settings.Status = viewModel.Status;
            settings.DateOfUpdate = DateTime.Now;
            settings.IsItDeleted = viewModel.IsItDeleted;
 
            settings.AboutUs = viewModel.AboutUs;
            settings.OurGoals = viewModel.OurGoals;
            settings.Principle = viewModel.Principle;
            settings.Logo = viewModel.Logo;
            settings.Map = viewModel.Map;
            settings.Phone = viewModel.Phone;
            settings.Adress = viewModel.Adress;
            settings.Email = viewModel.Email;
            settings.Fax = viewModel.Fax;


            settings.Facebook = viewModel.Facebook;
            settings.Twitter = viewModel.Twitter;
            settings.Instagram = viewModel.Instagram;
            settings.Youtube = viewModel.Youtube;


            settings.Slider1 = viewModel.Slider1;
            settings.Slider2 = viewModel.Slider2;
            settings.Slider3 = viewModel.Slider3;
            settings.Slider4 = viewModel.Slider4;
 
 
            _repository.Update(settings);
        }



    }
}
