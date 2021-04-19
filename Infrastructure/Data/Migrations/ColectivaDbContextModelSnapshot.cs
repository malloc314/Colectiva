﻿// <auto-generated />
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ColectivaDbContext))]
    partial class ColectivaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.HistoricalSequence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("Fifth")
                        .HasColumnType("tinyint");

                    b.Property<byte>("First")
                        .HasColumnType("tinyint");

                    b.Property<byte>("Fourth")
                        .HasColumnType("tinyint");

                    b.Property<byte>("Second")
                        .HasColumnType("tinyint");

                    b.Property<byte>("Seventh")
                        .HasColumnType("tinyint");

                    b.Property<byte>("Sixth")
                        .HasColumnType("tinyint");

                    b.Property<int>("Sn")
                        .HasColumnType("int");

                    b.Property<byte>("Thrid")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.ToTable("HistoricalSequences");
                });
#pragma warning restore 612, 618
        }
    }
}