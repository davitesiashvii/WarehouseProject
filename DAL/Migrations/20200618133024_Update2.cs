using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserShope_Sopes_ShopeID",
                table: "UserShope");

            migrationBuilder.DropForeignKey(
                name: "FK_UserShope_Users_UserID",
                table: "UserShope");

            migrationBuilder.DropTable(
                name: "UserProductions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserShope",
                table: "UserShope");

            migrationBuilder.RenameTable(
                name: "UserShope",
                newName: "UserShopes");

            migrationBuilder.RenameIndex(
                name: "IX_UserShope_UserID",
                table: "UserShopes",
                newName: "IX_UserShopes_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_UserShope_ShopeID",
                table: "UserShopes",
                newName: "IX_UserShopes_ShopeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserShopes",
                table: "UserShopes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserShopes_Sopes_ShopeID",
                table: "UserShopes",
                column: "ShopeID",
                principalTable: "Sopes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserShopes_Users_UserID",
                table: "UserShopes",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserShopes_Sopes_ShopeID",
                table: "UserShopes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserShopes_Users_UserID",
                table: "UserShopes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserShopes",
                table: "UserShopes");

            migrationBuilder.RenameTable(
                name: "UserShopes",
                newName: "UserShope");

            migrationBuilder.RenameIndex(
                name: "IX_UserShopes_UserID",
                table: "UserShope",
                newName: "IX_UserShope_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_UserShopes_ShopeID",
                table: "UserShope",
                newName: "IX_UserShope_ShopeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserShope",
                table: "UserShope",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserProductions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductionID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProductions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProductions_Productions_ProductionID",
                        column: x => x.ProductionID,
                        principalTable: "Productions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProductions_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProductions_ProductionID",
                table: "UserProductions",
                column: "ProductionID");

            migrationBuilder.CreateIndex(
                name: "IX_UserProductions_UserID",
                table: "UserProductions",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserShope_Sopes_ShopeID",
                table: "UserShope",
                column: "ShopeID",
                principalTable: "Sopes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserShope_Users_UserID",
                table: "UserShope",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
