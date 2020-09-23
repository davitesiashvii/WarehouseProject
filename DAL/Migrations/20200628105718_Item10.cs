using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Item10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductionShopes_Sopes_ShopeID",
                table: "ProductionShopes");

            migrationBuilder.DropTable(
                name: "Sopes");

            migrationBuilder.CreateTable(
                name: "Shopes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Address = table.Column<string>(maxLength: 200, nullable: false),
                    Type = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shopes", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionShopes_Shopes_ShopeID",
                table: "ProductionShopes",
                column: "ShopeID",
                principalTable: "Shopes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductionShopes_Shopes_ShopeID",
                table: "ProductionShopes");

            migrationBuilder.DropTable(
                name: "Shopes");

            migrationBuilder.CreateTable(
                name: "Sopes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sopes", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionShopes_Sopes_ShopeID",
                table: "ProductionShopes",
                column: "ShopeID",
                principalTable: "Sopes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
