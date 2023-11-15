using Microsoft.EntityFrameworkCore.Migrations;
using ProjectTest.Domain;
using ProjectTest.Persistence.Services;

#nullable disable

namespace ProjectTest.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Events : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", maxLength: 55, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 155, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventMessageResult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Message = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    EventId = table.Column<int>(type: "INTEGER", maxLength: 55, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventMessageResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventMessageResult_EventType_EventId",
                        column: x => x.EventId,
                        principalTable: "EventType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventMessageResult_EventId",
                table: "EventMessageResult",
                column: "EventId");
            migrationBuilder.InsertData(
                table: "EventType",
                columns: new[] { nameof(EventType.Id), nameof(EventType.Code), nameof(EventType.Description) },
                values: new object[,]
                {
                    {1, "Email", "Using the Internet" },
                    {2, "SMS", "Using mobile phone" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventMessageResult");

            migrationBuilder.DropTable(
                name: "EventType");
        }
    }
}
