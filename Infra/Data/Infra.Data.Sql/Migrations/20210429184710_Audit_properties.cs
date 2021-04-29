using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UrlShortner.Infra.Data.SqlServer.Migrations
{
    public partial class Audit_properties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "ShortenedUrls",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "ShortenedUrls",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "ShortenedUrls");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "ShortenedUrls");
        }
    }
}
