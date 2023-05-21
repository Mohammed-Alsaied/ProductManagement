using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddPermission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "Permissions",
               columns: table => new
               {
                   Id = table.Column<int>(type: "uniqueidentifier", nullable: false),
                   Action = table.Column<string>(type: "nvarchar(max)", nullable: true),
                   Resource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                   RoleId = table.Column<string>(type: "nvarchar(450)", nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Permissions", x => x.Id);
                   table.ForeignKey(
                       name: "FK_Permissions_AspNetRoles_RoleId",
                       column: x => x.RoleId,
                       principalTable: "AspNetRoles",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Restrict);
               });

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_RoleId",
                table: "Permissions",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "Permissions");
        }
    }
}
