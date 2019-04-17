using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using TRPR.Models;

namespace TRPR.Data
{
    public class TRPRContext : DbContext
    {
        public TRPRContext (DbContextOptions<TRPRContext> options)
            : base(options)
        {
            UserName = "SeedData";
        }

        public TRPRContext(DbContextOptions<TRPRContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
            UserName = _httpContextAccessor.HttpContext?.User.Identity.Name;
            //UserName = (UserName == null) ? "Unknown" : UserName;
            UserName = UserName ?? "Unknown";
        }

        //To give access to IHttpContextAccessor for Audit Data with IAuditable
        private readonly IHttpContextAccessor _httpContextAccessor;

        //Property to hold the UserName value
        public string UserName
        {
            get; private set;
        }

        public DbSet<File> Files { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Expertise> Expertises { get; set; }
        public DbSet<FileType> FileTypes { get; set; }
        public DbSet<Institute> Institutes { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
        public DbSet<PaperInfo> PaperInfos { get; set; }
        public DbSet<Recommend> Recommends { get; set; }
        public DbSet<Researcher> Researchers { get; set; }
        public DbSet<ReviewAgain> ReviewAgains { get; set; }
        public DbSet<ReviewAssign> ReviewAssigns { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<ResearchExpertise> ResearchExpertises { get; set; }
        public DbSet<AuthoredPaper> AuthoredPapers { get; set; }
        public DbSet<PaperKeyword> PaperKeywords { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<PaperType> PaperTypes { get; set; }
        public DbSet<Sub> Subs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TRPR");

            

            //Add a unique index to the researchers email
            modelBuilder.Entity<Researcher>()
            .HasIndex(a => new { a.ResEmail })
            .IsUnique();

            //Many to Many Researcher - Expertise
            modelBuilder.Entity<ResearchExpertise>()
            .HasKey(t => new { t.ResearcherID, t.ExpertiseID });

            //Many to Many Paper - Keyword
            modelBuilder.Entity<PaperKeyword>()
            .HasKey(t => new { t.PaperInfoID, t.KeywordID });

            //Many to Many Researcher - Institute
            modelBuilder.Entity<AuthoredPaper>()
            .HasKey(t => new { t.ResearcherID, t.PaperInfoID });

            //No Cascade Delete for Author - Paper
            modelBuilder.Entity<AuthoredPaper>()
                .HasOne(pc => pc.Researcher)
                .WithMany(c => c.AuthoredPapers)
                .HasForeignKey(pc => pc.ResearcherID)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                if (entry.Entity is IAuditable trackable)
                {
                    var now = DateTime.UtcNow;
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            trackable.UpdatedOn = now;
                            trackable.UpdatedBy = UserName;
                            break;

                        case EntityState.Added:
                            trackable.CreatedOn = now;
                            trackable.CreatedBy = UserName;
                            trackable.UpdatedOn = now;
                            trackable.UpdatedBy = UserName;
                            break;
                    }
                }
            }
        }
    }
}
