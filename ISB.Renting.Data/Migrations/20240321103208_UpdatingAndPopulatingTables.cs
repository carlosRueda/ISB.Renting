using Microsoft.EntityFrameworkCore.Migrations;
using System.Diagnostics;
using System.Net;

#nullable disable

namespace ISB.Renting.Data.Migrations
{
    /// <inheritdoc />
    public partial class PopulatingTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Property",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Contact",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Contact",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Contact",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Contact",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Contact",
                columns: new[] { "Id", "FirstName", "LastName", "PhoneNumber", "Email" },
                values: new object[,] { 
                    { new Guid("c6d07330-99b8-438d-832a-42843e598300"), "Zlatan", "Ibrahimovic", "1111111", "z.ibrahimovic@ISB.com" },
                    { new Guid("c6d07330-99b8-438d-832a-42843e598301"), "Carlos", "Rueda", "7777777", "c.rueda@ISB.com" },
                    { new Guid("c6d07330-99b8-438d-832a-42843e598302"), "Rafael", "Leao", "1710171", "r.leao@ISB.com" } 
                });

            migrationBuilder.InsertData(
            table: "Property",
                columns: new[] { "Id", "Name", "Address", "Price", "RegistrationDate" },
                values: new object[,] {
                    { new Guid("c6d07330-99b8-438d-832a-42843e598303"), "Madrid's House", "calle 19 3 303", 250000000.00, "2018-01-01 10:20:18.1360000" },
                    { new Guid("c6d07330-99b8-438d-832a-42843e598304"), "Sweden's House", "Street 11 house 4", 5200000000.00, "2010-01-01 10:20:18.1360000" },
                    { new Guid("c6d07330-99b8-438d-832a-42843e598305"), "Portugal's House", "streetsinha 25", 320000000.00, "2019-01-01 10:20:18.1360000" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Property",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Contact",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Contact",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Contact",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Contact",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
