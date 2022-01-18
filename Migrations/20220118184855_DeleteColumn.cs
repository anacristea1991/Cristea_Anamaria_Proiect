using Microsoft.EntityFrameworkCore.Migrations;

namespace Cristea_Anamaria_Proiect.Migrations
{
    public partial class DeleteColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalStaff_Room_ConsultationRoomId1",
                table: "MedicalStaff");

            migrationBuilder.RenameColumn(
                name: "ConsultationRoomId1",
                table: "MedicalStaff",
                newName: "ConsultationRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalStaff_ConsultationRoomId1",
                table: "MedicalStaff",
                newName: "IX_MedicalStaff_ConsultationRoomId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "County",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "City",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);


            migrationBuilder.AddForeignKey(
                name: "FK_MedicalStaff_Room_ConsultationRoomId",
                table: "MedicalStaff",
                column: "ConsultationRoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_County_CountyId",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalStaff_Room_ConsultationRoomId",
                table: "MedicalStaff");

            migrationBuilder.DropIndex(
                name: "IX_City_CountyId",
                table: "City");

            migrationBuilder.DropColumn(
                name: "CountyId",
                table: "City");

            migrationBuilder.RenameColumn(
                name: "ConsultationRoomId",
                table: "MedicalStaff",
                newName: "ConsultationRoomId1");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalStaff_ConsultationRoomId",
                table: "MedicalStaff",
                newName: "IX_MedicalStaff_ConsultationRoomId1");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "County",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "County",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "City",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "CityCountyId",
                table: "City",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_City_CityCountyId",
                table: "City",
                column: "CityCountyId");

            migrationBuilder.AddForeignKey(
                name: "FK_City_County_CityCountyId",
                table: "City",
                column: "CityCountyId",
                principalTable: "County",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalStaff_Room_ConsultationRoomId1",
                table: "MedicalStaff",
                column: "ConsultationRoomId1",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
