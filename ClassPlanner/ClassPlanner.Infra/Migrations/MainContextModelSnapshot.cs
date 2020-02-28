﻿// <auto-generated />
using System;
using ClassPlanner.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClassPlanner.Infra.Migrations
{
    [DbContext(typeof(MainContext))]
    partial class MainContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ClassPlanner.Domain.Entities.EnrolledStudent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active")
                        .HasColumnName("Active");

                    b.Property<DateTime>("AlterationDate")
                        .HasColumnName("AlterationDate");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnName("CreationDate");

                    b.Property<int>("RegistrationId");

                    b.Property<Guid>("StudentId")
                        .HasColumnName("StudentId");

                    b.Property<Guid>("StudentsClassId");

                    b.Property<double>("Value")
                        .HasColumnName("Value");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("StudentsClassId");

                    b.ToTable("EnrolledStudent");
                });

            modelBuilder.Entity("ClassPlanner.Domain.Entities.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active")
                        .HasColumnName("Active");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnName("Address");

                    b.Property<DateTime>("AlterationDate")
                        .HasColumnName("AlterationDate");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnName("CPF");

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasColumnName("Contact");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnName("CreationDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name");

                    b.Property<bool>("PrivateStudent")
                        .HasColumnName("PrivateStudent");

                    b.HasKey("Id");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("ClassPlanner.Domain.Entities.StudentsClass", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active")
                        .HasColumnName("Active");

                    b.Property<DateTime>("AlterationDate")
                        .HasColumnName("AlterationDate");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnName("CreationDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("StudentsClass");
                });

            modelBuilder.Entity("ClassPlanner.Domain.Entities.Teacher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active")
                        .HasColumnName("Active");

                    b.Property<DateTime>("AlterationDate")
                        .HasColumnName("AlterationDate");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnName("CPF");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnName("CreationDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("ClassPlanner.Domain.Entities.TeacherInCharge", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active")
                        .HasColumnName("Active");

                    b.Property<DateTime>("AlterationDate")
                        .HasColumnName("AlterationDate");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnName("CreationDate");

                    b.Property<Guid>("StudentsClassId");

                    b.Property<Guid>("TeacherId")
                        .HasColumnName("TeacherId");

                    b.HasKey("Id");

                    b.HasIndex("StudentsClassId");

                    b.HasIndex("TeacherId");

                    b.ToTable("TeacherInCharge");
                });

            modelBuilder.Entity("ClassPlanner.Domain.Entities.EnrolledStudent", b =>
                {
                    b.HasOne("ClassPlanner.Domain.Entities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ClassPlanner.Domain.Entities.StudentsClass", "StudentsClass")
                        .WithMany("EnrolledStudents")
                        .HasForeignKey("StudentsClassId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ClassPlanner.Domain.Entities.TeacherInCharge", b =>
                {
                    b.HasOne("ClassPlanner.Domain.Entities.StudentsClass", "StudentsClass")
                        .WithMany()
                        .HasForeignKey("StudentsClassId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ClassPlanner.Domain.Entities.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
