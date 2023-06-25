using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    HireDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentEmployees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "integer", nullable: false),
                    DepartmentId = table.Column<int>(type: "integer", nullable: false),
                    FromDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ToDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentEmployees", x => new { x.DepartmentId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_DepartmentEmployees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentEmployees_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "departmentManagers",
                columns: table => new
                {
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    DepartmentId = table.Column<int>(type: "integer", nullable: false),
                    EmployeeId1 = table.Column<int>(type: "integer", nullable: false),
                    FromDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TODate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departmentManagers", x => new { x.DepartmentId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_departmentManagers_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_departmentManagers_Employees_EmployeeId1",
                        column: x => x.EmployeeId1,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Salaries",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    EmployeeId1 = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<long>(type: "bigint", nullable: false),
                    FromDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ToDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Salaries_Employees_EmployeeId1",
                        column: x => x.EmployeeId1,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentEmployees_EmployeeId",
                table: "DepartmentEmployees",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_departmentManagers_EmployeeId1",
                table: "departmentManagers",
                column: "EmployeeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_EmployeeId1",
                table: "Salaries",
                column: "EmployeeId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentEmployees");

            migrationBuilder.DropTable(
                name: "departmentManagers");

            migrationBuilder.DropTable(
                name: "Salaries");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
