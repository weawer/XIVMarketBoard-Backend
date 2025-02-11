﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using XIVMarketBoard_Api.Data;

#nullable disable

namespace XIVMarketBoard_Api.Migrations
{
    [DbContext(typeof(XivDbContext))]
    [Migration("20220115002653_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("XIVMarketBoard_Backend.Models.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("CanBeCrafted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastSeen")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("RecipeId")
                        .HasColumnType("int");

                    b.HasKey("ItemId");

                    b.HasIndex("RecipeId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("XIVMarketBoard_Backend.Models.Job", b =>
                {
                    b.Property<string>("JobName")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("UserName")
                        .HasColumnType("varchar(255)");

                    b.HasKey("JobName");

                    b.HasIndex("UserName");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("XIVMarketBoard_Backend.Models.MbPost", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<bool>("HighQuality")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PostedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int?>("RetainerId")
                        .HasColumnType("int");

                    b.Property<string>("RetainerName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TotalAmount")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("varchar(255)");

                    b.HasKey("PostId");

                    b.HasIndex("ItemId");

                    b.HasIndex("RetainerId");

                    b.HasIndex("UserName");

                    b.ToTable("MbPosts");
                });

            modelBuilder.Entity("XIVMarketBoard_Backend.Models.Recipe", b =>
                {
                    b.Property<int>("RecipeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("JobName")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("RecipeId");

                    b.HasIndex("JobName");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("XIVMarketBoard_Backend.Models.Retainer", b =>
                {
                    b.Property<int>("RetainerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("RetainerName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("WorldName")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("RetainerId");

                    b.HasIndex("UserName");

                    b.HasIndex("WorldName");

                    b.ToTable("Retainers");
                });

            modelBuilder.Entity("XIVMarketBoard_Backend.Models.SaleHistory", b =>
                {
                    b.Property<int>("SaleHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("HighQuality")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SaleDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("SaleHistoryId");

                    b.HasIndex("ItemId");

                    b.ToTable("SaleHistory");
                });

            modelBuilder.Entity("XIVMarketBoard_Backend.Models.User", b =>
                {
                    b.Property<string>("UserName")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CharacterName")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("UserName");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("XIVMarketBoard_Backend.Models.World", b =>
                {
                    b.Property<string>("WorldName")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("DataCenter")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("WorldName");

                    b.ToTable("Servers");
                });

            modelBuilder.Entity("XIVMarketBoard_Backend.Models.Item", b =>
                {
                    b.HasOne("XIVMarketBoard_Backend.Models.Recipe", null)
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeId");
                });

            modelBuilder.Entity("XIVMarketBoard_Backend.Models.Job", b =>
                {
                    b.HasOne("XIVMarketBoard_Backend.Models.User", null)
                        .WithMany("Jobs")
                        .HasForeignKey("UserName");
                });

            modelBuilder.Entity("XIVMarketBoard_Backend.Models.MbPost", b =>
                {
                    b.HasOne("XIVMarketBoard_Backend.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("XIVMarketBoard_Backend.Models.Retainer", "Retainer")
                        .WithMany()
                        .HasForeignKey("RetainerId");

                    b.HasOne("XIVMarketBoard_Backend.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserName");

                    b.Navigation("Item");

                    b.Navigation("Retainer");

                    b.Navigation("User");
                });

            modelBuilder.Entity("XIVMarketBoard_Backend.Models.Recipe", b =>
                {
                    b.HasOne("XIVMarketBoard_Backend.Models.Job", "job")
                        .WithMany()
                        .HasForeignKey("JobName");

                    b.Navigation("job");
                });

            modelBuilder.Entity("XIVMarketBoard_Backend.Models.Retainer", b =>
                {
                    b.HasOne("XIVMarketBoard_Backend.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("XIVMarketBoard_Backend.Models.World", "World")
                        .WithMany()
                        .HasForeignKey("WorldName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("World");
                });

            modelBuilder.Entity("XIVMarketBoard_Backend.Models.SaleHistory", b =>
                {
                    b.HasOne("XIVMarketBoard_Backend.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("XIVMarketBoard_Backend.Models.Recipe", b =>
                {
                    b.Navigation("Ingredients");
                });

            modelBuilder.Entity("XIVMarketBoard_Backend.Models.User", b =>
                {
                    b.Navigation("Jobs");
                });
#pragma warning restore 612, 618
        }
    }
}
