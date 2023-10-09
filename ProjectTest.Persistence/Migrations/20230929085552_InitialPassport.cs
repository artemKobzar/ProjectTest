using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectTest.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialPassport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PassportUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Nationality = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ValidDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassportUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PassportUser_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PassportUser_Id",
                table: "PassportUser",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PassportUser_UserId",
                table: "PassportUser",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PassportUser");
        }
    }
}
