using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Robotics.Models
{
    public partial class RoboticsContext : DbContext
    {
        public virtual DbSet<Addresses> Addresses { get; set; }
        public virtual DbSet<AddressesInRelation> AddressesInRelation { get; set; }
        public virtual DbSet<Branches> Branches { get; set; }
        public virtual DbSet<BranchesTrans> BranchesTrans { get; set; }
        public virtual DbSet<Business> Business { get; set; }
        public virtual DbSet<BusinessTrans> BusinessTrans { get; set; }
        public virtual DbSet<Books> Books { get; set; }
      
        public virtual DbSet<Collections> Collections { get; set; }
        public virtual DbSet<ContributingFields> ContributingFields { get; set; }
        public virtual DbSet<ContributingFieldsTrans> ContributingFieldsTrans { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<CountriesTrans> CountriesTrans { get; set; }
        public virtual DbSet<DegreeOfMaturity> DegreeOfMaturity { get; set; }
        public virtual DbSet<DegreeOfMaturityTrans> DegreeOfMaturityTrans { get; set; }
        
        public virtual DbSet<InfluentialPeople> InfluentialPeople { get; set; }
        public virtual DbSet<InfluentialPeopleTrans> InfluentialPeopleTrans { get; set; }
        public virtual DbSet<InfoSources> InfoSources { get; set; }
        public virtual DbSet<InfoSourcesInRelation> InfoSourcesInRelation { get; set; }
        public virtual DbSet<InfoTypes> InfoTypes { get; set; }
        public virtual DbSet<Journals> Journals { get; set; }
        public virtual DbSet<Languages> Languages { get; set; }
        public virtual DbSet<ModesOfLocomotion> ModesOfLocomotion { get; set; }
        public virtual DbSet<ModesOfLocomotionTrans> ModesOfLocomotionTrans { get; set; }
        public virtual DbSet<Newspapers> Newspapers { get; set; }
        public virtual DbSet<OfficialStatements> OfficialStatements { get; set; }
        public virtual DbSet<RelatedContributingFields> RelatedContributingFields { get; set; }
        public virtual DbSet<RelatedBusiness> RelatedBusiness { get; set; }
        public virtual DbSet<RelatedBranches> RelatedBranches { get; set; }
        public virtual DbSet<RobotComponentsAndDesignFeatures> RobotComponentsAndDesignFeatures { get; set; }
        public virtual DbSet<RobotComponentsAndDesignFeaturesTrans> RobotComponentsAndDesignFeaturesTrans { get; set; }
        public virtual DbSet<RoboticsCompanies> RoboticsCompanies { get; set; }
        public virtual DbSet<RoboticsCompaniesInRelation> RoboticsCompaniesInRelation { get; set; }
        public virtual DbSet<RoboticsCompaniesTrans> RoboticsCompaniesTrans { get; set; }
        public virtual DbSet<RoboticsCompetitions> RoboticsCompetitions { get; set; }
        public virtual DbSet<RoboticsCompetitionsInRelation> RoboticsCompetitionsInRelation { get; set; }
        public virtual DbSet<RoboticsCompetitionsTrans> RoboticsCompetitionsTrans { get; set; }
        public virtual DbSet<RoboticsDevelopmentAndDevelopmentTools> RoboticsDevelopmentAndDevelopmentTools { get; set; }
        public virtual DbSet<RoboticsDevelopmentAndDevelopmentToolsTrans> RoboticsDevelopmentAndDevelopmentToolsTrans { get; set; }
        public virtual DbSet<RoboticsOrganizations> RoboticsOrganizations { get; set; }
        public virtual DbSet<RoboticsOrganizationsInRelation> RoboticsOrganizationsInRelation { get; set; }
        public virtual DbSet<RoboticsOrganizationsTrans> RoboticsOrganizationsTrans { get; set; }
        public virtual DbSet<RoboticsPrinciples> RoboticsPrinciples { get; set; }
        public virtual DbSet<RoboticsPrinciplesTrans> RoboticsPrinciplesTrans { get; set; }
        public virtual DbSet<Series> Series { get; set; }
        public virtual DbSet<SpecificRobots> SpecificRobots { get; set; }
        public virtual DbSet<SpecificRobotsInRelation> SpecificRobotsInRelation { get; set; }
        public virtual DbSet<SpecificRobotsTrans> SpecificRobotsTrans { get; set; }
        public virtual DbSet<Types> Types { get; set; }
        public virtual DbSet<TypesInRelation> TypesInRelation { get; set; }
        public virtual DbSet<TypesTrans> TypesTrans { get; set; }
        public virtual DbSet<Unpublished> Unpublished { get; set; }
        public virtual DbSet<Websites> Websites { get; set; }

        public RoboticsContext(DbContextOptions<RoboticsContext> options)
    : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Addresses>(entity =>
            {
                entity.ToTable("addresses");

                entity.Property(e => e.Company).HasMaxLength(50);

                entity.Property(e => e.Firstname).HasMaxLength(50);

                entity.Property(e => e.Lastname).HasMaxLength(50);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.Street).HasMaxLength(50);

                entity.Property(e => e.Streetnumber).HasMaxLength(10);

                entity.Property(e => e.Zip).HasMaxLength(20);

                entity.HasOne(d => d.CountryNavigation)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.Country)
                    .HasConstraintName("FK__addresses__Count__58D1301D");
            });

            modelBuilder.Entity<AddressesInRelation>(entity =>
            {
                entity.ToTable("addresses_in_relation");

                entity.Property(e => e.Tablename)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.HasOne(d => d.AddressesNavigation)
                    .WithMany(p => p.AddressesInRelation)
                    .HasForeignKey(d => d.Addresses)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__addresses__Addre__02925FBF");
            });

            modelBuilder.Entity<Books>(entity =>
            {
                entity.ToTable("books");

                entity.Property(e => e.Edition).HasMaxLength(50);

                entity.Property(e => e.Firstnameauhor1)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Firstnameauhor2).HasMaxLength(50);

                entity.Property(e => e.Firstnameauhor3).HasMaxLength(50);

                entity.Property(e => e.Furtherauthors).HasMaxLength(50);

                entity.Property(e => e.Lastnameauhor1)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Lastnameauhor2).HasMaxLength(50);

                entity.Property(e => e.Lastnameauhor3).HasMaxLength(50);

                entity.Property(e => e.Location).HasMaxLength(50);

                entity.Property(e => e.Pages).HasMaxLength(50);

                entity.Property(e => e.Publicationdate).HasColumnType("date");

                entity.Property(e => e.Title).HasMaxLength(200);
            });

           

            modelBuilder.Entity<Collections>(entity =>
            {
                entity.ToTable("collections");

                entity.Property(e => e.Edition).HasMaxLength(50);

                entity.Property(e => e.Firstnameauhor1)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Firstnameauhor2).HasMaxLength(50);

                entity.Property(e => e.Firstnameauhor3).HasMaxLength(50);

                entity.Property(e => e.Furtherauthors).HasMaxLength(50);

                entity.Property(e => e.Lastnameauhor1)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Lastnameauhor2).HasMaxLength(50);

                entity.Property(e => e.Lastnameauhor3).HasMaxLength(50);

                entity.Property(e => e.Location).HasMaxLength(50);

                entity.Property(e => e.Pages).HasMaxLength(50);

                entity.Property(e => e.Publicationdate).HasColumnType("date");

                entity.Property(e => e.Publisher).HasMaxLength(200);

                entity.Property(e => e.Title).HasMaxLength(200);
            });

            modelBuilder.Entity<ContributingFields>(entity =>
            {
                entity.ToTable("contributing_fields");
            });

            modelBuilder.Entity<ContributingFieldsTrans>(entity =>
            {
                entity.ToTable("contributing_fields_trans");

                entity.Property(e => e.Contributingfields).HasColumnName("contributingfields");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.ContributingfieldsNavigation)
                    .WithMany(p => p.ContributingFieldsTrans)
                    .HasForeignKey(d => d.Contributingfields)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__contribut__contr__7A3223E8");

                entity.HasOne(d => d.LanguageNavigation)
                    .WithMany(p => p.ContributingFieldsTrans)
                    .HasForeignKey(d => d.Language)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__contribut__Langu__793DFFAF");
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.ToTable("countries");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnType("char(2)");
            });

            modelBuilder.Entity<CountriesTrans>(entity =>
            {
                entity.ToTable("countries_trans");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.CountriesNavigation)
                    .WithMany(p => p.CountriesTrans)
                    .HasForeignKey(d => d.Countries)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__countries__Count__76619304");

                entity.HasOne(d => d.LanguageNavigation)
                    .WithMany(p => p.CountriesTrans)
                    .HasForeignKey(d => d.Language)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__countries__Langu__73852659");
            });

            modelBuilder.Entity<DegreeOfMaturity>(entity =>
            {
                entity.ToTable("degree_of_maturity");
            });

            modelBuilder.Entity<DegreeOfMaturityTrans>(entity =>
            {
                entity.ToTable("degree_of_maturity_trans");

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.HasOne(d => d.DegreeofmaturityNavigation)
                    .WithMany(p => p.DegreeOfMaturityTrans)
                    .HasForeignKey(d => d.Degreeofmaturity)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__degree_of__Degre__7E02B4CC");

                entity.HasOne(d => d.LanguageNavigation)
                    .WithMany(p => p.DegreeOfMaturityTrans)
                    .HasForeignKey(d => d.Language)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__degree_of__Langu__7D0E9093");
            });

            modelBuilder.Entity<Branches>(entity =>
            {
                entity.ToTable("branches");
            });
 modelBuilder.Entity<Business>(entity =>
           {
               entity.ToTable("business");
           });

            modelBuilder.Entity<BranchesTrans>(entity =>
            {
                entity.ToTable("branches_trans");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.BranchesNavigation) // BranchesNavigation
                    .WithMany(p => p.BranchesTrans)
                    .HasForeignKey(d => d.Branches)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__industrie__Indus__02C769E9");

                entity.HasOne(d => d.LanguageNavigation) // LanguageNavigation
                    .WithMany(p => p.BranchesTrans)
                    .HasForeignKey(d => d.Language)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__industrie__Langu__01D345B0");
            });
            modelBuilder.Entity<BusinessTrans>(entity =>
            {
                entity.ToTable("business_trans");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.BusinessNavigation) // BranchesNavigation
                    .WithMany(p => p.BusinessTrans)
                    .HasForeignKey(d => d.Business)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__business___Busin__50C5FA01");

                entity.HasOne(d => d.LanguageNavigation) // LanguageNavigation
                    .WithMany(p => p.BusinessTrans)
                    .HasForeignKey(d => d.Language)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__business___Langu__4FD1D5C8");
            });

            modelBuilder.Entity<InfluentialPeople>(entity =>
            {
                entity.ToTable("influential_people");
            });

            modelBuilder.Entity<InfluentialPeopleTrans>(entity =>
            {
                entity.ToTable("influential_people_trans");

                entity.Property(e => e.Firstname).HasMaxLength(50);

                entity.Property(e => e.Language).HasDefaultValueSql("'1'");

                entity.Property(e => e.Lastname).HasMaxLength(50);

                entity.Property(e => e.Prefix).HasMaxLength(50);

                entity.HasOne(d => d.InfluentialpeopleNavigation)
                    .WithMany(p => p.InfluentialPeopleTrans)
                    .HasForeignKey(d => d.Influentialpeople)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__influenti__Influ__42ACE4D4");

                entity.HasOne(d => d.LanguageNavigation)
                    .WithMany(p => p.InfluentialPeopleTrans)
                    .HasForeignKey(d => d.Language)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__influenti__Langu__41B8C09B");
            });

            modelBuilder.Entity<InfoSources>(entity =>
            {
                entity.ToTable("info_sources");

                entity.HasOne(d => d.BooksNavigation)
                    .WithMany(p => p.InfoSources)
                    .HasForeignKey(d => d.Books)
                    .HasConstraintName("FK__info_sour__Books__68D28DBC");

                entity.HasOne(d => d.CollectionsNavigation)
                    .WithMany(p => p.InfoSources)
                    .HasForeignKey(d => d.Collections)
                    .HasConstraintName("FK__info_sour__Colle__6BAEFA67");

                entity.HasOne(d => d.JournalsNavigation)
                    .WithMany(p => p.InfoSources)
                    .HasForeignKey(d => d.Journals)
                    .HasConstraintName("FK__info_sour__Journ__6ABAD62E");

                entity.HasOne(d => d.NewspapersNavigation)
                    .WithMany(p => p.InfoSources)
                    .HasForeignKey(d => d.Newspapers)
                    .HasConstraintName("FK__info_sour__Newsp__6D9742D9");

                entity.HasOne(d => d.OfficialstatementsNavigation)
                    .WithMany(p => p.InfoSources)
                    .HasForeignKey(d => d.Officialstatements)
                    .HasConstraintName("FK__info_sour__Offic__6E8B6712");

                entity.HasOne(d => d.SeriesNavigation)
                    .WithMany(p => p.InfoSources)
                    .HasForeignKey(d => d.Series)
                    .HasConstraintName("FK__info_sour__Serie__69C6B1F5");

                entity.HasOne(d => d.UnpublishedNavigation)
                    .WithMany(p => p.InfoSources)
                    .HasForeignKey(d => d.Unpublished)
                    .HasConstraintName("FK__info_sour__Unpub__6CA31EA0");

                entity.HasOne(d => d.WebsitesNavigation)
                    .WithMany(p => p.InfoSources)
                    .HasForeignKey(d => d.Websites)
                    .HasConstraintName("FK__info_sour__Websi__6F7F8B4B");
            });

            modelBuilder.Entity<InfoSourcesInRelation>(entity =>
            {
                entity.ToTable("info_sources_in_relation");

                entity.Property(e => e.Tablename)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.HasOne(d => d.InfotypesNavigation)
                    .WithMany(p => p.InfoSourcesInRelation)
                    .HasForeignKey(d => d.Infotype)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__info_sour__Infot__035179CE");
                
            });

            modelBuilder.Entity<InfoTypes>(entity =>
            {
                entity.ToTable("info_types");
                entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnType("varchar(50)");

            });

            modelBuilder.Entity<Journals>(entity =>
            {
                entity.ToTable("journals");

                entity.Property(e => e.Firstnameauhor1)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Firstnameauhor2).HasMaxLength(50);

                entity.Property(e => e.Firstnameauhor3).HasMaxLength(50);

                entity.Property(e => e.Furtherauthors).HasMaxLength(50);

                entity.Property(e => e.Issue).HasMaxLength(50);

                entity.Property(e => e.Journalname).HasMaxLength(200);

                entity.Property(e => e.Lastnameauhor1)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Lastnameauhor2).HasMaxLength(50);

                entity.Property(e => e.Lastnameauhor3).HasMaxLength(50);

                entity.Property(e => e.Pages).HasMaxLength(50);

                entity.Property(e => e.Publicationdate).HasColumnType("date");

                entity.Property(e => e.Title).HasMaxLength(200);

                entity.Property(e => e.Url)
                    .HasColumnName("URL")
                    .HasMaxLength(500);

                entity.Property(e => e.Volume).HasMaxLength(50);
            });

            modelBuilder.Entity<Languages>(entity =>
            {
                entity.ToTable("languages");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(2);
            });

            modelBuilder.Entity<ModesOfLocomotion>(entity =>
            {
                entity.ToTable("modes_of_locomotion");
            });

            modelBuilder.Entity<ModesOfLocomotionTrans>(entity =>
            {
                entity.ToTable("modes_of_locomotion_trans");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.LanguageNavigation)
                    .WithMany(p => p.ModesOfLocomotionTrans)
                    .HasForeignKey(d => d.Language)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__modes_of___Langu__0B5CAFEA");

                entity.HasOne(d => d.ModesoflocomotionNavigation)
                    .WithMany(p => p.ModesOfLocomotionTrans)
                    .HasForeignKey(d => d.Modesoflocomotion)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__modes_of___Modes__0C50D423");
            });

            modelBuilder.Entity<Newspapers>(entity =>
            {
                entity.ToTable("newspapers");

                entity.Property(e => e.Firstnameauhor1)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Firstnameauhor2).HasMaxLength(50);

                entity.Property(e => e.Firstnameauhor3).HasMaxLength(50);

                entity.Property(e => e.Furtherauthors).HasMaxLength(50);

                entity.Property(e => e.Issue).HasMaxLength(50);

                entity.Property(e => e.Lastnameauhor1).HasMaxLength(50);

                entity.Property(e => e.Lastnameauhor2).HasMaxLength(50);

                entity.Property(e => e.Lastnameauhor3).HasMaxLength(50);

                entity.Property(e => e.Newspapername).HasMaxLength(200);

                entity.Property(e => e.Pages).HasMaxLength(50);

                entity.Property(e => e.Publicationdate).HasColumnType("date");

                entity.Property(e => e.Title).HasMaxLength(200);
            });

            modelBuilder.Entity<OfficialStatements>(entity =>
            {
                entity.ToTable("official_statements");

                entity.Property(e => e.Issue).HasMaxLength(50);

                entity.Property(e => e.Location).HasMaxLength(50);

                entity.Property(e => e.Pages).HasMaxLength(50);

                entity.Property(e => e.Publication).HasMaxLength(200);

                entity.Property(e => e.Publicationdate).HasColumnType("date");

                entity.Property(e => e.Publisher)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Title).HasMaxLength(200);
            });

            modelBuilder.Entity<RelatedContributingFields>(entity =>
            {
                entity.ToTable("related_contributing_fields");

                entity.HasOne(d => d.Contributingfield1Navigation)
                    .WithMany(p => p.RelatedContributingFieldsContributingfield1Navigation)
                    .HasForeignKey(d => d.Contributingfield1)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__related_c__Contr__2739D489");

                entity.HasOne(d => d.Contributingfield2Navigation)
                    .WithMany(p => p.RelatedContributingFieldsContributingfield2Navigation)
                    .HasForeignKey(d => d.Contributingfield2)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__related_c__Contr__282DF8C2");
            });

            modelBuilder.Entity<RelatedBranches>(entity =>
            {
                entity.ToTable("related_branches");

                entity.HasOne(d => d.Industry1Navigation)
                    .WithMany(p => p.RelatedBranchesIndustry1Navigation)
                    .HasForeignKey(d => d.Industry1)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__related_i__Indus__1CBC4616");

                entity.HasOne(d => d.Industry2Navigation)
                    .WithMany(p => p.RelatedBranchesIndustry2Navigation)
                    .HasForeignKey(d => d.Industry2)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__related_i__Indus__1DB06A4F");
            });
            modelBuilder.Entity<RelatedBusiness>(entity =>
            {
                entity.ToTable("related_business");

                entity.HasOne(d => d.Business1Navigation)
                    .WithMany(p => p.RelatedBusinessBusiness1Navigation)
                    .HasForeignKey(d => d.Business1)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__related_b__Busin__5772F790");

                entity.HasOne(d => d.Business2Navigation)
                    .WithMany(p => p.RelatedBusinessBusiness2Navigation)
                    .HasForeignKey(d => d.Business2)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__related_b__Busin__58671BC9");
            });

            modelBuilder.Entity<RobotComponentsAndDesignFeatures>(entity =>
            {
                entity.ToTable("robot_components_and_design_features");
            });

            modelBuilder.Entity<RobotComponentsAndDesignFeaturesTrans>(entity =>
            {
                entity.ToTable("robot_components_and_design_features_trans");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.LanguageNavigation)
                    .WithMany(p => p.RobotComponentsAndDesignFeaturesTrans)
                    .HasForeignKey(d => d.Language)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__robot_com__Langu__10216507");

                entity.HasOne(d => d.RobotcomponentsanddesignfeaturesNavigation)
                    .WithMany(p => p.RobotComponentsAndDesignFeaturesTrans)
                    .HasForeignKey(d => d.Robotcomponentsanddesignfeatures)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__robot_com__Robot__11158940");
            });

            modelBuilder.Entity<RoboticsCompanies>(entity =>
            {
                entity.ToTable("robotics_companies");
            });

            modelBuilder.Entity<RoboticsCompaniesInRelation>(entity =>
            {
                entity.ToTable("robotics_companies_in_relation");

                entity.HasOne(d => d.ContributingfieldsNavigation)
                    .WithMany(p => p.RoboticsCompaniesInRelation)
                    .HasForeignKey(d => d.Contributingfields)
                    .HasConstraintName("FK__robotics___Contr__7720AD13");

                entity.HasOne(d => d.BranchesNavigation)//Navigation
                    .WithMany(p => p.RoboticsCompaniesInRelation)
                    .HasForeignKey(d => d.Branches)
                    .HasConstraintName("FK__robotics___Indus__762C88DA");

                entity.HasOne(d => d.BusinessNavigation)//Navigation
                                   .WithMany(p => p.RoboticsCompaniesInRelation)
                                   .HasForeignKey(d => d.Business)
                                   .HasConstraintName("FK__robotics___Busin__51BA1E3A");

                entity.HasOne(d => d.RoboticscompaniesNavigation)
                    .WithMany(p => p.RoboticsCompaniesInRelation)
                    .HasForeignKey(d => d.Roboticscompanies)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__robotics___Robot__753864A1");
            });

            modelBuilder.Entity<RoboticsCompaniesTrans>(entity =>
            {
                entity.ToTable("robotics_companies_trans");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.LanguageNavigation)
                    .WithMany(p => p.RoboticsCompaniesTrans)
                    .HasForeignKey(d => d.Language)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__robotics___Langu__3DE82FB7");

                entity.HasOne(d => d.RoboticscompaniesNavigation)
                    .WithMany(p => p.RoboticsCompaniesTrans)
                    .HasForeignKey(d => d.Roboticscompanies)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__robotics___Robot__3EDC53F0");
            });

            modelBuilder.Entity<RoboticsCompetitions>(entity =>
            {
                entity.ToTable("robotics_competitions");
            });

            modelBuilder.Entity<RoboticsCompetitionsInRelation>(entity =>
            {
                entity.ToTable("robotics_competitions_in_relation");

                entity.HasOne(d => d.ContributingfieldsNavigation)
                    .WithMany(p => p.RoboticsCompetitionsInRelation)
                    .HasForeignKey(d => d.Contributingfields)
                    .HasConstraintName("FK__robotics___Contr__00AA174D");

                entity.HasOne(d => d.BranchesNavigation)
                    .WithMany(p => p.RoboticsCompetitionsInRelation)
                    .HasForeignKey(d => d.Branches)
                    .HasConstraintName("FK__robotics___Indus__7FB5F314");
                entity.HasOne(d => d.BusinessNavigation)
                    .WithMany(p => p.RoboticsCompetitionsInRelation)
                    .HasForeignKey(d => d.Business)
                    .HasConstraintName("FK__robotics___Busin__54968AE5");

                entity.HasOne(d => d.RoboticscompetitionsNavigation)
                    .WithMany(p => p.RoboticsCompetitionsInRelation)
                    .HasForeignKey(d => d.Roboticscompetitions)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__robotics___Robot__7EC1CEDB");
            });

            modelBuilder.Entity<RoboticsCompetitionsTrans>(entity =>
            {
                entity.ToTable("robotics_competitions_trans");

                entity.HasOne(d => d.LanguageNavigation)
                    .WithMany(p => p.RoboticsCompetitionsTrans)
                    .HasForeignKey(d => d.Language)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__robotics___Langu__19AACF41");

                entity.HasOne(d => d.RoboticscompetitionsNavigation)
                    .WithMany(p => p.RoboticsCompetitionsTrans)
                    .HasForeignKey(d => d.Roboticscompetitions)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__robotics___Robot__1A9EF37A");
            });

            modelBuilder.Entity<RoboticsDevelopmentAndDevelopmentTools>(entity =>
            {
                entity.ToTable("robotics_development_and_development_tools");
            });

            modelBuilder.Entity<RoboticsDevelopmentAndDevelopmentToolsTrans>(entity =>
            {
                entity.ToTable("robotics_development_and_development_tools_trans");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.LanguageNavigation)
                    .WithMany(p => p.RoboticsDevelopmentAndDevelopmentToolsTrans)
                    .HasForeignKey(d => d.Language)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__robotics___Langu__3A179ED3");

                entity.HasOne(d => d.RoboticsdevelopmentanddevelopmenttoolsNavigation)
                    .WithMany(p => p.RoboticsDevelopmentAndDevelopmentToolsTrans)
                    .HasForeignKey(d => d.Roboticsdevelopmentanddevelopmenttools)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__robotics___Robot__3B0BC30C");
            });

            modelBuilder.Entity<RoboticsOrganizations>(entity =>
            {
                entity.ToTable("robotics_organizations");
            });

            modelBuilder.Entity<RoboticsOrganizationsInRelation>(entity =>
            {
                entity.ToTable("robotics_organizations_in_relation");

                entity.HasOne(d => d.ContributingfieldsNavigation)
                    .WithMany(p => p.RoboticsOrganizationsInRelation)
                    .HasForeignKey(d => d.Contributingfields)
                    .HasConstraintName("FK__robotics___Contr__7BE56230");

                entity.HasOne(d => d.BranchesNavigation)
                    .WithMany(p => p.RoboticsOrganizationsInRelation)
                    .HasForeignKey(d => d.Branches)
                    .HasConstraintName("FK__robotics___Indus__7AF13DF7");
                entity.HasOne(d => d.BusinessNavigation)
                    .WithMany(p => p.RoboticsOrganizationsInRelation)
                    .HasForeignKey(d => d.Business)
                    .HasConstraintName("FK__robotics___Busin__53A266AC");

                entity.HasOne(d => d.RoboticsorganizationsNavigation)
                    .WithMany(p => p.RoboticsOrganizationsInRelation)
                    .HasForeignKey(d => d.Roboticsorganizations)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__robotics___Robot__79FD19BE");
            });

            modelBuilder.Entity<RoboticsOrganizationsTrans>(entity =>
            {
                entity.ToTable("robotics_organizations_trans");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.LanguageNavigation)
                    .WithMany(p => p.RoboticsOrganizationsTrans)
                    .HasForeignKey(d => d.Language)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__robotics___Langu__36470DEF");

                entity.HasOne(d => d.RoboticsorganizationsNavigation)
                    .WithMany(p => p.RoboticsOrganizationsTrans)
                    .HasForeignKey(d => d.Roboticsorganizations)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__robotics___Robot__373B3228");
            });

            modelBuilder.Entity<RoboticsPrinciples>(entity =>
            {
                entity.ToTable("robotics_principles");
            });

            modelBuilder.Entity<RoboticsPrinciplesTrans>(entity =>
            {
                entity.ToTable("robotics_principles_trans");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.LanguageNavigation)
                    .WithMany(p => p.RoboticsPrinciplesTrans)
                    .HasForeignKey(d => d.Language)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__robotics___Langu__2AD55B43");

                entity.HasOne(d => d.RoboticsprinciplesNavigation)
                    .WithMany(p => p.RoboticsPrinciplesTrans)
                    .HasForeignKey(d => d.Roboticsprinciples)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__robotics___Robot__2BC97F7C");
            });

            modelBuilder.Entity<Series>(entity =>
            {
                entity.ToTable("series");

                entity.Property(e => e.Edition).HasMaxLength(50);

                entity.Property(e => e.Firstnameauhor1)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Firstnameauhor2).HasMaxLength(50);

                entity.Property(e => e.Firstnameauhor3).HasMaxLength(50);

                entity.Property(e => e.Furtherauthors).HasMaxLength(50);

                entity.Property(e => e.Lastnameauhor1)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Lastnameauhor2).HasMaxLength(50);

                entity.Property(e => e.Lastnameauhor3).HasMaxLength(50);

                entity.Property(e => e.Location).HasMaxLength(50);

                entity.Property(e => e.Pages).HasMaxLength(50);

                entity.Property(e => e.Publicationdate).HasColumnType("date");

                entity.Property(e => e.Title).HasMaxLength(200);

                entity.Property(e => e.Titleseries).HasMaxLength(200);

                entity.Property(e => e.Volume).HasMaxLength(50);
            });

            modelBuilder.Entity<SpecificRobots>(entity =>
            {
                entity.ToTable("specific_robots");
            });

            modelBuilder.Entity<SpecificRobotsInRelation>(entity =>
            {
                entity.ToTable("specific_robots_in_relation");

                entity.HasOne(d => d.ContributingfieldsNavigation)
                    .WithMany(p => p.SpecificRobotsInRelation)
                    .HasForeignKey(d => d.Contributingfields)
                    .HasConstraintName("FK__specific___Contr__45BE5BA9");

                entity.HasOne(d => d.DegreeofmaturityNavigation)
                    .WithMany(p => p.SpecificRobotsInRelation)
                    .HasForeignKey(d => d.Degreeofmaturity)
                    .HasConstraintName("FK__specific___Degre__4D5F7D71");

                entity.HasOne(d => d.BranchesNavigation)
                    .WithMany(p => p.SpecificRobotsInRelation)
                    .HasForeignKey(d => d.Branches)
                    .HasConstraintName("FK__specific___Indus__44CA3770");
                entity.HasOne(d => d.BusinessNavigation)
                   .WithMany(p => p.SpecificRobotsInRelation)
                   .HasForeignKey(d => d.Business)
                   .HasConstraintName("FK__specific___Busin__52AE4273");

                entity.HasOne(d => d.InfluentialpeopleNavigation)
                    .WithMany(p => p.SpecificRobotsInRelation)
                    .HasForeignKey(d => d.Influentialpeople)
                    .HasConstraintName("FK__specific___Influ__4C6B5938");

                entity.HasOne(d => d.ModesoflocomotionNavigation)
                    .WithMany(p => p.SpecificRobotsInRelation)
                    .HasForeignKey(d => d.Modesoflocomotion)
                    .HasConstraintName("FK__specific___Modes__43D61337");

                entity.HasOne(d => d.RobotcomponentsanddesignfeaturesNavigation)
                    .WithMany(p => p.SpecificRobotsInRelation)
                    .HasForeignKey(d => d.Robotcomponentsanddesignfeatures)
                    .HasConstraintName("FK__specific___Robot__47A6A41B");

                entity.HasOne(d => d.RoboticscompaniesNavigation)
                    .WithMany(p => p.SpecificRobotsInRelation)
                    .HasForeignKey(d => d.Roboticscompanies)
                    .HasConstraintName("FK__specific___Robot__498EEC8D");

                entity.HasOne(d => d.RoboticscompetitionsNavigation)
                    .WithMany(p => p.SpecificRobotsInRelation)
                    .HasForeignKey(d => d.Roboticscompetitions)
                    .HasConstraintName("FK__specific___Robot__4B7734FF");

                entity.HasOne(d => d.RoboticsdevelopmentanddevelopmenttoolsNavigation)
                    .WithMany(p => p.SpecificRobotsInRelation)
                    .HasForeignKey(d => d.Roboticsdevelopmentanddevelopmenttools)
                    .HasConstraintName("FK__specific___Robot__489AC854");

                entity.HasOne(d => d.RoboticsorganizationsNavigation)
                    .WithMany(p => p.SpecificRobotsInRelation)
                    .HasForeignKey(d => d.Roboticsorganizations)
                    .HasConstraintName("FK__specific___Robot__4A8310C6");

                entity.HasOne(d => d.RoboticsprinciplesNavigation)
                    .WithMany(p => p.SpecificRobotsInRelation)
                    .HasForeignKey(d => d.Roboticsprinciples)
                    .HasConstraintName("FK__specific___Robot__42E1EEFE");

                entity.HasOne(d => d.SpecificrobotsNavigation)
                    .WithMany(p => p.SpecificRobotsInRelation)
                    .HasForeignKey(d => d.Specificrobots)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SpecificRobots_Id"); //FK__specific___Speci__084B3915

                entity.HasOne(d => d.TypesNavigation)
                    .WithMany(p => p.SpecificRobotsInRelation)
                    .HasForeignKey(d => d.Types)
                    .HasConstraintName("FK__specific___Types__46B27FE2");
            });

            modelBuilder.Entity<SpecificRobotsTrans>(entity =>
            {
                entity.ToTable("specific_robots_trans");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.LanguageNavigation)
                    .WithMany(p => p.SpecificRobotsTrans)
                    .HasForeignKey(d => d.Language)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__specific___Langu__2EA5EC27");

                entity.HasOne(d => d.SpecificrobotsNavigation)
                    .WithMany(p => p.SpecificRobotsTrans)
                    .HasForeignKey(d => d.Specificrobots)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__specific___Speci__2F9A1060");
            });

            modelBuilder.Entity<Types>(entity =>
            {
                entity.ToTable("types");
            });

            modelBuilder.Entity<TypesInRelation>(entity =>
            {
                entity.ToTable("types_in_relation");

                entity.HasOne(d => d.ModesoflocomotionNavigation)
                    .WithMany(p => p.TypesInRelation)
                    .HasForeignKey(d => d.Modesoflocomotion)
                    .HasConstraintName("FK__types_in___Modes__075714DC");

                entity.HasOne(d => d.RoboticsprinciplesNavigation)
                    .WithMany(p => p.TypesInRelation)
                    .HasForeignKey(d => d.Roboticsprinciples)
                    .HasConstraintName("FK__types_in___Robot__0662F0A3");

                entity.HasOne(d => d.TypesNavigation)
                    .WithMany(p => p.TypesInRelation)
                    .HasForeignKey(d => d.Types)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__types_in___Types__056ECC6A");
            });

            modelBuilder.Entity<TypesTrans>(entity =>
            {
                entity.ToTable("types_trans");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.LanguageNavigation)
                    .WithMany(p => p.TypesTrans)
                    .HasForeignKey(d => d.Language)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__types_tra__Langu__32767D0B");

                entity.HasOne(d => d.TypesNavigation)
                    .WithMany(p => p.TypesTrans)
                    .HasForeignKey(d => d.Types)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__types_tra__Types__336AA144");
            });

            modelBuilder.Entity<Unpublished>(entity =>
            {
                entity.ToTable("unpublished");

                entity.Property(e => e.Edition).HasMaxLength(50);

                entity.Property(e => e.Firstnameauhor1)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Firstnameauhor2).HasMaxLength(50);

                entity.Property(e => e.Firstnameauhor3).HasMaxLength(50);

                entity.Property(e => e.Furtherauthors).HasMaxLength(50);

                entity.Property(e => e.Lastnameauhor1)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Lastnameauhor2).HasMaxLength(50);

                entity.Property(e => e.Lastnameauhor3).HasMaxLength(50);

                entity.Property(e => e.Pages).HasMaxLength(50);

                entity.Property(e => e.Publicationdate).HasColumnType("date");

                entity.Property(e => e.Schoollocation).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(200);

                entity.Property(e => e.Type).HasMaxLength(100);
            });

            modelBuilder.Entity<Websites>(entity =>
            {
                entity.ToTable("websites");

                entity.Property(e => e.Calldate).HasColumnType("date");

                entity.Property(e => e.Firstname).HasMaxLength(50);

                entity.Property(e => e.Lastname).HasMaxLength(50);

                entity.Property(e => e.Organization).HasMaxLength(200);

                entity.Property(e => e.Publicationdate).HasColumnType("date");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("URL")
                    .HasMaxLength(500);
            });
        }
    }
}