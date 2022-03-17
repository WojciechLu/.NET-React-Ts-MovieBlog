using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieBlog_Backend.Migrations
{
    public partial class migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Movies_RatedMovieId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_ToWatch_Users_UserId",
                table: "ToWatch");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ToWatch",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_ToWatch_UserId",
                table: "ToWatch",
                newName: "IX_ToWatch_OwnerId");

            migrationBuilder.RenameColumn(
                name: "RatedMovieId",
                table: "Reviews",
                newName: "MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_RatedMovieId",
                table: "Reviews",
                newName: "IX_Reviews_MovieId");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<int>(
                name: "IdListToWatch",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Movies_MovieId",
                table: "Reviews",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ToWatch_Users_OwnerId",
                table: "ToWatch",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Movies_MovieId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_ToWatch_Users_OwnerId",
                table: "ToWatch");

            migrationBuilder.DropColumn(
                name: "IdListToWatch",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "ToWatch",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ToWatch_OwnerId",
                table: "ToWatch",
                newName: "IX_ToWatch_UserId");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "Reviews",
                newName: "RatedMovieId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_MovieId",
                table: "Reviews",
                newName: "IX_Reviews_RatedMovieId");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Movies",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Movies_RatedMovieId",
                table: "Reviews",
                column: "RatedMovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ToWatch_Users_UserId",
                table: "ToWatch",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
