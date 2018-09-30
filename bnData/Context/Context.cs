using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Factory.Models;
using Factory.Exceptions;

namespace Data
{
    public partial class Context : DbContext
    {
        private EntUsers _user;
        internal EntUsers loggedUser 
        {
            get{
                if (_user == null) throw new LoggedUserNotLoadedException("No user is logged"); 
                else return _user;
            }
            set {_user = value;}
        }
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }
#region models
        public virtual DbSet<EntAccountDetails> EntAccountDetails { get; set; }
        public virtual DbSet<EntAccounts> EntAccounts { get; set; }
        public virtual DbSet<EntAddresses> EntAddresses { get; set; }
        public virtual DbSet<EntArticleMetaData> EntArticleMetaData { get; set; }
        public virtual DbSet<EntArticles> EntArticles { get; set; }
        public virtual DbSet<EntBill> EntBill { get; set; }
        public virtual DbSet<EntBillDetails> EntBillDetails { get; set; }
        public virtual DbSet<EntBillGroup> EntBillGroup { get; set; }
        public virtual DbSet<EntCategories> EntCategories { get; set; }
        public virtual DbSet<EntCities> EntCities { get; set; }
        public virtual DbSet<EntContactDetails> EntContactDetails { get; set; }
        public virtual DbSet<EntContacts> EntContacts { get; set; }
        public virtual DbSet<EntFeatures> EntFeatures { get; set; }
        public virtual DbSet<EntPhoneNumbers> EntPhoneNumbers { get; set; }
        public virtual DbSet<EntProfiles> EntProfiles { get; set; }
        public virtual DbSet<EntQuickEntry> EntQuickEntry { get; set; }
        public virtual DbSet<EntStatus> EntStatus { get; set; }
        public virtual DbSet<EntTypes> EntTypes { get; set; }
        public virtual DbSet<EntUsers> EntUsers { get; set; }
        public virtual DbSet<RelBillGrouping> RelBillGrouping { get; set; }
        public virtual DbSet<RelCategoryBill> RelCategoryBill { get; set; }
        public virtual DbSet<RelContactsAddresses> RelContactsAddresses { get; set; }
        public virtual DbSet<RelPhoneNumbersContacts> RelPhoneNumbersContacts { get; set; }
        public virtual DbSet<RelProfilesFeatures> RelProfilesFeatures { get; set; }
        public virtual DbSet<RelUserContact> RelUserContact { get; set; }
        public virtual DbSet<RelUserProfiles> RelUserProfiles { get; set; }
#endregion
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(Transformation.StringTransformation.Unhide(Config.Constants.ACCESS));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EntAccountDetails>(entity =>
            {
                entity.HasKey(e => e.AdtId);

                entity.ToTable("entAccountDetails");

                entity.Property(e => e.AdtId)
                    .HasColumnName("adtID")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AccId)
                    .IsRequired()
                    .HasColumnName("accID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.AdtAccount)
                    .HasColumnName("adtAccount")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AdtAdditionalInformation)
                    .HasColumnName("adtAdditionalInformation")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AdtAgency)
                    .HasColumnName("adtAgency")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.dtCreation)
                    .HasColumnName("dtCreation")
                    .HasColumnType("datetime");

                entity.Property(e => e.dtLastChange)
                    .HasColumnName("dtLastChange")
                    .HasColumnType("datetime");

                entity.Property(e => e.userIDCreation)
                    .IsRequired()
                    .HasColumnName("userIDCreation")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.userIDLastChange)
                    .HasColumnName("userIDLastChange")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.HasOne(d => d.Acc)
                    .WithMany(p => p.EntAccountDetails)
                    .HasForeignKey(d => d.AccId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_entAccountDetails_entAccounts");
            });

            modelBuilder.Entity<EntAccounts>(entity =>
            {
                entity.HasKey(e => e.AccId);

                entity.ToTable("entAccounts");

                entity.Property(e => e.AccId)
                    .HasColumnName("accID")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AccCode)
                    .HasColumnName("accCode")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AccName)
                    .HasColumnName("accName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.dtCreation)
                    .HasColumnName("dtCreation")
                    .HasColumnType("datetime");

                entity.Property(e => e.dtLastChange)
                    .HasColumnName("dtLastChange")
                    .HasColumnType("datetime");

                entity.Property(e => e.TypId)
                    .IsRequired()
                    .HasColumnName("typID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.userIDCreation)
                    .IsRequired()
                    .HasColumnName("userIDCreation")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.userIDLastChange)
                    .HasColumnName("userIDLastChange")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.HasOne(d => d.Typ)
                    .WithMany(p => p.EntAccounts)
                    .HasForeignKey(d => d.TypId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_entAccounts_entTypes");
            });

            modelBuilder.Entity<EntAddresses>(entity =>
            {
                entity.HasKey(e => e.AddId);

                entity.ToTable("entAddresses");

                entity.Property(e => e.AddId)
                    .HasColumnName("addID")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AddComplement).HasColumnName("addComplement");

                entity.Property(e => e.AddName)
                    .IsRequired()
                    .HasColumnName("addName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddNumber).HasColumnName("addNumber");

                entity.Property(e => e.AddStreet).HasColumnName("addStreet");

                entity.Property(e => e.AddZipCode)
                    .HasColumnName("addZipCode")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CitId)
                    .IsRequired()
                    .HasColumnName("citID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.dtCreation)
                    .HasColumnName("dtCreation")
                    .HasColumnType("datetime");

                entity.Property(e => e.dtLastChange)
                    .HasColumnName("dtLastChange")
                    .HasColumnType("datetime");

                entity.Property(e => e.userIDCreation)
                    .IsRequired()
                    .HasColumnName("userIDCreation")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.userIDLastChange)
                    .HasColumnName("userIDLastChange")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cit)
                    .WithMany(p => p.EntAddresses)
                    .HasForeignKey(d => d.CitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_entAddresses_entCities");
            });

            modelBuilder.Entity<EntArticleMetaData>(entity =>
            {
                entity.HasKey(e => e.AmdId);

                entity.ToTable("entArticleMetaData");

                entity.Property(e => e.AmdId)
                    .HasColumnName("amdID")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AmdPublishDate)
                    .HasColumnName("amdPublishDate")
                    .HasColumnType("date");

                entity.Property(e => e.ArtId)
                    .IsRequired()
                    .HasColumnName("artID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.ArtIdParent)
                    .HasColumnName("artID_Parent")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.dtCreation)
                    .HasColumnName("dtCreation")
                    .HasColumnType("datetime");

                entity.Property(e => e.dtLastChange)
                    .HasColumnName("dtLastChange")
                    .HasColumnType("datetime");

                entity.Property(e => e.userIDCreation)
                    .IsRequired()
                    .HasColumnName("userIDCreation")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.userIDLastChange)
                    .HasColumnName("userIDLastChange")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.HasOne(d => d.Art)
                    .WithMany(p => p.EntArticleMetaData)
                    .HasForeignKey(d => d.ArtId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_entArticleMetaData_entArticles");
            });

            modelBuilder.Entity<EntArticles>(entity =>
            {
                entity.HasKey(e => e.ArtId);

                entity.ToTable("entArticles");

                entity.Property(e => e.ArtId)
                    .HasColumnName("artID")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ArtCode)
                    .HasColumnName("artCode")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ArtContent)
                    .IsRequired()
                    .HasColumnName("artContent")
                    .HasColumnType("text");

                entity.Property(e => e.ArtTitle)
                    .IsRequired()
                    .HasColumnName("artTitle")
                    .IsUnicode(false);

                entity.Property(e => e.ArtUnderTitle)
                    .HasColumnName("artUnderTitle")
                    .IsUnicode(false);

                entity.Property(e => e.CatId)
                    .IsRequired()
                    .HasColumnName("catID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.ConId)
                    .IsRequired()
                    .HasColumnName("conID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.dtCreation)
                    .HasColumnName("dtCreation")
                    .HasColumnType("datetime");

                entity.Property(e => e.dtLastChange)
                    .HasColumnName("dtLastChange")
                    .HasColumnType("datetime");

                entity.Property(e => e.userIDCreation)
                    .IsRequired()
                    .HasColumnName("userIDCreation")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.userIDLastChange)
                    .HasColumnName("userIDLastChange")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.EntArticles)
                    .HasForeignKey(d => d.CatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_entArticles_entCategories");

                entity.HasOne(d => d.Con)
                    .WithMany(p => p.EntArticles)
                    .HasForeignKey(d => d.ConId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_entArticles_entContacts");
            });

            modelBuilder.Entity<EntBill>(entity =>
            {
                entity.HasKey(e => e.BilId);

                entity.ToTable("entBill");

                entity.Property(e => e.BilId)
                    .HasColumnName("bilID")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AccId)
                    .IsRequired()
                    .HasColumnName("accID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.BilCode)
                    .HasColumnName("bilCode")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BilDateExpiration)
                    .HasColumnName("bilDateExpiration")
                    .HasColumnType("datetime");

                entity.Property(e => e.BilDateOfWarning)
                    .HasColumnName("bilDateOfWarning")
                    .HasColumnType("datetime");

                entity.Property(e => e.BilMultiplicator)
                    .HasColumnName("bilMultiplicator")
                    .HasColumnType("numeric(1, 0)")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.BilRecurrence)
                    .HasColumnName("bilRecurrence")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.BilValue)
                    .HasColumnName("bilValue")
                    .HasColumnType("numeric(18, 8)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ConId)
                    .IsRequired()
                    .HasColumnName("conID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.dtCreation)
                    .HasColumnName("dtCreation")
                    .HasColumnType("datetime");

                entity.Property(e => e.dtLastChange)
                    .HasColumnName("dtLastChange")
                    .HasColumnType("datetime");

                entity.Property(e => e.StaId)
                    .IsRequired()
                    .HasColumnName("staID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.userIDCreation)
                    .IsRequired()
                    .HasColumnName("userIDCreation")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.userIDLastChange)
                    .HasColumnName("userIDLastChange")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.HasOne(d => d.Acc)
                    .WithMany(p => p.EntBill)
                    .HasForeignKey(d => d.AccId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_entBill_entAccounts");

                entity.HasOne(d => d.Con)
                    .WithMany(p => p.EntBill)
                    .HasForeignKey(d => d.ConId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_entBill_entContacts");

                entity.HasOne(d => d.Sta)
                    .WithMany(p => p.EntBill)
                    .HasForeignKey(d => d.StaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_entBill_entStatus");
            });

            modelBuilder.Entity<EntBillDetails>(entity =>
            {
                entity.HasKey(e => e.BdtId);

                entity.ToTable("entBillDetails");

                entity.Property(e => e.BdtId)
                    .HasColumnName("bdtID")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.BdtDateOfRegistration)
                    .HasColumnName("bdtDateOfRegistration")
                    .HasColumnType("datetime");

                entity.Property(e => e.BdtDiscount)
                    .HasColumnName("bdtDiscount")
                    .HasColumnType("numeric(18, 8)");

                entity.Property(e => e.BdtFine)
                    .HasColumnName("bdtFine")
                    .HasColumnType("numeric(18, 8)");

                entity.Property(e => e.BdtInterest)
                    .HasColumnName("bdtInterest")
                    .HasColumnType("numeric(18, 8)");

                entity.Property(e => e.BdtTotalValue)
                    .HasColumnName("bdtTotalValue")
                    .HasColumnType("numeric(18, 8)");

                entity.Property(e => e.BilId)
                    .IsRequired()
                    .HasColumnName("bilID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.BtdObservation)
                    .HasColumnName("btdObservation")
                    .IsUnicode(false);

                entity.Property(e => e.dtCreation)
                    .HasColumnName("dtCreation")
                    .HasColumnType("datetime");

                entity.Property(e => e.dtLastChange)
                    .HasColumnName("dtLastChange")
                    .HasColumnType("datetime");

                entity.Property(e => e.userIDCreation)
                    .IsRequired()
                    .HasColumnName("userIDCreation")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.userIDLastChange)
                    .HasColumnName("userIDLastChange")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.HasOne(d => d.Bil)
                    .WithMany(p => p.EntBillDetails)
                    .HasForeignKey(d => d.BilId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_entBillDetails_entBill");
            });

            modelBuilder.Entity<EntBillGroup>(entity =>
            {
                entity.HasKey(e => e.BgrId);

                entity.ToTable("entBillGroup");

                entity.Property(e => e.BgrId)
                    .HasColumnName("bgrID")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.BgrDateOfFinalInstallment)
                    .HasColumnName("bgrDateOfFinalInstallment")
                    .HasColumnType("datetime");

                entity.Property(e => e.BgrDateOfFirstInstallment)
                    .HasColumnName("bgrDateOfFirstInstallment")
                    .HasColumnType("datetime");

                entity.Property(e => e.BgrTotalInstallments).HasColumnName("bgrTotalInstallments");

                entity.Property(e => e.dtCreation)
                    .HasColumnName("dtCreation")
                    .HasColumnType("datetime");

                entity.Property(e => e.dtLastChange)
                    .HasColumnName("dtLastChange")
                    .HasColumnType("datetime");

                entity.Property(e => e.userIDCreation)
                    .IsRequired()
                    .HasColumnName("userIDCreation")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.userIDLastChange)
                    .HasColumnName("userIDLastChange")
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EntCategories>(entity =>
            {
                entity.HasKey(e => e.CatId);

                entity.ToTable("entCategories");

                entity.Property(e => e.CatId)
                    .HasColumnName("catID")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CatCode)
                    .HasColumnName("catCode")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CatFriendlyCode)
                    .HasColumnName("catFriendlyCode")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CatName)
                    .IsRequired()
                    .HasColumnName("catName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.dtCreation)
                    .HasColumnName("dtCreation")
                    .HasColumnType("datetime");

                entity.Property(e => e.dtLastChange)
                    .HasColumnName("dtLastChange")
                    .HasColumnType("datetime");

                entity.Property(e => e.TypId)
                    .IsRequired()
                    .HasColumnName("typID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.userIDCreation)
                    .IsRequired()
                    .HasColumnName("userIDCreation")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.userIDLastChange)
                    .HasColumnName("userIDLastChange")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.HasOne(d => d.Typ)
                    .WithMany(p => p.EntCategories)
                    .HasForeignKey(d => d.TypId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_entCategories_entTypes");
            });

            modelBuilder.Entity<EntCities>(entity =>
            {
                entity.HasKey(e => e.CitId);

                entity.ToTable("entCities");

                entity.Property(e => e.CitId)
                    .HasColumnName("citID")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CitCountry)
                    .HasColumnName("citCountry")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CitName)
                    .IsRequired()
                    .HasColumnName("citName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CitState)
                    .HasColumnName("citState")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.dtCreation)
                    .HasColumnName("dtCreation")
                    .HasColumnType("datetime");

                entity.Property(e => e.dtLastChange)
                    .HasColumnName("dtLastChange")
                    .HasColumnType("datetime");

                entity.Property(e => e.userIDCreation)
                    .IsRequired()
                    .HasColumnName("userIDCreation")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.userIDLastChange)
                    .HasColumnName("userIDLastChange")
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EntContactDetails>(entity =>
            {
                entity.HasKey(e => e.CdeId);

                entity.ToTable("entContactDetails");

                entity.Property(e => e.CdeId)
                    .HasColumnName("cdeID")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CdeEmail)
                    .HasColumnName("cdeEmail")
                    .IsUnicode(false);

                entity.Property(e => e.ConId)
                    .IsRequired()
                    .HasColumnName("conID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.dtCreation)
                    .HasColumnName("dtCreation")
                    .HasColumnType("datetime");

                entity.Property(e => e.dtLastChange)
                    .HasColumnName("dtLastChange")
                    .HasColumnType("datetime");

                entity.Property(e => e.userIDCreation)
                    .IsRequired()
                    .HasColumnName("userIDCreation")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.userIDLastChange)
                    .HasColumnName("userIDLastChange")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.HasOne(d => d.Con)
                    .WithMany(p => p.EntContactDetails)
                    .HasForeignKey(d => d.ConId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_entContactDetails_entContacts");
            });

            modelBuilder.Entity<EntContacts>(entity =>
            {
                entity.HasKey(e => e.ConId);

                entity.ToTable("entContacts");

                entity.Property(e => e.ConId)
                    .HasColumnName("conID")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ConCode)
                    .HasColumnName("conCode")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ConFirstName)
                    .IsRequired()
                    .HasColumnName("conFirstName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ConLastname)
                    .HasColumnName("conLastname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ConMidleName)
                    .HasColumnName("conMidleName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ConObservation).HasColumnName("conObservation");

                entity.Property(e => e.dtCreation)
                    .HasColumnName("dtCreation")
                    .HasColumnType("datetime");

                entity.Property(e => e.dtLastChange)
                    .HasColumnName("dtLastChange")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsUser).HasColumnName("isUser");

                entity.Property(e => e.userIDCreation)
                    .IsRequired()
                    .HasColumnName("userIDCreation")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.userIDLastChange)
                    .HasColumnName("userIDLastChange")
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EntFeatures>(entity =>
            {
                entity.HasKey(e => e.FeaId);

                entity.ToTable("entFeatures");

                entity.Property(e => e.FeaId)
                    .HasColumnName("feaID")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.dtCreation)
                    .HasColumnName("dtCreation")
                    .HasColumnType("datetime");

                entity.Property(e => e.dtLastChange)
                    .HasColumnName("dtLastChange")
                    .HasColumnType("datetime");

                entity.Property(e => e.FeaController)
                    .HasColumnName("feaController")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FeaName)
                    .IsRequired()
                    .HasColumnName("feaName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FeaParent)
                    .HasColumnName("feaParent")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.ShouldShow).HasColumnName("shouldShow");

                entity.Property(e => e.userIDCreation)
                    .IsRequired()
                    .HasColumnName("userIDCreation")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.userIDLastChange)
                    .HasColumnName("userIDLastChange")
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EntPhoneNumbers>(entity =>
            {
                entity.HasKey(e => e.PnId);

                entity.ToTable("entPhoneNumbers");

                entity.Property(e => e.PnId)
                    .HasColumnName("pnID")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.dtCreation)
                    .HasColumnName("dtCreation")
                    .HasColumnType("datetime");

                entity.Property(e => e.dtLastChange)
                    .HasColumnName("dtLastChange")
                    .HasColumnType("datetime");

                entity.Property(e => e.PnName)
                    .IsRequired()
                    .HasColumnName("pnName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PnNumber)
                    .HasColumnName("pnNumber")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PnType)
                    .HasColumnName("pnType")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.userIDCreation)
                    .IsRequired()
                    .HasColumnName("userIDCreation")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.userIDLastChange)
                    .HasColumnName("userIDLastChange")
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EntProfiles>(entity =>
            {
                entity.HasKey(e => e.ProId);

                entity.ToTable("entProfiles");

                entity.Property(e => e.ProId)
                    .HasColumnName("proID")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.dtCreation)
                    .HasColumnName("dtCreation")
                    .HasColumnType("datetime");

                entity.Property(e => e.dtLastChange)
                    .HasColumnName("dtLastChange")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProName)
                    .IsRequired()
                    .HasColumnName("proName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.userIDCreation)
                    .IsRequired()
                    .HasColumnName("userIDCreation")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.userIDLastChange)
                    .HasColumnName("userIDLastChange")
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EntQuickEntry>(entity =>
            {
                entity.HasKey(e => e.QenId);

                entity.ToTable("entQuickEntry");

                entity.Property(e => e.QenId)
                    .HasColumnName("qenID")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AccId)
                    .IsRequired()
                    .HasColumnName("accID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.CatId)
                    .IsRequired()
                    .HasColumnName("catID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.dtCreation)
                    .HasColumnName("dtCreation")
                    .HasColumnType("datetime");

                entity.Property(e => e.dtLastChange)
                    .HasColumnName("dtLastChange")
                    .HasColumnType("datetime");

                entity.Property(e => e.QenCode)
                    .HasColumnName("qenCode")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.QenDateActivation)
                    .HasColumnName("qenDateActivation")
                    .HasColumnType("datetime");

                entity.Property(e => e.QenGroupId)
                    .HasColumnName("qenGroupID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.QenInstallmentNumber).HasColumnName("qenInstallmentNumber");

                entity.Property(e => e.QenTotalInstallments).HasColumnName("qenTotalInstallments");

                entity.Property(e => e.QenValue)
                    .HasColumnName("qenValue")
                    .HasColumnType("numeric(18, 8)");

                entity.Property(e => e.userIDCreation)
                    .IsRequired()
                    .HasColumnName("userIDCreation")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.userIDLastChange)
                    .HasColumnName("userIDLastChange")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.HasOne(d => d.Acc)
                    .WithMany(p => p.EntQuickEntry)
                    .HasForeignKey(d => d.AccId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_entQuickEntry_entAccounts");

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.EntQuickEntry)
                    .HasForeignKey(d => d.CatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_entQuickEntry_entCategories");
            });

            modelBuilder.Entity<EntStatus>(entity =>
            {
                entity.HasKey(e => e.StaId);

                entity.ToTable("entStatus");

                entity.Property(e => e.StaId)
                    .HasColumnName("staID")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.dtCreation)
                    .HasColumnName("dtCreation")
                    .HasColumnType("datetime");

                entity.Property(e => e.dtLastChange)
                    .HasColumnName("dtLastChange")
                    .HasColumnType("datetime");

                entity.Property(e => e.StaCode)
                    .HasColumnName("staCode")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.StaDescription)
                    .HasColumnName("staDescription")
                    .IsUnicode(false);

                entity.Property(e => e.StaName)
                    .IsRequired()
                    .HasColumnName("staName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.userIDCreation)
                    .IsRequired()
                    .HasColumnName("userIDCreation")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.userIDLastChange)
                    .HasColumnName("userIDLastChange")
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EntTypes>(entity =>
            {
                entity.HasKey(e => e.TypId);

                entity.ToTable("entTypes");

                entity.Property(e => e.TypId)
                    .HasColumnName("typID")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.dtCreation)
                    .HasColumnName("dtCreation")
                    .HasColumnType("datetime");

                entity.Property(e => e.dtLastChange)
                    .HasColumnName("dtLastChange")
                    .HasColumnType("datetime");

                entity.Property(e => e.TypAllowChange)
                    .IsRequired()
                    .HasColumnName("typAllowChange")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TypCode)
                    .HasColumnName("typCode")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.TypName)
                    .IsRequired()
                    .HasColumnName("typName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.userIDCreation)
                    .IsRequired()
                    .HasColumnName("userIDCreation")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.userIDLastChange)
                    .HasColumnName("userIDLastChange")
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EntUsers>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("entUsers");

                entity.Property(e => e.UserId)
                    .HasColumnName("userID")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.dtCreation)
                    .HasColumnName("dtCreation")
                    .HasColumnType("datetime");

                entity.Property(e => e.dtLastChange)
                    .HasColumnName("dtLastChange")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.UserCode)
                    .HasColumnName("userCode")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.userIDCreation)
                    .IsRequired()
                    .HasColumnName("userIDCreation")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.userIDLastChange)
                    .HasColumnName("userIDLastChange")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.UserKey)
                    .IsRequired()
                    .HasColumnName("userKey")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RelBillGrouping>(entity =>
            {
                entity.HasKey(e => new { e.BgrId, e.BilId });

                entity.ToTable("relBillGrouping");

                entity.Property(e => e.BgrId)
                    .HasColumnName("bgrID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.BilId)
                    .HasColumnName("bilID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.dtCreation)
                    .HasColumnName("dtCreation")
                    .HasColumnType("datetime");

                entity.Property(e => e.dtLastChange)
                    .HasColumnName("dtLastChange")
                    .HasColumnType("datetime");

                entity.Property(e => e.userIDCreation)
                    .IsRequired()
                    .HasColumnName("userIDCreation")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.userIDLastChange)
                    .HasColumnName("userIDLastChange")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.HasOne(d => d.Bgr)
                    .WithMany(p => p.RelBillGrouping)
                    .HasForeignKey(d => d.BgrId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_relBillGrouping_entBillGroup");

                entity.HasOne(d => d.Bil)
                    .WithMany(p => p.RelBillGrouping)
                    .HasForeignKey(d => d.BilId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_relBillGrouping_entBill");
            });

            modelBuilder.Entity<RelCategoryBill>(entity =>
            {
                entity.HasKey(e => new { e.BilId, e.CatId });

                entity.ToTable("relCategoryBill");

                entity.Property(e => e.BilId)
                    .HasColumnName("bilID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.CatId)
                    .HasColumnName("catID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.dtCreation)
                    .HasColumnName("dtCreation")
                    .HasColumnType("datetime");

                entity.Property(e => e.dtLastChange)
                    .HasColumnName("dtLastChange")
                    .HasColumnType("datetime");

                entity.Property(e => e.userIDCreation)
                    .IsRequired()
                    .HasColumnName("userIDCreation")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.userIDLastChange)
                    .HasColumnName("userIDLastChange")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.HasOne(d => d.Bil)
                    .WithMany(p => p.RelCategoryBill)
                    .HasForeignKey(d => d.BilId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_relCategoryBill_entBill");

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.RelCategoryBill)
                    .HasForeignKey(d => d.CatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_relCategoryBill_entCategories");
            });

            modelBuilder.Entity<RelContactsAddresses>(entity =>
            {
                entity.HasKey(e => new { e.ConId, e.AddId });

                entity.ToTable("relContactsAddresses");

                entity.Property(e => e.ConId)
                    .HasColumnName("conID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.AddId)
                    .HasColumnName("addID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.dtCreation)
                    .HasColumnName("dtCreation")
                    .HasColumnType("datetime");

                entity.Property(e => e.dtLastChange)
                    .HasColumnName("dtLastChange")
                    .HasColumnType("datetime");

                entity.Property(e => e.userIDCreation)
                    .IsRequired()
                    .HasColumnName("userIDCreation")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.userIDLastChange)
                    .HasColumnName("userIDLastChange")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.HasOne(d => d.Add)
                    .WithMany(p => p.RelContactsAddresses)
                    .HasForeignKey(d => d.AddId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_relContactsAddresses_entAddresses");

                entity.HasOne(d => d.Con)
                    .WithMany(p => p.RelContactsAddresses)
                    .HasForeignKey(d => d.ConId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_relContactsAddresses_entContacts");
            });

            modelBuilder.Entity<RelPhoneNumbersContacts>(entity =>
            {
                entity.HasKey(e => new { e.PnId, e.ConId });

                entity.ToTable("relPhoneNumbersContacts");

                entity.Property(e => e.PnId)
                    .HasColumnName("pnID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.ConId)
                    .HasColumnName("conID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.dtCreation)
                    .HasColumnName("dtCreation")
                    .HasColumnType("datetime");

                entity.Property(e => e.dtLastChange)
                    .HasColumnName("dtLastChange")
                    .HasColumnType("datetime");

                entity.Property(e => e.userIDCreation)
                    .IsRequired()
                    .HasColumnName("userIDCreation")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.userIDLastChange)
                    .HasColumnName("userIDLastChange")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.HasOne(d => d.Con)
                    .WithMany(p => p.RelPhoneNumbersContacts)
                    .HasForeignKey(d => d.ConId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_relPhoneNumbersContacts_entContacts");

                entity.HasOne(d => d.Pn)
                    .WithMany(p => p.RelPhoneNumbersContacts)
                    .HasForeignKey(d => d.PnId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_relPhoneNumbersContacts_entPhoneNumbers");
            });

            modelBuilder.Entity<RelProfilesFeatures>(entity =>
            {
                entity.HasKey(e => new { e.ProId, e.FeaId });

                entity.ToTable("relProfilesFeatures");

                entity.Property(e => e.ProId)
                    .HasColumnName("proID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.FeaId)
                    .HasColumnName("feaID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.dtCreation)
                    .HasColumnName("dtCreation")
                    .HasColumnType("datetime");

                entity.Property(e => e.dtLastChange)
                    .HasColumnName("dtLastChange")
                    .HasColumnType("datetime");

                entity.Property(e => e.Permission).HasColumnName("permission");

                entity.Property(e => e.userIDCreation)
                    .IsRequired()
                    .HasColumnName("userIDCreation")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.userIDLastChange)
                    .HasColumnName("userIDLastChange")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.HasOne(d => d.Fea)
                    .WithMany(p => p.RelProfilesFeatures)
                    .HasForeignKey(d => d.FeaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_relProfilesFeatures_entFeatures");

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.RelProfilesFeatures)
                    .HasForeignKey(d => d.ProId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_relProfilesFeatures_entProfiles");
            });

            modelBuilder.Entity<RelUserContact>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ConId });

                entity.ToTable("relUserContact");

                entity.Property(e => e.UserId)
                    .HasColumnName("userID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.ConId)
                    .HasColumnName("conID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.dtCreation)
                    .HasColumnName("dtCreation")
                    .HasColumnType("datetime");

                entity.Property(e => e.dtLastChange)
                    .HasColumnName("dtLastChange")
                    .HasColumnType("datetime");

                entity.Property(e => e.userIDCreation)
                    .IsRequired()
                    .HasColumnName("userIDCreation")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.userIDLastChange)
                    .HasColumnName("userIDLastChange")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.HasOne(d => d.Con)
                    .WithMany(p => p.RelUserContact)
                    .HasForeignKey(d => d.ConId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_relUserContact_entContacts");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RelUserContact)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_relUserContact_entUsers");
            });

            modelBuilder.Entity<RelUserProfiles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ProId });

                entity.ToTable("relUserProfiles");

                entity.Property(e => e.UserId)
                    .HasColumnName("userID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.ProId)
                    .HasColumnName("proID")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.dtCreation)
                    .HasColumnName("dtCreation")
                    .HasColumnType("datetime");

                entity.Property(e => e.dtLastChange)
                    .HasColumnName("dtLastChange")
                    .HasColumnType("datetime");

                entity.Property(e => e.userIDCreation)
                    .IsRequired()
                    .HasColumnName("userIDCreation")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.userIDLastChange)
                    .HasColumnName("userIDLastChange")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.RelUserProfiles)
                    .HasForeignKey(d => d.ProId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_relUserProfiles_entProfiles");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RelUserProfiles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_relUserProfiles_entUsers");
            });
        }
    }
}
