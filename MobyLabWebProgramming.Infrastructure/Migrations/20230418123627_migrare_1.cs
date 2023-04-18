using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobyLabWebProgramming.Infrastructure.Migrations
{
    public partial class migrare_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adrese_User_UserId",
                table: "Adrese");

            migrationBuilder.DropForeignKey(
                name: "FK_Adrese_User_UserId1",
                table: "Adrese");

            migrationBuilder.DropIndex(
                name: "IX_Adrese_UserId1",
                table: "Adrese");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Adrese");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Adrese",
                newName: "UserIdAdresa");

            migrationBuilder.RenameIndex(
                name: "IX_Adrese_UserId",
                table: "Adrese",
                newName: "IX_Adrese_UserIdAdresa");

            migrationBuilder.AddColumn<Guid>(
                name: "AdresaLivrareId",
                table: "User",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_User_AdresaLivrareId",
                table: "User",
                column: "AdresaLivrareId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adrese_User_UserIdAdresa",
                table: "Adrese",
                column: "UserIdAdresa",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Adrese_AdresaLivrareId",
                table: "User",
                column: "AdresaLivrareId",
                principalTable: "Adrese",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adrese_User_UserIdAdresa",
                table: "Adrese");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Adrese_AdresaLivrareId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_AdresaLivrareId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "AdresaLivrareId",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "UserIdAdresa",
                table: "Adrese",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Adrese_UserIdAdresa",
                table: "Adrese",
                newName: "IX_Adrese_UserId");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                table: "Adrese",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Adrese_UserId1",
                table: "Adrese",
                column: "UserId1",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Adrese_User_UserId",
                table: "Adrese",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Adrese_User_UserId1",
                table: "Adrese",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
