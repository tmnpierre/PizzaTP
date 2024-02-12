using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizza.API.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ingrédient",
                columns: new[] { "Id", "Description", "Nom", "Prix" },
                values: new object[,]
                {
                    { 1, "Tomates fraîches", "Tomate", 1.00m },
                    { 2, "Mozzarella fondante", "Fromage", 2.00m },
                    { 3, "Pepperoni épicé", "Pepperoni", 2.50m },
                    { 4, "Jambon de qualité supérieure", "Jambon", 2.00m },
                    { 5, "Champignons frais", "Champignons", 1.50m },
                    { 6, "Olives noires", "Olives", 1.00m }
                });

            migrationBuilder.InsertData(
                table: "Pizza",
                columns: new[] { "Id", "Categorie", "Description", "Nom", "Prix" },
                values: new object[,]
                {
                    { 1, 0, "Simple et classique.", "Margherita", 10.00m },
                    { 2, 2, "Piquante avec pepperoni.", "Pepperoni", 12.00m },
                    { 3, 0, "Riche en fromages.", "Quatre fromages", 13.00m },
                    { 4, 1, "Garnie de légumes frais.", "Végétarienne", 11.00m },
                    { 5, 0, "Jambon et ananas.", "Hawaïenne", 12.00m },
                    { 6, 3, "Pliée et farcie, garnie de jambon, champignons et fromage.", "Calzone", 14.00m }
                });

            migrationBuilder.InsertData(
                table: "Utilisateur",
                columns: new[] { "Id", "Adresse postale", "Date de naissance", "Email", "Prénom", "Administrateur", "Nom de famille", "Mot de passe", "Numéro de téléphone" },
                values: new object[,]
                {
                    { 1, "123 Main St, Anytown", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@example.com", "John", false, "Doe", "Password1", "0123456789" },
                    { 2, "456 Another St, Anytown", new DateTime(1992, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.doe@example.com", "Jane", false, "Doe", "Password2", "9876543210" },
                    { 3, "789 Admin St, Anytown", new DateTime(1985, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@example.com", "Admin", true, "User", "AdminPassword", "1234567890" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ingrédient",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ingrédient",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ingrédient",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ingrédient",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ingrédient",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Ingrédient",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Pizza",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Utilisateur",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Utilisateur",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Utilisateur",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
