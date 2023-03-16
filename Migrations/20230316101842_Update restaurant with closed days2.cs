using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheRandomFork.Migrations
{
    /// <inheritdoc />
    public partial class Updaterestaurantwithcloseddays2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantClosedDay_Restaurants_RestaurantId",
                table: "RestaurantClosedDay");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RestaurantClosedDay",
                table: "RestaurantClosedDay");

            migrationBuilder.RenameTable(
                name: "RestaurantClosedDay",
                newName: "ClosedDays");

            migrationBuilder.RenameIndex(
                name: "IX_RestaurantClosedDay_RestaurantId",
                table: "ClosedDays",
                newName: "IX_ClosedDays_RestaurantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClosedDays",
                table: "ClosedDays",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClosedDays_Restaurants_RestaurantId",
                table: "ClosedDays",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClosedDays_Restaurants_RestaurantId",
                table: "ClosedDays");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClosedDays",
                table: "ClosedDays");

            migrationBuilder.RenameTable(
                name: "ClosedDays",
                newName: "RestaurantClosedDay");

            migrationBuilder.RenameIndex(
                name: "IX_ClosedDays_RestaurantId",
                table: "RestaurantClosedDay",
                newName: "IX_RestaurantClosedDay_RestaurantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RestaurantClosedDay",
                table: "RestaurantClosedDay",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantClosedDay_Restaurants_RestaurantId",
                table: "RestaurantClosedDay",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
