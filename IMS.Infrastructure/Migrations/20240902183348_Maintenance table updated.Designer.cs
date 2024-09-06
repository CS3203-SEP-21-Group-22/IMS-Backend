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
    [Migration("20240902183348_Maintenance table updated")]
    partial class Maintenancetableupdated
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IMS.ApplicationCore.Model.Equipment", b =>
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

                    b.Property<DateTime>("MaintenanceInterval")
                        .HasColumnType("datetime2");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specification")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EquipmentId");

                    b.HasIndex("LabId");

                    b.ToTable("Equipments");
                });

            modelBuilder.Entity("IMS.ApplicationCore.Model.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemId"));

                    b.Property<int>("EquipmentId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("SerialNumber")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ItemId");

                    b.HasIndex("EquipmentId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("IMS.ApplicationCore.Model.ItemReservation", b =>
                {
                    b.Property<int>("ItemReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemReservationId"));

                    b.Property<int>("AsignedItemId")
                        .HasColumnType("int");

                    b.Property<DateTime>("BorrowedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("BorrowedFrom")
                        .HasColumnType("int");

                    b.Property<DateTime>("CancelledAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("RequstedEquipmentId")
                        .HasColumnType("int");

                    b.Property<int>("ReservedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("ResponedAtAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ResponseNote")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ResponseedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReturnedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReturnedTo")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ToDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ItemReservationId");

                    b.HasIndex("AsignedItemId");

                    b.HasIndex("BorrowedFrom");

                    b.HasIndex("RequstedEquipmentId");

                    b.HasIndex("ReservedBy");

                    b.HasIndex("ResponseedBy");

                    b.HasIndex("ReturnedTo");

                    b.ToTable("ItemReservations");
                });

            modelBuilder.Entity("IMS.ApplicationCore.Model.Lab", b =>
                {
                    b.Property<int>("LabId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LabId"));

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("LabCode")
                        .HasColumnType("int");

                    b.Property<string>("LabName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LabId");

                    b.ToTable("Labs");
                });

            modelBuilder.Entity("IMS.ApplicationCore.Model.Maintenance", b =>
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

                    b.ToTable("Maintenances");
                });

            modelBuilder.Entity("IMS.ApplicationCore.Model.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("ContactNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("IMS.ApplicationCore.Model.Equipment", b =>
                {
                    b.HasOne("IMS.ApplicationCore.Model.Lab", "Lab")
                        .WithMany()
                        .HasForeignKey("LabId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lab");
                });

            modelBuilder.Entity("IMS.ApplicationCore.Model.Item", b =>
                {
                    b.HasOne("IMS.ApplicationCore.Model.Equipment", "Equipment")
                        .WithMany()
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipment");
                });

            modelBuilder.Entity("IMS.ApplicationCore.Model.ItemReservation", b =>
                {
                    b.HasOne("IMS.ApplicationCore.Model.Item", "Item")
                        .WithMany()
                        .HasForeignKey("AsignedItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IMS.ApplicationCore.Model.User", "BorrowedFromUser")
                        .WithMany("BorrowedItems")
                        .HasForeignKey("BorrowedFrom")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("IMS.ApplicationCore.Model.Equipment", "Equipment")
                        .WithMany()
                        .HasForeignKey("RequstedEquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IMS.ApplicationCore.Model.User", "ReservedByUser")
                        .WithMany("ReservedItems")
                        .HasForeignKey("ReservedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("IMS.ApplicationCore.Model.User", "ResponseedByUser")
                        .WithMany("ResponseItems")
                        .HasForeignKey("ResponseedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("IMS.ApplicationCore.Model.User", "ReturnedToUser")
                        .WithMany("ReturnedItems")
                        .HasForeignKey("ReturnedTo")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("BorrowedFromUser");

                    b.Navigation("Equipment");

                    b.Navigation("Item");

                    b.Navigation("ReservedByUser");

                    b.Navigation("ResponseedByUser");

                    b.Navigation("ReturnedToUser");
                });

            modelBuilder.Entity("IMS.ApplicationCore.Model.Maintenance", b =>
                {
                    b.HasOne("IMS.ApplicationCore.Model.User", "CreatedClerk")
                        .WithMany("MaintenancesCreatedBy")
                        .HasForeignKey("CreatedClerkId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("IMS.ApplicationCore.Model.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IMS.ApplicationCore.Model.User", "ReviewedClerk")
                        .WithMany("MaintenancesReviewedBy")
                        .HasForeignKey("ReviewedClerkId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("IMS.ApplicationCore.Model.User", "Technician")
                        .WithMany("MaintenancesAssignedTo")
                        .HasForeignKey("TechnicianId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CreatedClerk");

                    b.Navigation("Item");

                    b.Navigation("ReviewedClerk");

                    b.Navigation("Technician");
                });

            modelBuilder.Entity("IMS.ApplicationCore.Model.User", b =>
                {
                    b.Navigation("BorrowedItems");

                    b.Navigation("MaintenancesAssignedTo");

                    b.Navigation("MaintenancesCreatedBy");

                    b.Navigation("MaintenancesReviewedBy");

                    b.Navigation("ReservedItems");

                    b.Navigation("ResponseItems");

                    b.Navigation("ReturnedItems");
                });
#pragma warning restore 612, 618
        }
    }
}
