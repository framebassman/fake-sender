using Microsoft.EntityFrameworkCore.Migrations;

namespace FakeSender.Api.Migrations
{
    public partial class Add_Limits_To_Account : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Limit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ByMessage = table.Column<long>(nullable: false),
                    ByMinute = table.Column<int>(nullable: false),
                    ByDay = table.Column<long>(nullable: false),
                    AccountForeignKey = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Limit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Limit_Accounts_AccountForeignKey",
                        column: x => x.AccountForeignKey,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Limit_AccountForeignKey",
                table: "Limit",
                column: "AccountForeignKey",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Limit");
        }
    }
}
