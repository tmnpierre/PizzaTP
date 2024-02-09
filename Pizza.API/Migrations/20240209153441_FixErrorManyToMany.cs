using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizza.API.Migrations
{
    public partial class FixErrorManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingrédient_Ingrédient_IngredientModelId",
                table: "Ingrédient");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingrédient_Pizza_PizzaModelId",
                table: "Ingrédient");

            migrationBuilder.DropIndex(
                name: "IX_Ingrédient_IngredientModelId",
                table: "Ingrédient");

            migrationBuilder.DropIndex(
                name: "IX_Ingrédient_PizzaModelId",
                table: "Ingrédient");

            migrationBuilder.DropColumn(
                name: "IngredientModelId",
                table: "Ingrédient");

            migrationBuilder.DropColumn(
                name: "PizzaModelId",
                table: "Ingrédient");

            migrationBuilder.CreateTable(
                name: "IngredientModelPizzaModel",
                columns: table => new
                {
                    IngredientsId = table.Column<int>(type: "int", nullable: false),
                    PizzasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientModelPizzaModel", x => new { x.IngredientsId, x.PizzasId });
                    table.ForeignKey(
                        name: "FK_IngredientModelPizzaModel_Ingrédient_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "Ingrédient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientModelPizzaModel_Pizza_PizzasId",
                        column: x => x.PizzasId,
                        principalTable: "Pizza",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientModelPizzaModel_PizzasId",
                table: "IngredientModelPizzaModel",
                column: "PizzasId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientModelPizzaModel");

            migrationBuilder.AddColumn<int>(
                name: "IngredientModelId",
                table: "Ingrédient",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PizzaModelId",
                table: "Ingrédient",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingrédient_IngredientModelId",
                table: "Ingrédient",
                column: "IngredientModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingrédient_PizzaModelId",
                table: "Ingrédient",
                column: "PizzaModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingrédient_Ingrédient_IngredientModelId",
                table: "Ingrédient",
                column: "IngredientModelId",
                principalTable: "Ingrédient",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingrédient_Pizza_PizzaModelId",
                table: "Ingrédient",
                column: "PizzaModelId",
                principalTable: "Pizza",
                principalColumn: "Id");
        }
    }
}
