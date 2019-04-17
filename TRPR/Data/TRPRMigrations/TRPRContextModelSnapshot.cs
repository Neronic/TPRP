﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TRPR.Data;

namespace TRPR.Data.TRPRMigrations
{
    [DbContext(typeof(TRPRContext))]
    partial class TRPRContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("TRPR")
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TRPR.Models.AuthoredPaper", b =>
                {
                    b.Property<int>("ResearcherID");

                    b.Property<int>("PaperInfoID");

                    b.Property<string>("AuthPapLevel");

                    b.HasKey("ResearcherID", "PaperInfoID");

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

                    b.Property<int>("ResearcherID");

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

                    b.Property<int?>("PaperInfoID");

                    b.Property<int?>("ReveiwAssignID");

                    b.Property<int?>("ReviewAssignID");

                    b.Property<int?>("TypeID");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("UpdatedOn");

                    b.HasKey("ID");

                    b.HasIndex("FileTypeID");

                    b.HasIndex("PaperInfoID");

                    b.HasIndex("ReviewAssignID");

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

            modelBuilder.Entity("TRPR.Models.PaperInfo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("CreatedOn");

                    b.Property<string>("PaperAbstract")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<int>("PaperLength");

                    b.Property<string>("PaperTitle")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int>("PaperTypeID");

                    b.Property<int>("StatusID");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("UpdatedOn");

                    b.HasKey("ID");

                    b.HasIndex("PaperTypeID");

                    b.HasIndex("StatusID");

                    b.ToTable("PaperInfos");
                });

            modelBuilder.Entity("TRPR.Models.PaperKeyword", b =>
                {
                    b.Property<int>("PaperInfoID");

                    b.Property<int>("KeywordID");

                    b.HasKey("PaperInfoID", "KeywordID");

                    b.HasIndex("KeywordID");

                    b.ToTable("PaperKeywords");
                });

            modelBuilder.Entity("TRPR.Models.PaperType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("ID");

                    b.ToTable("PaperTypes");
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

                    b.Property<bool>("Active");

                    b.Property<int>("InstituteID");

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

                    b.Property<int>("TitleID");

                    b.HasKey("ID");

                    b.HasIndex("InstituteID");

                    b.HasIndex("ResEmail")
                        .IsUnique();

                    b.HasIndex("TitleID");

                    b.ToTable("Researchers");
                });

            modelBuilder.Entity("TRPR.Models.ResearchExpertise", b =>
                {
                    b.Property<int>("ResearcherID");

                    b.Property<int>("ExpertiseID");

                    b.HasKey("ResearcherID", "ExpertiseID");

                    b.HasIndex("ExpertiseID");

                    b.ToTable("ResearchExpertises");
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

                    b.Property<string>("AuthorComment");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("CreatedOn");

                    b.Property<string>("EiCComment");

                    b.Property<int>("PaperInfoID");

                    b.Property<int?>("RecommendID");

                    b.Property<int>("ResearcherID");

                    b.Property<string>("RevCitationReview");

                    b.Property<string>("RevContentReview");

                    b.Property<string>("RevFormatReview");

                    b.Property<string>("RevKeywordReview");

                    b.Property<string>("RevLengthReview");

                    b.Property<int?>("ReviewAgainID");

                    b.Property<int>("RoleID");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("UpdatedOn");

                    b.HasKey("ID");

                    b.HasIndex("PaperInfoID");

                    b.HasIndex("RecommendID");

                    b.HasIndex("ResearcherID");

                    b.HasIndex("ReviewAgainID");

                    b.HasIndex("RoleID");

                    b.ToTable("ReviewAssigns");
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

            modelBuilder.Entity("TRPR.Models.Sub", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(127);

                    b.Property<string>("PushAuth")
                        .HasMaxLength(512);

                    b.Property<string>("PushEndpoint")
                        .HasMaxLength(512);

                    b.Property<string>("PushP256DH")
                        .HasMaxLength(512);

                    b.Property<int?>("ResearcherID");

                    b.HasKey("Id");

                    b.HasIndex("ResearcherID");

                    b.ToTable("Subs");
                });

            modelBuilder.Entity("TRPR.Models.Title", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.HasKey("ID");

                    b.ToTable("Titles");
                });

            modelBuilder.Entity("TRPR.Models.AuthoredPaper", b =>
                {
                    b.HasOne("TRPR.Models.PaperInfo", "PaperInfo")
                        .WithMany("AuthoredPapers")
                        .HasForeignKey("PaperInfoID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TRPR.Models.Researcher", "Researcher")
                        .WithMany("AuthoredPapers")
                        .HasForeignKey("ResearcherID")
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

                    b.HasOne("TRPR.Models.PaperInfo", "PaperInfo")
                        .WithMany("Files")
                        .HasForeignKey("PaperInfoID");

                    b.HasOne("TRPR.Models.ReviewAssign", "ReviewAssign")
                        .WithMany("Files")
                        .HasForeignKey("ReviewAssignID");
                });

            modelBuilder.Entity("TRPR.Models.PaperInfo", b =>
                {
                    b.HasOne("TRPR.Models.PaperType", "PaperType")
                        .WithMany("PaperInfos")
                        .HasForeignKey("PaperTypeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TRPR.Models.Status", "Status")
                        .WithMany("PaperInfos")
                        .HasForeignKey("StatusID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TRPR.Models.PaperKeyword", b =>
                {
                    b.HasOne("TRPR.Models.Keyword", "Keyword")
                        .WithMany("PaperKeywords")
                        .HasForeignKey("KeywordID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TRPR.Models.PaperInfo", "PaperInfo")
                        .WithMany("PaperKeywords")
                        .HasForeignKey("PaperInfoID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TRPR.Models.Researcher", b =>
                {
                    b.HasOne("TRPR.Models.Institute", "Institutes")
                        .WithMany("Researchers")
                        .HasForeignKey("InstituteID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TRPR.Models.Title", "Title")
                        .WithMany("Researchers")
                        .HasForeignKey("TitleID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TRPR.Models.ResearchExpertise", b =>
                {
                    b.HasOne("TRPR.Models.Expertise", "Expertise")
                        .WithMany("ResearchExpertises")
                        .HasForeignKey("ExpertiseID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TRPR.Models.Researcher", "Researcher")
                        .WithMany("ResearchExpertises")
                        .HasForeignKey("ResearcherID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TRPR.Models.ReviewAssign", b =>
                {
                    b.HasOne("TRPR.Models.PaperInfo", "PaperInfo")
                        .WithMany("ReviewAssigns")
                        .HasForeignKey("PaperInfoID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TRPR.Models.Recommend", "Recommend")
                        .WithMany()
                        .HasForeignKey("RecommendID");

                    b.HasOne("TRPR.Models.Researcher", "Researcher")
                        .WithMany("ReviewAssigns")
                        .HasForeignKey("ResearcherID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TRPR.Models.ReviewAgain", "ReviewAgain")
                        .WithMany()
                        .HasForeignKey("ReviewAgainID");

                    b.HasOne("TRPR.Models.Role", "Roles")
                        .WithMany()
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TRPR.Models.Sub", b =>
                {
                    b.HasOne("TRPR.Models.Researcher", "researcher")
                        .WithMany("Subs")
                        .HasForeignKey("ResearcherID");
                });
#pragma warning restore 612, 618
        }
    }
}
