using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TRPR.Data.TRPRMigrations
{
    public partial class pwa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subs",
                schema: "TRPR",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 127, nullable: true),
                    PushEndpoint = table.Column<string>(maxLength: 512, nullable: true),
                    PushP256DH = table.Column<string>(maxLength: 512, nullable: true),
                    PushAuth = table.Column<string>(maxLength: 512, nullable: true),
                    ResearcherID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subs_Researchers_ResearcherID",
                        column: x => x.ResearcherID,
                        principalSchema: "TRPR",
                        principalTable: "Researchers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subs_ResearcherID",
                schema: "TRPR",
                table: "Subs",
                column: "ResearcherID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subs",
                schema: "TRPR");
        }
    }
}
