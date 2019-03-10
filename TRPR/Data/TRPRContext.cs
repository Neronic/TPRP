using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TRPR.Models;

namespace TRPR.Data
{
    public class TRPRContext : DbContext
    {
        public TRPRContext (DbContextOptions<TRPRContext> options)
            : base(options)
        {
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
        public DbSet<ResearchInstitute> ResearchInstitutes { get; set; }
        public DbSet<ResearchExpertise> ResearchExpertises { get; set; }
        public DbSet<AuthoredPaper> AuthoredPapers { get; set; }
        public DbSet<PaperKeyword> PaperKeywords { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TRPR");


            //Add a unique index to the researchers email
            modelBuilder.Entity<Researcher>()
            .HasIndex(p => p.ResEmail)
            .IsUnique();

            //Many to Many Authored - Paper
            modelBuilder.Entity<AuthoredPaper>()
            .HasKey(t => new { t.ResearcherID, t.PaperInfoID });

            //Many to Many Researcher - Expertise
            modelBuilder.Entity<ResearchExpertise>()
            .HasKey(t => new { t.ResearcherID, t.ExpertiseID });

            //Many to Many Researcher - Institute
            modelBuilder.Entity<ResearchInstitute>()
            .HasKey(t => new { t.ResearcherID, t.InstituteID });

            //Many to Many Paper - Keyword
            modelBuilder.Entity<PaperKeyword>()
            .HasKey(t => new { t.PaperInfoID, t.KeywordID });

            //No Cascade Delete for Author - Paper
            modelBuilder.Entity<AuthoredPaper>()
                .HasOne(pc => pc.Researcher)
                .WithMany(c => c.AuthoredPapers)
                .HasForeignKey(pc => pc.ResearcherID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
