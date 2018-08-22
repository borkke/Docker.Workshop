using Microsoft.EntityFrameworkCore.Migrations;

namespace Notes.Migrations
{
    public partial class NotesWitUsersAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerFullName",
                table: "Notes");

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Notes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "OwnerId", "Text" },
                values: new object[] { 1, 1, "pick up groceries" });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "OwnerId", "Text" },
                values: new object[] { 2, 1, "pay electricity" });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "OwnerId", "Text" },
                values: new object[] { 3, 2, "have meeting with boss" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Notes");

            migrationBuilder.AddColumn<string>(
                name: "OwnerFullName",
                table: "Notes",
                nullable: true);
        }
    }
}
