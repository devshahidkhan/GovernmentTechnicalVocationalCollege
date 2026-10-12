using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GovernmentTechnicalVocationalCollege.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddInstructingAssignmentEntityAndAddRelationInEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InstructingAssignments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    InstructorId = table.Column<Guid>(type: "uuid", nullable: false),
                    TrainingProgramId = table.Column<Guid>(type: "uuid", nullable: false),
                    AcademicSessionId = table.Column<Guid>(type: "uuid", nullable: false),
                    AssignedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructingAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstructingAssignments_AcademicSessions_AcademicSessionId",
                        column: x => x.AcademicSessionId,
                        principalTable: "AcademicSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstructingAssignments_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstructingAssignments_Programs_TrainingProgramId",
                        column: x => x.TrainingProgramId,
                        principalTable: "Programs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InstructingAssignments_AcademicSessionId",
                table: "InstructingAssignments",
                column: "AcademicSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructingAssignments_InstructorId",
                table: "InstructingAssignments",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructingAssignments_TrainingProgramId",
                table: "InstructingAssignments",
                column: "TrainingProgramId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstructingAssignments");
        }
    }
}
