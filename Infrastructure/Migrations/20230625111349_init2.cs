using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_departmentManagers_Employees_EmployeeId1",
                table: "departmentManagers");

            migrationBuilder.DropIndex(
                name: "IX_departmentManagers_EmployeeId1",
                table: "departmentManagers");

            migrationBuilder.DropColumn(
                name: "EmployeeId1",
                table: "departmentManagers");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "departmentManagers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_departmentManagers_EmployeeId",
                table: "departmentManagers",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_departmentManagers_Employees_EmployeeId",
                table: "departmentManagers",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_departmentManagers_Employees_EmployeeId",
                table: "departmentManagers");

            migrationBuilder.DropIndex(
                name: "IX_departmentManagers_EmployeeId",
                table: "departmentManagers");

            migrationBuilder.AlterColumn<long>(
                name: "EmployeeId",
                table: "departmentManagers",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId1",
                table: "departmentManagers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_departmentManagers_EmployeeId1",
                table: "departmentManagers",
                column: "EmployeeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_departmentManagers_Employees_EmployeeId1",
                table: "departmentManagers",
                column: "EmployeeId1",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
