using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GovernmentTechnicalVocationalCollege.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenameAttendanceProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_InstructingAssignments_TeachingAssignmentId",
                table: "Attendances");

            migrationBuilder.RenameColumn(
                name: "TeachingAssignmentId",
                table: "Attendances",
                newName: "InstructingAssignmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendances_TeachingAssignmentId",
                table: "Attendances",
                newName: "IX_Attendances_InstructingAssignmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_InstructingAssignments_InstructingAssignmentId",
                table: "Attendances",
                column: "InstructingAssignmentId",
                principalTable: "InstructingAssignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_InstructingAssignments_InstructingAssignmentId",
                table: "Attendances");

            migrationBuilder.RenameColumn(
                name: "InstructingAssignmentId",
                table: "Attendances",
                newName: "TeachingAssignmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendances_InstructingAssignmentId",
                table: "Attendances",
                newName: "IX_Attendances_TeachingAssignmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_InstructingAssignments_TeachingAssignmentId",
                table: "Attendances",
                column: "TeachingAssignmentId",
                principalTable: "InstructingAssignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
