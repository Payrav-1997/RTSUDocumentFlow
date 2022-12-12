﻿// <auto-generated />
using System;
using DocumentFlow.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DocumentFlow.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221212150056_feat: statuses")]
    partial class featstatuses
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DocumentFlow.Models.Agreement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("AgreementDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Descrioption")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("DocumentId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ExecutorId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("DocumentId");

                    b.HasIndex("ExecutorId");

                    b.ToTable("Agreements");
                });

            modelBuilder.Entity("DocumentFlow.Models.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"),
                            CreatedAt = new DateTime(2022, 12, 12, 15, 0, 56, 277, DateTimeKind.Utc).AddTicks(6064),
                            Name = "Test"
                        });
                });

            modelBuilder.Entity("DocumentFlow.Models.Document", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Correspondent")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CorrespondentNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("CreatedAtCorrespondent")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("DocumentNumber")
                        .HasColumnType("integer");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer");

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("DocumentFlow.Models.Executor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Code")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateOfOrder")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("DocumentId")
                        .HasColumnType("uuid");

                    b.Property<string>("ExecutionTime")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ExecutorRole")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("DocumentId");

                    b.HasIndex("StatusId");

                    b.HasIndex("UserId");

                    b.ToTable("Executors");
                });

            modelBuilder.Entity("DocumentFlow.Models.Notion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Notions");
                });

            modelBuilder.Entity("DocumentFlow.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Админ"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Сотрудник"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Исполниель"
                        });
                });

            modelBuilder.Entity("DocumentFlow.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Новый"
                        },
                        new
                        {
                            Id = 2,
                            Name = "В процессе"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Отказано"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Одобренно"
                        });
                });

            modelBuilder.Entity("DocumentFlow.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("DepartmentId")
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("61ba371d-3228-410b-bb99-ed9430a6ab42"),
                            Address = "Test",
                            CreatedAt = new DateTime(2022, 12, 12, 15, 0, 56, 358, DateTimeKind.Utc).AddTicks(8295),
                            DepartmentId = new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"),
                            Email = "Admin@gmail.com",
                            Logo = "user/638061145023499962thumb_1559_600_480_0_0_auto.jpg",
                            Name = "Админ",
                            Password = "$2b$10$ZrT8SU/Hrp2FtE7XlpeDG.jVSyj2VTGSroLLwHHM3HdO0fbck1GJC",
                            Phone = "+992915224442",
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("DocumentFlow.Models.Agreement", b =>
                {
                    b.HasOne("DocumentFlow.Models.Document", "Document")
                        .WithMany("Agreements")
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DocumentFlow.Models.Executor", "Executor")
                        .WithMany()
                        .HasForeignKey("ExecutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Document");

                    b.Navigation("Executor");
                });

            modelBuilder.Entity("DocumentFlow.Models.Document", b =>
                {
                    b.HasOne("DocumentFlow.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("DocumentFlow.Models.Executor", b =>
                {
                    b.HasOne("DocumentFlow.Models.Document", "Document")
                        .WithMany("Executors")
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DocumentFlow.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DocumentFlow.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Document");

                    b.Navigation("Status");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DocumentFlow.Models.User", b =>
                {
                    b.HasOne("DocumentFlow.Models.Department", "Department")
                        .WithMany("Users")
                        .HasForeignKey("DepartmentId");

                    b.HasOne("DocumentFlow.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("DocumentFlow.Models.Department", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("DocumentFlow.Models.Document", b =>
                {
                    b.Navigation("Agreements");

                    b.Navigation("Executors");
                });
#pragma warning restore 612, 618
        }
    }
}
