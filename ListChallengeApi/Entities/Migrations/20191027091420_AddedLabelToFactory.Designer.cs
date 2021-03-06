﻿// <auto-generated />
using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Entities.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20191027091420_AddedLabelToFactory")]
    partial class AddedLabelToFactory
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Entities.Child", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<Guid>("FactoryId");

                    b.Property<int>("Value");

                    b.HasKey("Id");

                    b.HasIndex("FactoryId");

                    b.ToTable("child");
                });

            modelBuilder.Entity("Entities.Factory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<string>("Label");

                    b.Property<int>("RangeHigh");

                    b.Property<int>("RangeLow");

                    b.Property<Guid>("RootId");

                    b.HasKey("Id");

                    b.HasIndex("RootId");

                    b.ToTable("factory");
                });

            modelBuilder.Entity("Entities.Root", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.HasKey("Id");

                    b.ToTable("root");
                });

            modelBuilder.Entity("Entities.Child", b =>
                {
                    b.HasOne("Entities.Factory")
                        .WithMany("Childs")
                        .HasForeignKey("FactoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entities.Factory", b =>
                {
                    b.HasOne("Entities.Root")
                        .WithMany("Factories")
                        .HasForeignKey("RootId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
