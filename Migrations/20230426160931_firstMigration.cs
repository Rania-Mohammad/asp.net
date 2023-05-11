using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectF.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    clientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    operationID = table.Column<int>(type: "int", nullable: false),
                    operationName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.clientID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    employeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    employeeimage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false),
                    salary = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.employeeID);
                });

            migrationBuilder.CreateTable(
                name: "finances",
                columns: table => new
                {
                    financeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    operationAmount = table.Column<double>(type: "float", nullable: false),
                    totalAmount = table.Column<double>(type: "float", nullable: false),
                    taxes = table.Column<double>(type: "float", nullable: false),
                    state = table.Column<bool>(type: "bit", nullable: false),
                    maintenanceAmount = table.Column<double>(type: "float", nullable: false),
                    operationID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_finances", x => x.financeID);
                });

            migrationBuilder.CreateTable(
                name: "operations",
                columns: table => new
                {
                    operationsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    operationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    startDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    clientID = table.Column<int>(type: "int", nullable: false),
                    financeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_operations", x => x.operationsID);
                    table.ForeignKey(
                        name: "FK_operations_clients_clientID",
                        column: x => x.clientID,
                        principalTable: "clients",
                        principalColumn: "clientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "to_do_list",
                columns: table => new
                {
                    to_do_listID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    taskID = table.Column<int>(type: "int", nullable: false),
                    taskName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    employeeID = table.Column<int>(type: "int", nullable: false),
                    deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    state = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_to_do_list", x => x.to_do_listID);
                    table.ForeignKey(
                        name: "FK_to_do_list_Employees_employeeID",
                        column: x => x.employeeID,
                        principalTable: "Employees",
                        principalColumn: "employeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "history",
                columns: table => new
                {
                    HistoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    operationID = table.Column<int>(type: "int", nullable: false),
                    operationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    operationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    egyPrice = table.Column<double>(type: "float", nullable: false),
                    dollarPrice = table.Column<double>(type: "float", nullable: false),
                    clientID = table.Column<int>(type: "int", nullable: false),
                    employeeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_history", x => x.HistoryID);
                    table.ForeignKey(
                        name: "FK_history_Employees_employeeID",
                        column: x => x.employeeID,
                        principalTable: "Employees",
                        principalColumn: "employeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_history_operations_operationID",
                        column: x => x.operationID,
                        principalTable: "operations",
                        principalColumn: "operationsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_history_employeeID",
                table: "history",
                column: "employeeID");

            migrationBuilder.CreateIndex(
                name: "IX_history_operationID",
                table: "history",
                column: "operationID");

            migrationBuilder.CreateIndex(
                name: "IX_operations_clientID",
                table: "operations",
                column: "clientID");

            migrationBuilder.CreateIndex(
                name: "IX_to_do_list_employeeID",
                table: "to_do_list",
                column: "employeeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "finances");

            migrationBuilder.DropTable(
                name: "history");

            migrationBuilder.DropTable(
                name: "to_do_list");

            migrationBuilder.DropTable(
                name: "operations");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "clients");
        }
    }
}
