﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Persistence.Context;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(ClientContext))]
    [Migration("20230511163558_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("CountPositions")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateLastModify")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("uuid");

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("State")
                        .HasColumnType("boolean");

                    b.Property<Guid>("UserCreatorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserModifierId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Domain.Entities.ClientPosition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CurrentStateId")
                        .HasColumnType("uuid");

                    b.Property<string>("CurrentStateName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("DateLastModify")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PositionDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("PositionId")
                        .HasColumnType("uuid");

                    b.Property<bool>("State")
                        .HasColumnType("boolean");

                    b.Property<Guid>("UserCreatorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserModifierId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("ClientsPositions");
                });

            modelBuilder.Entity("Domain.Entities.ClientPositionManager", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClientPositionId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateLastModify")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Resource")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ResourceId")
                        .HasColumnType("uuid");

                    b.Property<bool>("State")
                        .HasColumnType("boolean");

                    b.Property<Guid>("UserCreatorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserModifierId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ClientPositionId")
                        .IsUnique();

                    b.ToTable("ClientPositionManagers");
                });

            modelBuilder.Entity("Domain.Entities.LeaveRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClientPositionId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateLastModify")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LeaveReasonComments")
                        .HasColumnType("text");

                    b.Property<Guid>("ReasonId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ResourceId")
                        .HasColumnType("uuid");

                    b.Property<bool>("State")
                        .HasColumnType("boolean");

                    b.Property<Guid>("UserCreatorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserModifierId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ClientPositionId")
                        .IsUnique();

                    b.ToTable("LeaveRequests");
                });

            modelBuilder.Entity("Domain.Entities.ClientPosition", b =>
                {
                    b.HasOne("Domain.Entities.Client", "Client")
                        .WithMany("ClientPositions")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Domain.Entities.ClientPositionManager", b =>
                {
                    b.HasOne("Domain.Entities.ClientPosition", null)
                        .WithOne()
                        .HasForeignKey("Domain.Entities.ClientPositionManager", "ClientPositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.LeaveRequest", b =>
                {
                    b.HasOne("Domain.Entities.ClientPosition", null)
                        .WithOne()
                        .HasForeignKey("Domain.Entities.LeaveRequest", "ClientPositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Client", b =>
                {
                    b.Navigation("ClientPositions");
                });
#pragma warning restore 612, 618
        }
    }
}