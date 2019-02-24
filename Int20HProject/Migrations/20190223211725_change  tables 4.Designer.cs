﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Int20HProject.Migrations
{
    [DbContext(typeof(TeencyBarkerContext))]
    [Migration("20190223211725_change  tables 4")]
    partial class changetables4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Models.SearchedFoodResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FoodName");

                    b.Property<double>("NfCalories");

                    b.Property<double>("NfCholesterol");

                    b.Property<double>("NfDietaryFiber");

                    b.Property<double>("NfP");

                    b.Property<double>("NfPotassium");

                    b.Property<double>("NfProtein");

                    b.Property<double>("NfSaturatedFat");

                    b.Property<double>("NfSugars");

                    b.Property<double>("NfTotalCarbohydrate");

                    b.Property<double>("NfTotalFat");

                    b.Property<int>("ServingQty");

                    b.Property<double>("ServingWeightGrams");

                    b.Property<int>("UserSearchesId");

                    b.HasKey("Id");

                    b.HasIndex("UserSearchesId");

                    b.ToTable("searched_food_result");
                });

            modelBuilder.Entity("Models.UserInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<int>("FullYears");

                    b.Property<string>("Gender");

                    b.Property<double>("Height");

                    b.Property<string>("LastName");

                    b.Property<double>("Weight");

                    b.HasKey("Id");

                    b.ToTable("user_info");
                });

            modelBuilder.Entity("Models.UserSearches", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("SearchDateTime");

                    b.Property<int>("UserInfoId");

                    b.Property<string>("UserQuery");

                    b.HasKey("Id");

                    b.HasIndex("UserInfoId");

                    b.ToTable("user_searches");
                });

            modelBuilder.Entity("Models.SearchedFoodResult", b =>
                {
                    b.HasOne("Models.UserSearches", "UserSearches")
                        .WithMany("SearchedFoodResults")
                        .HasForeignKey("UserSearchesId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Models.UserSearches", b =>
                {
                    b.HasOne("Models.UserInfo", "UserInfo")
                        .WithMany()
                        .HasForeignKey("UserInfoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
