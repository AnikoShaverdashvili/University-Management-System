using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityManagementSystemFinal.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subject_Schedule_ScheduleId",
                schema: "uni",
                table: "Subject");

            migrationBuilder.DropIndex(
                name: "IX_Subject_ScheduleId",
                schema: "uni",
                table: "Subject");

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                schema: "uni",
                table: "Schedule",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_SubjectId",
                schema: "uni",
                table: "Schedule",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Subject_SubjectId",
                schema: "uni",
                table: "Schedule",
                column: "SubjectId",
                principalSchema: "uni",
                principalTable: "Subject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Subject_SubjectId",
                schema: "uni",
                table: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_Schedule_SubjectId",
                schema: "uni",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                schema: "uni",
                table: "Schedule");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_ScheduleId",
                schema: "uni",
                table: "Subject",
                column: "ScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_Schedule_ScheduleId",
                schema: "uni",
                table: "Subject",
                column: "ScheduleId",
                principalSchema: "uni",
                principalTable: "Schedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
