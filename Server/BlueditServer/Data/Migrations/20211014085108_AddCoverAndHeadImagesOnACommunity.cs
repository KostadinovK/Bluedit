using Microsoft.EntityFrameworkCore.Migrations;

namespace BlueditServer.Migrations
{
    public partial class AddCoverAndHeadImagesOnACommunity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Communities",
                newName: "HeadImageUrl");

            migrationBuilder.AddColumn<string>(
                name: "CoverImageUrl",
                table: "Communities",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverImageUrl",
                table: "Communities");

            migrationBuilder.RenameColumn(
                name: "HeadImageUrl",
                table: "Communities",
                newName: "ImageUrl");
        }
    }
}
