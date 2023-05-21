using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class SeedPermissionsData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Action", "Resource", "RoleId" },
                values: new object[,]
                {
                    { Guid.NewGuid, "Action.View", "Products", "548436b4-4e32-426d-a0ef-6ed5037fb2c4" },
                    { Guid.NewGuid, "Action.Create", "Products", "548436b4-4e32-426d-a0ef-6ed5037fb2c4" },
                    { Guid.NewGuid, "Action.Update", "Products", "548436b4-4e32-426d-a0ef-6ed5037fb2c4" },
                    { Guid.NewGuid, "Action.Upload", "Products", "548436b4-4e32-426d-a0ef-6ed5037fb2c4" },
                    { Guid.NewGuid, "Action.Delete", "Products", "548436b4-4e32-426d-a0ef-6ed5037fb2c4" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "Permissions",
            //    keyColumn: "Id",
            //    keyValues: new object[] { });
        }
    }
}
