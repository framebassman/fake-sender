using Microsoft.EntityFrameworkCore.Migrations;

namespace FakeSender.Api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApnsQueryBox",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PushToken = table.Column<string>(nullable: true),
                    ApplePassTypeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApnsQueryBox", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailBox",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    To = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    Html = table.Column<string>(nullable: true),
                    Attachments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailBox", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SmsBox",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    To = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmsBox", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApnsQueryBox");

            migrationBuilder.DropTable(
                name: "EmailBox");

            migrationBuilder.DropTable(
                name: "SmsBox");
        }
    }
}
