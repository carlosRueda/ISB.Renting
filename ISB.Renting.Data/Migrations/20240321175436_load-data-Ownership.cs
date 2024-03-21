using ISB.Renting.Models.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Diagnostics;

#nullable disable

namespace ISB.Renting.Data.Migrations
{
    /// <inheritdoc />
    public partial class loaddataOwnership : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "Ownership",
            columns: new[] { "Id", "PropertyId", "ContactId", "Price", "EffectiveFrom", "EffectiveTill" },
                values: new object[,] {
                    { new Guid("c6d07330-99b8-438d-832a-42843e598306"), new Guid("c6d07330-99b8-438d-832a-42843e598303"), new Guid("c6d07330-99b8-438d-832a-42843e598301"), 250000000.00, DateTime.Now, null },
                    { new Guid("c6d07330-99b8-438d-832a-42843e598307"), new Guid("c6d07330-99b8-438d-832a-42843e598304"), new Guid("c6d07330-99b8-438d-832a-42843e598300"), 5200000000.00,DateTime.Now, null },
                    { new Guid("c6d07330-99b8-438d-832a-42843e598308"), new Guid("c6d07330-99b8-438d-832a-42843e598305"), new Guid("c6d07330-99b8-438d-832a-42843e598302"), 320000000.00, DateTime.Now, null},
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
