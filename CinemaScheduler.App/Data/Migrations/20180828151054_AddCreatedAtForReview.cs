using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaScheduler.App.Migrations
{
    public partial class AddCreatedAtForReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "MovieReviews",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "MovieReviews");
        }
    }
}
