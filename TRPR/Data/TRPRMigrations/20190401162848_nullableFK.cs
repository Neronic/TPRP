using Microsoft.EntityFrameworkCore.Migrations;

namespace TRPR.Data.TRPRMigrations
{
    public partial class nullableFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReviewAssigns_Recommends_RecommendID",
                schema: "TRPR",
                table: "ReviewAssigns");

            migrationBuilder.DropForeignKey(
                name: "FK_ReviewAssigns_ReviewAgains_ReviewAgainID",
                schema: "TRPR",
                table: "ReviewAssigns");

            migrationBuilder.AlterColumn<int>(
                name: "ReviewAgainID",
                schema: "TRPR",
                table: "ReviewAssigns",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "RecommendID",
                schema: "TRPR",
                table: "ReviewAssigns",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewAssigns_Recommends_RecommendID",
                schema: "TRPR",
                table: "ReviewAssigns",
                column: "RecommendID",
                principalSchema: "TRPR",
                principalTable: "Recommends",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewAssigns_ReviewAgains_ReviewAgainID",
                schema: "TRPR",
                table: "ReviewAssigns",
                column: "ReviewAgainID",
                principalSchema: "TRPR",
                principalTable: "ReviewAgains",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReviewAssigns_Recommends_RecommendID",
                schema: "TRPR",
                table: "ReviewAssigns");

            migrationBuilder.DropForeignKey(
                name: "FK_ReviewAssigns_ReviewAgains_ReviewAgainID",
                schema: "TRPR",
                table: "ReviewAssigns");

            migrationBuilder.AlterColumn<int>(
                name: "ReviewAgainID",
                schema: "TRPR",
                table: "ReviewAssigns",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RecommendID",
                schema: "TRPR",
                table: "ReviewAssigns",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewAssigns_Recommends_RecommendID",
                schema: "TRPR",
                table: "ReviewAssigns",
                column: "RecommendID",
                principalSchema: "TRPR",
                principalTable: "Recommends",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewAssigns_ReviewAgains_ReviewAgainID",
                schema: "TRPR",
                table: "ReviewAssigns",
                column: "ReviewAgainID",
                principalSchema: "TRPR",
                principalTable: "ReviewAgains",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
