using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment10.Migrations
{
    public partial class NewDbDay10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Depts",
                columns: table => new
                {
                    Department_ModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Department_Name = table.Column<string>(nullable: true),
                    Total_Employees = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depts", x => x.Department_ModelId);
                });

            migrationBuilder.CreateTable(
                name: "Emps",
                columns: table => new
                {
                    Employees_ModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Employee_name = table.Column<string>(nullable: true),
                    Employee_Email = table.Column<string>(nullable: true),
                    Emp_Dep_Id = table.Column<int>(nullable: false),
                    Department_ModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emps", x => x.Employees_ModelId);
                    table.ForeignKey(
                        name: "FK_Emps_Depts_Department_ModelId",
                        column: x => x.Department_ModelId,
                        principalTable: "Depts",
                        principalColumn: "Department_ModelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emps_Department_ModelId",
                table: "Emps",
                column: "Department_ModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emps");

            migrationBuilder.DropTable(
                name: "Depts");
        }
    }
}
