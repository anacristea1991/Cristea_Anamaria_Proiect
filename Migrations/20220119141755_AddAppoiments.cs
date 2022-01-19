using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cristea_Anamaria_Proiect.Migrations
{
    public partial class AddAppoiments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId1 = table.Column<int>(type: "int", nullable: true),
                    MedicalStaffId1 = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointment_MedicalStaff_MedicalStaffId1",
                        column: x => x.MedicalStaffId1,
                        principalTable: "MedicalStaff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointment_Patient_PatientId1",
                        column: x => x.PatientId1,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_MedicalStaffId1",
                table: "Appointment",
                column: "MedicalStaffId1");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_PatientId1",
                table: "Appointment",
                column: "PatientId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointment");
        }
    }
}
