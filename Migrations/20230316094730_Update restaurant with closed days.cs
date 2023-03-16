using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheRandomFork.Migrations
{
    /// <inheritdoc />
    public partial class Updaterestaurantwithcloseddays : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RestaurantClosedDay",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RestaurantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClosedDay = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantClosedDay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantClosedDay_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantClosedDay_RestaurantId",
                table: "RestaurantClosedDay",
                column: "RestaurantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RestaurantClosedDay");
        }
    }
}
