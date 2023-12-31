﻿// <auto-generated />
using AspNetCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CSIMediaTest.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231114013029_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CSIMediaTest.Data.Models.Number", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("SortedNumbersId")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SortedNumbersId");

                    b.ToTable("Numbers");
                });

            modelBuilder.Entity("CSIMediaTest.Data.Models.SortedNumbers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("InAscendingOrder")
                        .HasColumnType("bit");

                    b.Property<int>("TimeTakenToSort")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SortedNumbers");
                });

            modelBuilder.Entity("CSIMediaTest.Data.Models.Number", b =>
                {
                    b.HasOne("CSIMediaTest.Data.Models.SortedNumbers", "SortedNumbers")
                        .WithMany("Numbers")
                        .HasForeignKey("SortedNumbersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SortedNumbers");
                });

            modelBuilder.Entity("CSIMediaTest.Data.Models.SortedNumbers", b =>
                {
                    b.Navigation("Numbers");
                });
#pragma warning restore 612, 618
        }
    }
}
