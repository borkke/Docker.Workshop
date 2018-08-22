using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Users.Migrations
{
    public partial class UsersInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Conuntry = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "City", "Conuntry", "FirstName", "LastName", "Number", "Street" },
                values: new object[] { 1, "Novi Sad", "Serbia", "Aleksandar", "Borkovac", "yyy", "xxx" });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "City", "Conuntry", "FirstName", "LastName", "Number", "Street" },
                values: new object[] { 2, "London", "United Kingdom", "Marko", "Markovic", "yyy", "xxx" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");
        }
    }
}
