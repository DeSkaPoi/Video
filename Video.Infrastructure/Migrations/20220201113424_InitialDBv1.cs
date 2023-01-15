using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Video.Infrastructure.Migrations
{
    public partial class InitialDBv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "not indicated"),
                    Format = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "not indicated"),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "not indicated"),
                    Resolution = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "not indicated"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "not indicated"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BelongDocument = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Videos");
        }
    }
}
