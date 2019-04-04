using Microsoft.EntityFrameworkCore.Migrations;

namespace TRPR.Data.TRPRMigrations
{
    public partial class commetns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment1",
                schema: "TRPR",
                table: "ReviewAssigns",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comment2",
                schema: "TRPR",
                table: "ReviewAssigns",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment1",
                schema: "TRPR",
                table: "ReviewAssigns");

            migrationBuilder.DropColumn(
                name: "Comment2",
                schema: "TRPR",
                table: "ReviewAssigns");
        }
    }
}
