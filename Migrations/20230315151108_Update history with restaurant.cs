using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheRandomFork.Migrations
{
    /// <inheritdoc />
    public partial class Updatehistorywithrestaurant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdRestaurant",
                table: "RestaurantHistory",
                newName: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantHistory_RestaurantId",
                table: "RestaurantHistory",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantHistory_Restaurants_RestaurantId",
                table: "RestaurantHistory",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantHistory_Restaurants_RestaurantId",
                table: "RestaurantHistory");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantHistory_RestaurantId",
                table: "RestaurantHistory");

            migrationBuilder.RenameColumn(
                name: "RestaurantId",
                table: "RestaurantHistory",
                newName: "IdRestaurant");
        }
    }
}
