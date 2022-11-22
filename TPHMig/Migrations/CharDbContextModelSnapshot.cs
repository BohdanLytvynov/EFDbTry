﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TPHMig;

#nullable disable

namespace TPHMig.Migrations
{
    [DbContext(typeof(CharDbContext))]
    partial class CharDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EntityFrameWork.TPH.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Hp")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Stamina")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Persons");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("EntityFrameWork.TPH.Warrior", b =>
                {
                    b.HasBaseType("EntityFrameWork.TPH.Person");

                    b.Property<double>("Armor")
                        .HasColumnType("float");

                    b.Property<double>("Attack")
                        .HasColumnType("float");

                    b.HasDiscriminator().HasValue("Warrior");
                });

            modelBuilder.Entity("EntityFrameWork.TPH.Hero", b =>
                {
                    b.HasBaseType("EntityFrameWork.TPH.Warrior");

                    b.Property<double>("Mana")
                        .HasColumnType("float");

                    b.HasDiscriminator().HasValue("Hero");
                });
#pragma warning restore 612, 618
        }
    }
}
