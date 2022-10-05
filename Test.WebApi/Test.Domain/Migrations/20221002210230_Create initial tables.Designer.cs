﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Test.Domain.Context;

#nullable disable

namespace Test.Domain.Migrations
{
    [DbContext(typeof(TestContext))]
    [Migration("20221002210230_Create initial tables")]
    partial class Createinitialtables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Test.Domain.Entities.Account", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IncidentName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Name");

                    b.HasIndex("IncidentName");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Test.Domain.Entities.Contact", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccountName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Email");

                    b.HasIndex("AccountName");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("Test.Domain.Entities.Incident", b =>
                {
                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Name");

                    b.ToTable("Incidents");
                });

            modelBuilder.Entity("Test.Domain.Entities.Account", b =>
                {
                    b.HasOne("Test.Domain.Entities.Incident", "Incident")
                        .WithMany("Accounts")
                        .HasForeignKey("IncidentName");

                    b.Navigation("Incident");
                });

            modelBuilder.Entity("Test.Domain.Entities.Contact", b =>
                {
                    b.HasOne("Test.Domain.Entities.Account", "Account")
                        .WithMany("Contacts")
                        .HasForeignKey("AccountName");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Test.Domain.Entities.Account", b =>
                {
                    b.Navigation("Contacts");
                });

            modelBuilder.Entity("Test.Domain.Entities.Incident", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
