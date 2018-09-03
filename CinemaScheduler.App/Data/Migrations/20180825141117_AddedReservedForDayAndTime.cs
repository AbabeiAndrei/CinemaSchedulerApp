using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaScheduler.App.Migrations
{
    public partial class AddedReservedForDayAndTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReservedForDay",
                table: "Schedules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ReservedForTime",
                table: "Schedules",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReservedForDay",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "ReservedForTime",
                table: "Schedules");
        }
    }
}
