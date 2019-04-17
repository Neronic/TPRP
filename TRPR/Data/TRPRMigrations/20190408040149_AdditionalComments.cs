using Microsoft.EntityFrameworkCore.Migrations;

namespace TRPR.Data.TRPRMigrations
{
    public partial class AdditionalComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthorComment",
                schema: "TRPR",
                table: "ReviewAssigns",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EiCComment",
                schema: "TRPR",
                table: "ReviewAssigns",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorComment",
                schema: "TRPR",
                table: "ReviewAssigns");

            migrationBuilder.DropColumn(
                name: "EiCComment",
                schema: "TRPR",
                table: "ReviewAssigns");
        }
    }
}
