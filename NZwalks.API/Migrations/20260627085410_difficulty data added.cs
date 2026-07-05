using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZwalks.API.Migrations
{
    /// <inheritdoc />
    public partial class difficultydataadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("7fff13b2-e8d9-4ade-a749-17c7a473d78f"), "Easy" },
                    { new Guid("8fff13b2-e8d9-4ade-a749-17c7a473d78f"), "Medium" },
                    { new Guid("9fff13b2-e8d9-4ade-a749-17c7a473d78f"), "Difficult" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("7fff13b2-e8d9-4ade-a749-17c7a473d78f"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("8fff13b2-e8d9-4ade-a749-17c7a473d78f"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("9fff13b2-e8d9-4ade-a749-17c7a473d78f"));
        }
    }
}
