using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace phase3_api2.Infrastructure.Migrations
{
    public partial class initMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeExpire = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeStored = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isWasted = table.Column<bool>(type: "bit", nullable: true),
                    TimeTaken = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prods", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prods");
        }
    }
}
