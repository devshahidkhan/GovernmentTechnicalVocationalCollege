using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GovernmentTechnicalVocationalCollege.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAttendanceEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AdmissionId = table.Column<Guid>(type: "uuid", nullable: false),
                    TeachingAssignmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    AttendanceDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TrainingProgramId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attendances_Admissions_AdmissionId",
                        column: x => x.AdmissionId,
                        principalTable: "Admissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attendances_InstructingAssignments_TeachingAssignmentId",
                        column: x => x.TeachingAssignmentId,
                        principalTable: "InstructingAssignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attendances_Programs_TrainingProgramId",
                        column: x => x.TrainingProgramId,
                        principalTable: "Programs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_AdmissionId",
                table: "Attendances",
                column: "AdmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_TeachingAssignmentId",
                table: "Attendances",
                column: "TeachingAssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_TrainingProgramId",
                table: "Attendances",
                column: "TrainingProgramId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendances");
        }
    }
}
