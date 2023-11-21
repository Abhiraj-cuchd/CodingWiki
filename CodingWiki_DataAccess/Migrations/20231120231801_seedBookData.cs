using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CodingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class seedBookData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "IdBook", "ISBN", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "569741", 2500m, "Spider without Duty" },
                    { 2, "54684", 1100m, "Fortune of Time" },
                    { 3, "412369", 3500m, "Call of Duty" },
                    { 4, "44103", 1300m, "2 States" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "IdBook",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "IdBook",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "IdBook",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "IdBook",
                keyValue: 4);
        }
    }
}
