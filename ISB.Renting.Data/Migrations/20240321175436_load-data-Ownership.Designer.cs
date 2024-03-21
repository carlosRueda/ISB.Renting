﻿// <auto-generated />
using System;
using ISB.Renting.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ISB.Renting.Data.Migrations
{
    [DbContext(typeof(IsbDbContext))]
    [Migration("20240321175436_load-data-Ownership")]
    partial class loaddataOwnership
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ISB.Renting.Models.Data.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Contact", (string)null);
                });

            modelBuilder.Entity("ISB.Renting.Models.Data.Ownership", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ContactId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EffectiveFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EffectiveTill")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("PropertyId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.HasIndex("PropertyId");

                    b.ToTable("Ownership", (string)null);
                });

            modelBuilder.Entity("ISB.Renting.Models.Data.PriceHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("NewPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("PropertyId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId");

                    b.ToTable("PriceHistory", (string)null);
                });

            modelBuilder.Entity("ISB.Renting.Models.Data.Property", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Property", (string)null);
                });

            modelBuilder.Entity("ISB.Renting.Models.Data.Ownership", b =>
                {
                    b.HasOne("ISB.Renting.Models.Data.Contact", "Contact")
                        .WithMany("Ownerships")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ISB.Renting.Models.Data.Property", "Property")
                        .WithMany("Ownerships")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contact");

                    b.Navigation("Property");
                });

            modelBuilder.Entity("ISB.Renting.Models.Data.PriceHistory", b =>
                {
                    b.HasOne("ISB.Renting.Models.Data.Property", null)
                        .WithMany("PriceHistories")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ISB.Renting.Models.Data.Contact", b =>
                {
                    b.Navigation("Ownerships");
                });

            modelBuilder.Entity("ISB.Renting.Models.Data.Property", b =>
                {
                    b.Navigation("Ownerships");

                    b.Navigation("PriceHistories");
                });
#pragma warning restore 612, 618
        }
    }
}