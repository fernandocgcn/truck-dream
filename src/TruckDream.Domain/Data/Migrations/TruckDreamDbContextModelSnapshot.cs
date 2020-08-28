﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TruckDream.Domain.Data;

namespace TruckDream.Domain.Data.Migrations
{
    [DbContext(typeof(TruckDreamDbContext))]
    partial class TruckDreamDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7");

            modelBuilder.Entity("TruckDream.Domain.Entities.Model", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("model_id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Acronym")
                        .IsRequired()
                        .HasColumnName("acronym")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("tb_model");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Acronym = "XH",
                            Name = "Extra Heavy / Extra Pesado"
                        },
                        new
                        {
                            Id = 2,
                            Acronym = "N10",
                            Name = "Nose 10L / Bicudo 10L"
                        },
                        new
                        {
                            Id = 3,
                            Acronym = "NL",
                            Name = "Nose Larger / Bicudo Cabine Mais Larga"
                        },
                        new
                        {
                            Id = 4,
                            Acronym = "FH",
                            Name = "Frontal High / Frente Reta Cabine Alta"
                        },
                        new
                        {
                            Id = 5,
                            Acronym = "FH16",
                            Name = "Frontal High 16L / Frente Reta Cabine Alta 16L"
                        },
                        new
                        {
                            Id = 6,
                            Acronym = "VNL",
                            Name = "Volvo Nose Larger / Volvo Bicudo Cabine Mais Larga"
                        },
                        new
                        {
                            Id = 7,
                            Acronym = "FL",
                            Name = "Frontal Lower / Frente Reta Cabine Mais Baixa"
                        },
                        new
                        {
                            Id = 8,
                            Acronym = "FM",
                            Name = "Frontal Medium / Frente Reta Cabine M�dia"
                        },
                        new
                        {
                            Id = 9,
                            Acronym = "FMX",
                            Name = "Frontal Medium Extreme / Frente Reta Cabine M�dia Fora da Estrada"
                        },
                        new
                        {
                            Id = 10,
                            Acronym = "VM",
                            Name = "Volvo Medium 32T / Volvo M�dio 32T"
                        });
                });

            modelBuilder.Entity("TruckDream.Domain.Entities.Truck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("truck_id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Color")
                        .HasColumnName("color")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Horsepower")
                        .HasColumnName("horsepower")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("Mileage")
                        .HasColumnName("mileage")
                        .HasColumnType("REAL");

                    b.Property<int>("ModelYear")
                        .HasColumnName("model_year")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductionYear")
                        .HasColumnName("production_year")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("model_id")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("model_id");

                    b.ToTable("tb_truck");
                });

            modelBuilder.Entity("TruckDream.Domain.Entities.Truck", b =>
                {
                    b.HasOne("TruckDream.Domain.Entities.Model", "Model")
                        .WithMany()
                        .HasForeignKey("model_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
