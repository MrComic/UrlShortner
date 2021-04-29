using Microsoft.EntityFrameworkCore.Migrations;

namespace UrlShortner.Infra.Data.SqlServer.Migrations
{
    public partial class Auditproperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ViewdCount",
                table: "ShortenedUrls",
                newName: "VisitCount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VisitCount",
                table: "ShortenedUrls",
                newName: "ViewdCount");
        }
    }
}
