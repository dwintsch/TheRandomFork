﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheRandomFork.Migrations
{
    /// <inheritdoc />
    public partial class Addnewhistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RestaurantHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdRestaurant = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantHistory", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RestaurantHistory");
        }
    }
}
