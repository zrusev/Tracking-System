namespace Metrics_Track.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class TeamLeads : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ID_TeamLead",
                schema: "CPS",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TblTeamLead",
                schema: "CPS",
                columns: table => new
                {
                    Id_TeamLead = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TeamLead = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblTeamLead", x => x.Id_TeamLead);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ID_TeamLead",
                schema: "CPS",
                table: "AspNetUsers",
                column: "ID_TeamLead",
                unique: false);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_TblTeamLead_ID_TeamLead",
                schema: "CPS",
                table: "AspNetUsers",
                column: "ID_TeamLead",
                principalSchema: "CPS",
                principalTable: "TblTeamLead",
                principalColumn: "Id_TeamLead",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_TblTeamLead_ID_TeamLead",
                schema: "CPS",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "TblTeamLead",
                schema: "CPS");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ID_TeamLead",
                schema: "CPS",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ID_TeamLead",
                schema: "CPS",
                table: "AspNetUsers");
        }
    }
}
