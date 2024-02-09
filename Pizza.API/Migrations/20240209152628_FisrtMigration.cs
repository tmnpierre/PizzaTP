using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizza.API.Migrations
{
    public partial class FisrtMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pizza",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prix = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Categorie = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizza", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utilisateur",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prénom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nomdefamille = table.Column<string>(name: "Nom de famille", type: "nvarchar(max)", nullable: true),
                    Datedenaissance = table.Column<DateTime>(name: "Date de naissance", type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numérodetéléphone = table.Column<string>(name: "Numéro de téléphone", type: "nvarchar(max)", nullable: true),
                    Adressepostale = table.Column<string>(name: "Adresse postale", type: "nvarchar(max)", nullable: true),
                    Motdepasse = table.Column<string>(name: "Mot de passe", type: "nvarchar(max)", nullable: true),
                    Administrateur = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateur", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingrédient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prix = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IngredientModelId = table.Column<int>(type: "int", nullable: true),
                    PizzaModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingrédient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingrédient_Ingrédient_IngredientModelId",
                        column: x => x.IngredientModelId,
                        principalTable: "Ingrédient",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ingrédient_Pizza_PizzaModelId",
                        column: x => x.PizzaModelId,
                        principalTable: "Pizza",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingrédient_IngredientModelId",
                table: "Ingrédient",
                column: "IngredientModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingrédient_PizzaModelId",
                table: "Ingrédient",
                column: "PizzaModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingrédient");

            migrationBuilder.DropTable(
                name: "Utilisateur");

            migrationBuilder.DropTable(
                name: "Pizza");
        }
    }
}
