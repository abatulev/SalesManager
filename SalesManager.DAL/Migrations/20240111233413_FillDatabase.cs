using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

#nullable disable

namespace SalesManager.DAL.Migrations
{
    /// <inheritdoc />
    public partial class FillDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Name", "State" },
                values: new object[,] {
                    { 1, "New York Building 1", "NY" },
                    { 2, "California Hotel AJK", "CA" }
                });

            migrationBuilder.InsertData(
                table: "Windows",
                columns: new[] { "Id", "Name", "QuantityOfWindows", "TotalSubElements", "OrderId" },
                values: new object[,] {
                    { 1, "A51", 4, 3, 1 },
                    { 2, "C Zone 5", 2, 1, 1 },
                    { 3, "GLB", 3, 2, 2 },
                    { 4, "OHF", 10, 2, 2 }
                });
            migrationBuilder.InsertData(
                table: "SubElements",
                columns: new[] { "Id", "Element", "Type", "Width", "Height", "WindowId" },
                values: new object[,] {
                    { 1, 1, 1, 1200, 1850, 1 },
                    { 2, 2, 2, 800, 1850, 1 },
                    { 3, 3, 2, 700, 1850, 1 },
                    { 4, 1, 2, 1500, 2000, 2 },
                    { 5, 1, 1, 1400, 2200, 3 },
                    { 6, 2, 2, 600, 2200, 3 },
                    { 7, 1, 2, 1500, 2000, 4 },
                    { 8, 1, 2, 1500, 2000, 4 }
                });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Operations.Add(new SqlOperation
            {
                Sql = "TRUNCATE TABLE Orders",
            });

            migrationBuilder.Operations.Add(new SqlOperation
            {
                Sql = "TRUNCATE TABLE Windows",
            });

            migrationBuilder.Operations.Add(new SqlOperation
            {
                Sql = "TRUNCATE TABLE SubElements",
            });
        }
    }
}
