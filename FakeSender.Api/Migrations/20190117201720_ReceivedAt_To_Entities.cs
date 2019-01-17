using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FakeSender.Api.Migrations
{
    public partial class ReceivedAt_To_Entities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ReceivedAt",
                table: "SmsBox",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ReceivedAt",
                table: "EmailBox",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ReceivedAt",
                table: "ApnsQueryBox",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ReceivedAt",
                table: "Accounts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceivedAt",
                table: "SmsBox");

            migrationBuilder.DropColumn(
                name: "ReceivedAt",
                table: "EmailBox");

            migrationBuilder.DropColumn(
                name: "ReceivedAt",
                table: "ApnsQueryBox");

            migrationBuilder.DropColumn(
                name: "ReceivedAt",
                table: "Accounts");
        }
    }
}
