﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TRPR.Data;

namespace TRPR.Data.TRPRMigrations
{
    [DbContext(typeof(TRPRContext))]
    [Migration("20190308215840_authorPaperManyToMany")]
    partial class authorPaperManyToMany
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("TRPR")
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TRPR.Models.AuthoredPaper", b =>
                {
                    b.Property<int>("ResID");

                    b.Property<int>("PaperID");

                    b.Property<string>("AuthPapLevel");

                    b.Property<int?>("PaperInfoID");

                    b.HasKey("ResID", "PaperID");

                    b.HasIndex("PaperInfoID");

                    b.ToTable("AuthoredPapers");
                });

            modelBuilder.Entity("TRPR.Models.Comment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ComAccess")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Comtext")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("CreatedOn");

                    b.Property<int>("RevID");

                    b.Property<int?>("ReviewAssignID");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("UpdatedOn");

                    b.HasKey("ID");

                    b.HasIndex("ReviewAssignID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("TRPR.Models.Expertise", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ExpName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("ID");

                    b.ToTable("Expertises");
                });

            modelBuilder.Entity("TRPR.Models.File", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("CreatedOn");

                    b.Property<byte[]>("FileContent");

                    b.Property<string>("FileMimeType")
                        .HasMaxLength(256);

                    b.Property<string>("FileName")
                        .IsRequired();

                    b.Property<int?>("FileTypeID");

                    b.Property<int>("TypeID");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("UpdatedOn");

                    b.HasKey("ID");

                    b.HasIndex("FileTypeID");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("TRPR.Models.FileType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("FileTypes");
                });

            modelBuilder.Entity("TRPR.Models.Institute", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("InstName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("ID");

                    b.ToTable("Institutes");
                });

            modelBuilder.Entity("TRPR.Models.Keyword", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("KeyWord")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("ID");

                    b.ToTable("Keywords");
                });

            modelBuilder.Entity("TRPR.Models.PaperFile", b =>
                {
                    b.Property<int>("PaperID");

                    b.Property<int>("FileID");

                    b.Property<int?>("PaperInfoID");

                    b.HasKey("PaperID", "FileID");

                    b.HasIndex("FileID");

                    b.HasIndex("PaperInfoID");

                    b.ToTable("PaperFiles");
                });

            modelBuilder.Entity("TRPR.Models.PaperInfo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PaperAbstract")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<int>("PaperLength");

                    b.Property<string>("PaperTitle")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("PaperType")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<int>("StatID");

                    b.Property<int?>("StatusID");

                    b.HasKey("ID");

                    b.HasIndex("StatusID");

                    b.ToTable("PaperInfos");
                });

            modelBuilder.Entity("TRPR.Models.PaperKeyword", b =>
                {
                    b.Property<int>("PaperID");

                    b.Property<int>("KeyID");

                    b.Property<int?>("KeywordID");

                    b.Property<int?>("PaperInfoID");

                    b.HasKey("PaperID", "KeyID");

                    b.HasIndex("KeywordID");

                    b.HasIndex("PaperInfoID");

                    b.ToTable("PaperKeywords");
                });

            modelBuilder.Entity("TRPR.Models.Recommend", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RecTitle")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("ID");

                    b.ToTable("Recommends");
                });

            modelBuilder.Entity("TRPR.Models.Researcher", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ResBio")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("ResEmail")
                        .IsRequired()
                        .HasMaxLength(320);

                    b.Property<string>("ResFirst")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("ResLast")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("ResMiddle")
                        .HasMaxLength(50);

                    b.Property<string>("ResTitle")
                        .HasMaxLength(10);

                    b.HasKey("ID");

                    b.HasIndex("ResEmail")
                        .IsUnique();

                    b.ToTable("Researchers");
                });

            modelBuilder.Entity("TRPR.Models.ResearchExpertise", b =>
                {
                    b.Property<int>("ResID");

                    b.Property<int>("ExpID");

                    b.Property<int?>("ExpertiseID");

                    b.Property<int?>("ResearcherID");

                    b.HasKey("ResID", "ExpID");

                    b.HasIndex("ExpertiseID");

                    b.HasIndex("ResearcherID");

                    b.ToTable("ResearchExpertises");
                });

            modelBuilder.Entity("TRPR.Models.ResearchInstitute", b =>
                {
                    b.Property<int>("ResID");

                    b.Property<int>("InstID");

                    b.Property<int?>("InstituteID");

                    b.Property<DateTime?>("ResInstEndDate");

                    b.Property<DateTime?>("ResInstStartDate");

                    b.Property<int?>("ResearcherID");

                    b.HasKey("ResID", "InstID");

                    b.HasIndex("InstituteID");

                    b.HasIndex("ResearcherID");

                    b.ToTable("ResearchInstitutes");
                });

            modelBuilder.Entity("TRPR.Models.ReviewAgain", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ReSponse");

                    b.HasKey("ID");

                    b.ToTable("ReviewAgains");
                });

            modelBuilder.Entity("TRPR.Models.ReviewAssign", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PaperID");

                    b.Property<int?>("PaperInfoID");

                    b.Property<int>("ReRevID");

                    b.Property<int>("RecID");

                    b.Property<int?>("RecommendID");

                    b.Property<int>("ResID");

                    b.Property<int?>("ResearcherID");

                    b.Property<string>("RevCitationReview");

                    b.Property<string>("RevContentReview");

                    b.Property<string>("RevFormatReview");

                    b.Property<string>("RevKeywordReview");

                    b.Property<string>("RevLengthReview");

                    b.Property<int?>("ReviewAgainID");

                    b.Property<int>("RoleID");

                    b.HasKey("ID");

                    b.HasIndex("PaperInfoID");

                    b.HasIndex("RecommendID");

                    b.HasIndex("ResearcherID");

                    b.HasIndex("ReviewAgainID");

                    b.HasIndex("RoleID");

                    b.ToTable("ReviewAssigns");
                });

            modelBuilder.Entity("TRPR.Models.ReviewFile", b =>
                {
                    b.Property<int>("RevID");

                    b.Property<int>("FileID");

                    b.Property<int?>("ReviewAssignID");

                    b.HasKey("RevID", "FileID");

                    b.HasIndex("FileID");

                    b.HasIndex("ReviewAssignID");

                    b.ToTable("ReviewFiles");
                });

            modelBuilder.Entity("TRPR.Models.Role", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleTitle")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("ID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("TRPR.Models.Status", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StatName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("ID");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("TRPR.Models.AuthoredPaper", b =>
                {
                    b.HasOne("TRPR.Models.PaperInfo", "PaperInfo")
                        .WithMany("AuthoredPapers")
                        .HasForeignKey("PaperInfoID");

                    b.HasOne("TRPR.Models.Researcher", "Researcher")
                        .WithMany("AuthoredPapers")
                        .HasForeignKey("ResID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("TRPR.Models.Comment", b =>
                {
                    b.HasOne("TRPR.Models.ReviewAssign", "ReviewAssign")
                        .WithMany()
                        .HasForeignKey("ReviewAssignID");
                });

            modelBuilder.Entity("TRPR.Models.File", b =>
                {
                    b.HasOne("TRPR.Models.FileType", "FileType")
                        .WithMany()
                        .HasForeignKey("FileTypeID");
                });

            modelBuilder.Entity("TRPR.Models.PaperFile", b =>
                {
                    b.HasOne("TRPR.Models.File", "File")
                        .WithMany()
                        .HasForeignKey("FileID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TRPR.Models.PaperInfo", "PaperInfo")
                        .WithMany("PaperFiles")
                        .HasForeignKey("PaperInfoID");
                });

            modelBuilder.Entity("TRPR.Models.PaperInfo", b =>
                {
                    b.HasOne("TRPR.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusID");
                });

            modelBuilder.Entity("TRPR.Models.PaperKeyword", b =>
                {
                    b.HasOne("TRPR.Models.Keyword", "Keyword")
                        .WithMany("PaperKeywords")
                        .HasForeignKey("KeywordID");

                    b.HasOne("TRPR.Models.PaperInfo", "PaperInfo")
                        .WithMany("PaperKeywords")
                        .HasForeignKey("PaperInfoID");
                });

            modelBuilder.Entity("TRPR.Models.ResearchExpertise", b =>
                {
                    b.HasOne("TRPR.Models.Expertise", "Expertise")
                        .WithMany("ResearchExpertises")
                        .HasForeignKey("ExpertiseID");

                    b.HasOne("TRPR.Models.Researcher", "Researcher")
                        .WithMany("ResearchExpertises")
                        .HasForeignKey("ResearcherID");
                });

            modelBuilder.Entity("TRPR.Models.ResearchInstitute", b =>
                {
                    b.HasOne("TRPR.Models.Institute", "Institute")
                        .WithMany("ResearchInstitutes")
                        .HasForeignKey("InstituteID");

                    b.HasOne("TRPR.Models.Researcher", "Researcher")
                        .WithMany("ResearchInstitutes")
                        .HasForeignKey("ResearcherID");
                });

            modelBuilder.Entity("TRPR.Models.ReviewAssign", b =>
                {
                    b.HasOne("TRPR.Models.PaperInfo", "PaperInfo")
                        .WithMany()
                        .HasForeignKey("PaperInfoID");

                    b.HasOne("TRPR.Models.Recommend", "Recommend")
                        .WithMany()
                        .HasForeignKey("RecommendID");

                    b.HasOne("TRPR.Models.Researcher", "Researcher")
                        .WithMany("ReviewAssigns")
                        .HasForeignKey("ResearcherID");

                    b.HasOne("TRPR.Models.ReviewAgain", "ReviewAgain")
                        .WithMany()
                        .HasForeignKey("ReviewAgainID");

                    b.HasOne("TRPR.Models.Role", "Roles")
                        .WithMany()
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TRPR.Models.ReviewFile", b =>
                {
                    b.HasOne("TRPR.Models.File", "File")
                        .WithMany()
                        .HasForeignKey("FileID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TRPR.Models.ReviewAssign", "ReviewAssign")
                        .WithMany("ReviewFiles")
                        .HasForeignKey("ReviewAssignID");
                });
#pragma warning restore 612, 618
        }
    }
}
