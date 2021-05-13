using Strasbourg.DAL.Mappings;
using Strasbourg.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.DAL.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
    : base("Server=.; Database=Strasbourg; User Id=sa; Pwd=123;")
        {

        }

        public DbSet<AidToMosques> AidToMosques { get; set; }
        public DbSet<AlmsDonation> AlmsDonations { get; set; }
        public DbSet<SisterOrganization> SisterOrganizations { get; set; }
         public DbSet<RelatedOrganization> RelatedOrganizations { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<ContactRequest> ContactRequests { get; set; }
        public DbSet<FitreDonation> FitreDonations { get; set; }
        public DbSet<GeneralDonation> GeneralDonations { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<RansomDonation> RansomDonations { get; set; }
        public DbSet<SacrificeDonation> SacrificeDonations { get; set; }
        public DbSet<Sermon> Sermons { get; set; }
        public DbSet<SiteSettings> SiteSettings { get; set; }
        public DbSet<Video> Videos{ get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<SacrificePrice> SacrificePrice { get; set; }
        public DbSet<EmailSettings> EmailSettings { get; set; }
        public DbSet<EmailTemplates> EmailTemplates { get; set; }
        public DbSet<EmailHistory> EmailHistory { get; set; }
        public DbSet<SMSSettings> SMSSettings { get; set; }
        public DbSet<SMSTemplates> SMSTemplates { get; set; }
        public DbSet<SMSHistory> SMSHistory { get; set; }
        public DbSet<NewsCategory> NewsCategories { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Publication> Publications { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AidToMosquesMap());
            modelBuilder.Configurations.Add(new AlmsDonationMap());
            modelBuilder.Configurations.Add(new AssociationMap());
            modelBuilder.Configurations.Add(new BoardMap());
            modelBuilder.Configurations.Add(new ContactRequestsMap());
            modelBuilder.Configurations.Add(new FitreDonationMap());
            modelBuilder.Configurations.Add(new GeneralDonationMap());
            modelBuilder.Configurations.Add(new NewsMap());
            modelBuilder.Configurations.Add(new SisterOrganizationMap());
            modelBuilder.Configurations.Add(new RansomDonationMap());
            modelBuilder.Configurations.Add(new SacrificeDonationMap());
            modelBuilder.Configurations.Add(new SermonMap());
            modelBuilder.Configurations.Add(new SiteSettingsMap());
            modelBuilder.Configurations.Add(new VideoMap());
            modelBuilder.Configurations.Add(new RelatedOrganizationMap());
            modelBuilder.Configurations.Add(new SacrificePriceMap());
            modelBuilder.Configurations.Add(new EmailSettingsMap());
            modelBuilder.Configurations.Add(new EmailTemplatesMap());
            modelBuilder.Configurations.Add(new SMSSettingsMap());
            modelBuilder.Configurations.Add(new SMSTemplatesMap());
            modelBuilder.Configurations.Add(new EmailHistoryMap());
            modelBuilder.Configurations.Add(new SMSHistoryMap());
            modelBuilder.Configurations.Add(new NewsCategoryMap());
            modelBuilder.Configurations.Add(new SubscriberMap());
            modelBuilder.Configurations.Add(new PublicationMap());
            base.OnModelCreating(modelBuilder);
        }    
    }
}
