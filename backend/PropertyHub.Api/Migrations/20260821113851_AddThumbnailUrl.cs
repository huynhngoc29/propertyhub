using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PropertyHub.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddThumbnailUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ThumbnailUrl",
                table: "Units",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThumbnailUrl",
                table: "Properties",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThumbnailUrl",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "ThumbnailUrl",
                table: "Properties");
        }
    }
}
