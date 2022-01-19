﻿// <auto-generated />
using System;
using Cristea_Anamaria_Proiect.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cristea_Anamaria_Proiect.Migrations
{
    [DbContext(typeof(Cristea_Anamaria_ProiectContext))]
    partial class Cristea_Anamaria_ProiectContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cristea_Anamaria_Proiect.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MedicalStaffId1")
                        .HasColumnType("int");

                    b.Property<int?>("PatientId1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MedicalStaffId1");

                    b.HasIndex("PatientId1");

                    b.ToTable("Appointment");
                });

            modelBuilder.Entity("Cristea_Anamaria_Proiect.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountyId")
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountyId");

                    b.ToTable("City");
                });

            modelBuilder.Entity("Cristea_Anamaria_Proiect.Models.County", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("County");
                });

            modelBuilder.Entity("Cristea_Anamaria_Proiect.Models.MedicalStaff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ConsultationRoomId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Specialisation")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("ConsultationRoomId");

                    b.ToTable("MedicalStaff");
                });

            modelBuilder.Entity("Cristea_Anamaria_Proiect.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AssignedDoctorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CNP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AssignedDoctorId");

                    b.HasIndex("CityId");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("Cristea_Anamaria_Proiect.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("Cristea_Anamaria_Proiect.Models.Appointment", b =>
                {
                    b.HasOne("Cristea_Anamaria_Proiect.Models.MedicalStaff", "MedicalStaff")
                        .WithMany()
                        .HasForeignKey("MedicalStaffId1");

                    b.HasOne("Cristea_Anamaria_Proiect.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId1");

                    b.Navigation("MedicalStaff");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Cristea_Anamaria_Proiect.Models.City", b =>
                {
                    b.HasOne("Cristea_Anamaria_Proiect.Models.County", "County")
                        .WithMany()
                        .HasForeignKey("CountyId");

                    b.Navigation("County");
                });

            modelBuilder.Entity("Cristea_Anamaria_Proiect.Models.MedicalStaff", b =>
                {
                    b.HasOne("Cristea_Anamaria_Proiect.Models.Room", "ConsultationRoom")
                        .WithMany()
                        .HasForeignKey("ConsultationRoomId");

                    b.Navigation("ConsultationRoom");
                });

            modelBuilder.Entity("Cristea_Anamaria_Proiect.Models.Patient", b =>
                {
                    b.HasOne("Cristea_Anamaria_Proiect.Models.MedicalStaff", "AssignedDoctor")
                        .WithMany()
                        .HasForeignKey("AssignedDoctorId");

                    b.HasOne("Cristea_Anamaria_Proiect.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.Navigation("AssignedDoctor");

                    b.Navigation("City");
                });
#pragma warning restore 612, 618
        }
    }
}
