﻿// <auto-generated />
using System;
using IMS.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IMS.Infrastructure.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20240903181501_Table fields modified")]
    partial class Tablefieldsmodified
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IMS.Application.Model.Equipment", b =>
                {
                    b.Property<int>("EquipmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EquipmentId"));

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("LabId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("MaintenanceInterval")
                        .HasColumnType("datetime2");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specification")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EquipmentId");

                    b.HasIndex("LabId");

                    b.ToTable("equipments");
                });

            modelBuilder.Entity("IMS.Application.Model.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemId"));

                    b.Property<int>("EquipmentId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ItemId");

                    b.HasIndex("EquipmentId");

                    b.ToTable("items");
                });

            modelBuilder.Entity("IMS.Application.Model.ItemReservation", b =>
                {
                    b.Property<int>("ItemReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemReservationId"));

                    b.Property<DateTime?>("BorrowedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CancelledAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EquipmentId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("ItemId")
                        .HasColumnType("int");

                    b.Property<int?>("LentClerkId")
                        .HasColumnType("int");

                    b.Property<int>("ReservedUserId")
                        .HasColumnType("int");

                    b.Property<int?>("RespondedClerkId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ResponedAtAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ResponseNote")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ReturnAcceptedClerkId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReturnedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ItemReservationId");

                    b.HasIndex("EquipmentId");

                    b.HasIndex("ItemId");

                    b.HasIndex("LentClerkId");

                    b.HasIndex("ReservedUserId");

                    b.HasIndex("RespondedClerkId");

                    b.HasIndex("ReturnAcceptedClerkId");

                    b.ToTable("itemReservations");
                });

            modelBuilder.Entity("IMS.Application.Model.Lab", b =>
                {
                    b.Property<int>("LabId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LabId"));

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LabCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LabName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LabId");

                    b.ToTable("labs");
                });

            modelBuilder.Entity("IMS.Application.Model.Maintenance", b =>
                {
                    b.Property<int>("MaintenanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaintenanceId"));

                    b.Property<int?>("Cost")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedClerkId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("ReviewNote")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ReviewedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ReviewedClerkId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubmitNote")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("SubmittedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("TaskDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TechnicianId")
                        .HasColumnType("int");

                    b.HasKey("MaintenanceId");

                    b.HasIndex("CreatedClerkId");

                    b.HasIndex("ItemId");

                    b.HasIndex("ReviewedClerkId");

                    b.HasIndex("TechnicianId");

                    b.ToTable("maintenances");
                });

            modelBuilder.Entity("IMS.Application.Model.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("IMS.Application.Model.Equipment", b =>
                {
                    b.HasOne("IMS.Application.Model.Lab", "Lab")
                        .WithMany("Equipments")
                        .HasForeignKey("LabId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Lab");
                });

            modelBuilder.Entity("IMS.Application.Model.Item", b =>
                {
                    b.HasOne("IMS.Application.Model.Equipment", "Equipment")
                        .WithMany("Items")
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Equipment");
                });

            modelBuilder.Entity("IMS.Application.Model.ItemReservation", b =>
                {
                    b.HasOne("IMS.Application.Model.Equipment", "Equipment")
                        .WithMany("ItemReservations")
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("IMS.Application.Model.Item", "Item")
                        .WithMany("Reservations")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("IMS.Application.Model.User", "LentClerk")
                        .WithMany("ItemsBorrowedFrom")
                        .HasForeignKey("LentClerkId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("IMS.Application.Model.User", "ReservedUser")
                        .WithMany("ItemsReservedBy")
                        .HasForeignKey("ReservedUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("IMS.Application.Model.User", "RespondedClerk")
                        .WithMany("ReservationsRespondedTo")
                        .HasForeignKey("RespondedClerkId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("IMS.Application.Model.User", "ReturnAcceptedClerk")
                        .WithMany("ItemsReturnedTo")
                        .HasForeignKey("ReturnAcceptedClerkId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Equipment");

                    b.Navigation("Item");

                    b.Navigation("LentClerk");

                    b.Navigation("ReservedUser");

                    b.Navigation("RespondedClerk");

                    b.Navigation("ReturnAcceptedClerk");
                });

            modelBuilder.Entity("IMS.Application.Model.Maintenance", b =>
                {
                    b.HasOne("IMS.Application.Model.User", "CreatedClerk")
                        .WithMany("MaintenancesCreatedBy")
                        .HasForeignKey("CreatedClerkId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("IMS.Application.Model.Item", "Item")
                        .WithMany("Maintenances")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("IMS.Application.Model.User", "ReviewedClerk")
                        .WithMany("MaintenancesReviewedBy")
                        .HasForeignKey("ReviewedClerkId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("IMS.Application.Model.User", "Technician")
                        .WithMany("MaintenancesAssignedTo")
                        .HasForeignKey("TechnicianId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CreatedClerk");

                    b.Navigation("Item");

                    b.Navigation("ReviewedClerk");

                    b.Navigation("Technician");
                });

            modelBuilder.Entity("IMS.Application.Model.Equipment", b =>
                {
                    b.Navigation("ItemReservations");

                    b.Navigation("Items");
                });

            modelBuilder.Entity("IMS.Application.Model.Item", b =>
                {
                    b.Navigation("Maintenances");

                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("IMS.Application.Model.Lab", b =>
                {
                    b.Navigation("Equipments");
                });

            modelBuilder.Entity("IMS.Application.Model.User", b =>
                {
                    b.Navigation("ItemsBorrowedFrom");

                    b.Navigation("ItemsReservedBy");

                    b.Navigation("ItemsReturnedTo");

                    b.Navigation("MaintenancesAssignedTo");

                    b.Navigation("MaintenancesCreatedBy");

                    b.Navigation("MaintenancesReviewedBy");

                    b.Navigation("ReservationsRespondedTo");
                });
#pragma warning restore 612, 618
        }
    }
}
