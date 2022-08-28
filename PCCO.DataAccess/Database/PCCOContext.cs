using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PCCO.Models;

namespace PCCO.DataAccess
{
    public partial class PCCOContext : IdentityDbContext
    {
        public PCCOContext(DbContextOptions<PCCOContext> options) : base(options)
        {
        }

        public virtual DbSet<CorruptionRecord> CorruptionRecords { get; set; }
        public virtual DbSet<CrimeInfo> CrimeInfos { get; set; }
        public virtual DbSet<CriminalArticle> CriminalArticles { get; set; }
        public virtual DbSet<IndividualData> IndividualData { get; set; }
        public virtual DbSet<IssuingAuthority> IssuingAuthorities { get; set; }
        public virtual DbSet<LegalEntityData> LegalEntityData { get; set; }
        public virtual DbSet<Pcco> Pccos { get; set; }
        public virtual DbSet<Punishment> Punishments { get; set; }
        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<CorruptionRecord>(entity =>
            {
                entity.HasIndex(e => e.CourtCaseNumber)
                    .IsUnique();

                entity.HasIndex(e => e.CourtSentenceNumber)
                    .IsUnique();
            });

            builder.Entity<CriminalArticle>(entity =>
            {
                entity.HasIndex(e => e.ArticleNumber)
                    .IsUnique();
            });

            builder.Entity<IndividualData>(entity =>
            {
                entity.HasIndex(e => e.Series)
                    .IsUnique();

                entity.HasIndex(e => e.IdentificationCode)
                    .IsUnique();
            });

            builder.Entity<IssuingAuthority>(entity =>
            {
                entity.HasIndex(e => e.Code)
                    .IsUnique();
            });

            builder.Entity<LegalEntityData>(entity =>
            {
                entity.HasIndex(e => e.IdentificationCode)
                    .IsUnique();
            });
        }
    }
}
