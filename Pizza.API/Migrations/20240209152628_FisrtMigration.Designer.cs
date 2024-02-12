﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pizza.API.Data;

#nullable disable

namespace Pizza.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240209152628_FisrtMigration")]
    partial class FisrtMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Pizza.API.Models.IngredientModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Description");

                    b.Property<int?>("IngredientModelId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nom");

                    b.Property<int?>("PizzaModelId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Prix");

                    b.HasKey("Id");

                    b.HasIndex("IngredientModelId");

                    b.HasIndex("PizzaModelId");

                    b.ToTable("Ingrédient");
                });

            modelBuilder.Entity("Pizza.API.Models.PizzaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Categorie")
                        .HasColumnType("int")
                        .HasColumnName("Categorie");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Description");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nom");

                    b.Property<decimal>("Prix")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Prix");

                    b.HasKey("Id");

                    b.ToTable("Pizza");
                });

            modelBuilder.Entity("Pizza.API.Models.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Adresse postale");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2")
                        .HasColumnName("Date de naissance");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Prénom");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit")
                        .HasColumnName("Administrateur");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nom de famille");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Mot de passe");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Numéro de téléphone");

                    b.HasKey("Id");

                    b.ToTable("Utilisateur");
                });

            modelBuilder.Entity("Pizza.API.Models.IngredientModel", b =>
                {
                    b.HasOne("Pizza.API.Models.IngredientModel", null)
                        .WithMany("Ingredients")
                        .HasForeignKey("IngredientModelId");

                    b.HasOne("Pizza.API.Models.PizzaModel", null)
                        .WithMany("Ingredients")
                        .HasForeignKey("PizzaModelId");
                });

            modelBuilder.Entity("Pizza.API.Models.IngredientModel", b =>
                {
                    b.Navigation("Ingredients");
                });

            modelBuilder.Entity("Pizza.API.Models.PizzaModel", b =>
                {
                    b.Navigation("Ingredients");
                });
#pragma warning restore 612, 618
        }
    }
}