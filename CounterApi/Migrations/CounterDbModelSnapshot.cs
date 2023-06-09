﻿// <auto-generated />
using System;
using CounterApi.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CounterApi.Migrations
{
    [DbContext(typeof(CounterDb))]
    partial class CounterDbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CounterApi.Domain.Counter", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("Max")
                        .HasColumnType("int");

                    b.Property<int?>("Min")
                        .HasColumnType("int");

                    b.Property<int>("Step")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Name");

                    b.ToTable("Counters");
                });
#pragma warning restore 612, 618
        }
    }
}
