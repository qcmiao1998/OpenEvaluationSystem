﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OpenEvaluation.Data;

namespace OpenEvaluation.Migrations
{
    [DbContext(typeof(EvaluateContext))]
    [Migration("20200416125607_RefactorHomeworkSubmission")]
    partial class RefactorHomeworkSubmission
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OpenEvaluation.Data.Group", b =>
                {
                    b.Property<string>("GroupId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GroupName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GroupId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("OpenEvaluation.Data.Homework", b =>
                {
                    b.Property<string>("HomeworkId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HomeworkName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("HomeworkId");

                    b.HasIndex("OwnerUserId");

                    b.ToTable("Homeworks");
                });

            modelBuilder.Entity("OpenEvaluation.Data.HomeworkScore", b =>
                {
                    b.Property<string>("HomeworkScoreId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("HomeworkSubmissionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SubmitterUserUserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("HomeworkScoreId");

                    b.HasIndex("HomeworkSubmissionId");

                    b.HasIndex("SubmitterUserUserId");

                    b.ToTable("HomeworkScores");
                });

            modelBuilder.Entity("OpenEvaluation.Data.HomeworkScore+SubScore", b =>
                {
                    b.Property<string>("SubScoreId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("HomeworkScoreId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Score")
                        .HasColumnType("float");

                    b.Property<string>("ScoreItemHomeworkScoreItemId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("SubScoreId");

                    b.HasIndex("HomeworkScoreId");

                    b.HasIndex("ScoreItemHomeworkScoreItemId");

                    b.ToTable("SubScore");
                });

            modelBuilder.Entity("OpenEvaluation.Data.HomeworkScoreItem", b =>
                {
                    b.Property<string>("HomeworkScoreItemId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HomeworkId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("MaxScore")
                        .HasColumnType("float");

                    b.Property<double>("MinScore")
                        .HasColumnType("float");

                    b.HasKey("HomeworkScoreItemId");

                    b.HasIndex("HomeworkId");

                    b.ToTable("HomeworkScoreItems");
                });

            modelBuilder.Entity("OpenEvaluation.Data.HomeworkSubmission", b =>
                {
                    b.Property<string>("HomeworkSubmissionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HomeworkId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("SubmitType")
                        .HasColumnType("int");

                    b.Property<string>("SubmitterGroupGroupId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SubmitterUserUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("HomeworkSubmissionId");

                    b.HasIndex("HomeworkId");

                    b.HasIndex("SubmitterGroupGroupId");

                    b.HasIndex("SubmitterUserUserId");

                    b.ToTable("HomeworkSubmits");
                });

            modelBuilder.Entity("OpenEvaluation.Data.User", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GroupId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("GroupId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("OpenEvaluation.Data.Homework", b =>
                {
                    b.HasOne("OpenEvaluation.Data.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerUserId");
                });

            modelBuilder.Entity("OpenEvaluation.Data.HomeworkScore", b =>
                {
                    b.HasOne("OpenEvaluation.Data.HomeworkSubmission", "HomeworkSubmission")
                        .WithMany("Scores")
                        .HasForeignKey("HomeworkSubmissionId");

                    b.HasOne("OpenEvaluation.Data.User", "SubmitterUser")
                        .WithMany()
                        .HasForeignKey("SubmitterUserUserId");
                });

            modelBuilder.Entity("OpenEvaluation.Data.HomeworkScore+SubScore", b =>
                {
                    b.HasOne("OpenEvaluation.Data.HomeworkScore", "HomeworkScore")
                        .WithMany("Scores")
                        .HasForeignKey("HomeworkScoreId");

                    b.HasOne("OpenEvaluation.Data.HomeworkScoreItem", "ScoreItem")
                        .WithMany()
                        .HasForeignKey("ScoreItemHomeworkScoreItemId");
                });

            modelBuilder.Entity("OpenEvaluation.Data.HomeworkScoreItem", b =>
                {
                    b.HasOne("OpenEvaluation.Data.Homework", "Homework")
                        .WithMany("ScoreItems")
                        .HasForeignKey("HomeworkId");
                });

            modelBuilder.Entity("OpenEvaluation.Data.HomeworkSubmission", b =>
                {
                    b.HasOne("OpenEvaluation.Data.Homework", "Homework")
                        .WithMany("Submits")
                        .HasForeignKey("HomeworkId");

                    b.HasOne("OpenEvaluation.Data.Group", "SubmitterGroup")
                        .WithMany()
                        .HasForeignKey("SubmitterGroupGroupId");

                    b.HasOne("OpenEvaluation.Data.User", "SubmitterUser")
                        .WithMany()
                        .HasForeignKey("SubmitterUserUserId");
                });

            modelBuilder.Entity("OpenEvaluation.Data.User", b =>
                {
                    b.HasOne("OpenEvaluation.Data.Group", "Group")
                        .WithMany("Users")
                        .HasForeignKey("GroupId");
                });
#pragma warning restore 612, 618
        }
    }
}
