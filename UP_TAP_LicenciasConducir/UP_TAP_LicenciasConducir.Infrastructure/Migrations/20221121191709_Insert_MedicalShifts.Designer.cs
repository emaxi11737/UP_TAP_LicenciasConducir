﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UP_TAP_LicenciasConducir.Infrastructure.Data;

#nullable disable

namespace UP_TAP_LicenciasConducir.Infrastructure.Migrations
{
    [DbContext(typeof(LicenciasConducirDataContext))]
    [Migration("20221121191709_Insert_MedicalShifts")]
    partial class Insert_MedicalShifts
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("UP_TAP_LicenciasConducir.Core.Entities.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsRight")
                        .HasColumnType("bit");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answer");
                });

            modelBuilder.Entity("UP_TAP_LicenciasConducir.Core.Entities.Exam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("UseGlasses")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("UP_TAP_LicenciasConducir.Core.Entities.Intermediates.QuizQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AnswerId")
                        .HasColumnType("int");

                    b.Property<int>("QuizId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnswerId");

                    b.HasIndex("QuizId");

                    b.ToTable("QuizQuestion");
                });

            modelBuilder.Entity("UP_TAP_LicenciasConducir.Core.Entities.MedicalRevision", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ExamId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsPassed")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ExamId")
                        .IsUnique();

                    b.ToTable("MedicalRevisions");
                });

            modelBuilder.Entity("UP_TAP_LicenciasConducir.Core.Entities.MedicalShift", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MedicalRevisionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MedicalRevisionId")
                        .IsUnique()
                        .HasFilter("[MedicalRevisionId] IS NOT NULL");

                    b.ToTable("MedicalShifts");
                });

            modelBuilder.Entity("UP_TAP_LicenciasConducir.Core.Entities.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("UP_TAP_LicenciasConducir.Core.Entities.Quiz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AccessPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ExamId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PasswordExpirationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ExamId")
                        .IsUnique();

                    b.ToTable("Quiz");
                });

            modelBuilder.Entity("UP_TAP_LicenciasConducir.Core.Entities.Result", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ExamId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ResultDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("UP_TAP_LicenciasConducir.Core.Entities.Security", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Securities");
                });

            modelBuilder.Entity("UP_TAP_LicenciasConducir.Core.Entities.Answer", b =>
                {
                    b.HasOne("UP_TAP_LicenciasConducir.Core.Entities.Question", "Question")
                        .WithMany("Answer")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("UP_TAP_LicenciasConducir.Core.Entities.Exam", b =>
                {
                    b.HasOne("UP_TAP_LicenciasConducir.Core.Entities.Security", "User")
                        .WithMany("Exams")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("UP_TAP_LicenciasConducir.Core.Entities.Intermediates.QuizQuestion", b =>
                {
                    b.HasOne("UP_TAP_LicenciasConducir.Core.Entities.Answer", "Answer")
                        .WithMany("QuizQuestions")
                        .HasForeignKey("AnswerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UP_TAP_LicenciasConducir.Core.Entities.Quiz", "Quiz")
                        .WithMany("QuizQuestions")
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Answer");

                    b.Navigation("Quiz");
                });

            modelBuilder.Entity("UP_TAP_LicenciasConducir.Core.Entities.MedicalRevision", b =>
                {
                    b.HasOne("UP_TAP_LicenciasConducir.Core.Entities.Exam", "Exam")
                        .WithOne("MedicalRevision")
                        .HasForeignKey("UP_TAP_LicenciasConducir.Core.Entities.MedicalRevision", "ExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exam");
                });

            modelBuilder.Entity("UP_TAP_LicenciasConducir.Core.Entities.MedicalShift", b =>
                {
                    b.HasOne("UP_TAP_LicenciasConducir.Core.Entities.MedicalRevision", "MedicalRevision")
                        .WithOne("MedicalShift")
                        .HasForeignKey("UP_TAP_LicenciasConducir.Core.Entities.MedicalShift", "MedicalRevisionId");

                    b.Navigation("MedicalRevision");
                });

            modelBuilder.Entity("UP_TAP_LicenciasConducir.Core.Entities.Quiz", b =>
                {
                    b.HasOne("UP_TAP_LicenciasConducir.Core.Entities.Exam", "Exam")
                        .WithOne("Quiz")
                        .HasForeignKey("UP_TAP_LicenciasConducir.Core.Entities.Quiz", "ExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exam");
                });

            modelBuilder.Entity("UP_TAP_LicenciasConducir.Core.Entities.Result", b =>
                {
                    b.HasOne("UP_TAP_LicenciasConducir.Core.Entities.Exam", "Exam")
                        .WithMany()
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exam");
                });

            modelBuilder.Entity("UP_TAP_LicenciasConducir.Core.Entities.Answer", b =>
                {
                    b.Navigation("QuizQuestions");
                });

            modelBuilder.Entity("UP_TAP_LicenciasConducir.Core.Entities.Exam", b =>
                {
                    b.Navigation("MedicalRevision")
                        .IsRequired();

                    b.Navigation("Quiz")
                        .IsRequired();
                });

            modelBuilder.Entity("UP_TAP_LicenciasConducir.Core.Entities.MedicalRevision", b =>
                {
                    b.Navigation("MedicalShift")
                        .IsRequired();
                });

            modelBuilder.Entity("UP_TAP_LicenciasConducir.Core.Entities.Question", b =>
                {
                    b.Navigation("Answer");
                });

            modelBuilder.Entity("UP_TAP_LicenciasConducir.Core.Entities.Quiz", b =>
                {
                    b.Navigation("QuizQuestions");
                });

            modelBuilder.Entity("UP_TAP_LicenciasConducir.Core.Entities.Security", b =>
                {
                    b.Navigation("Exams");
                });
#pragma warning restore 612, 618
        }
    }
}
