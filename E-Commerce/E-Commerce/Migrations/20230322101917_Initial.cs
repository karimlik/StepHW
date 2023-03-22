﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(name: "User Name", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserEmail = table.Column<string>(name: "User Email", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserPassword = table.Column<string>(name: "User Password", type: "nvarchar(max)", nullable: false),
                    UserPhone = table.Column<string>(name: "User Phone", type: "nvarchar(max)", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    AdminLevel = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarMake = table.Column<string>(name: "Car Make", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CarModel = table.Column<string>(name: "Car Model", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CarYear = table.Column<int>(name: "Car Year", type: "int", nullable: false),
                    CarMileage = table.Column<int>(name: "Car Mileage", type: "int", nullable: false),
                    CarPrice = table.Column<decimal>(name: "Car Price", type: "decimal(18,2)", nullable: false),
                    ImgUrl = table.Column<string>(name: "Img Url", type: "nvarchar(max)", nullable: false),
                    SellerName = table.Column<string>(name: "Seller Name", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SellerPhone = table.Column<string>(name: "Seller Phone", type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_UserId",
                table: "Cars",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
