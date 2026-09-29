using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EduTrack360.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PreparationDomains",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OptionLabel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreparationDomains", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PreparationOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsSystemDefined = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    PreparationDomainId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreparationOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreparationOptions_PreparationDomains_PreparationDomainId",
                        column: x => x.PreparationDomainId,
                        principalTable: "PreparationDomains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudyWorkspaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Goal = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TargetDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    PreparationDomainId = table.Column<int>(type: "int", nullable: false),
                    PreparationOptionId = table.Column<int>(type: "int", nullable: true),
                    CustomOptionName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyWorkspaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudyWorkspaces_PreparationDomains_PreparationDomainId",
                        column: x => x.PreparationDomainId,
                        principalTable: "PreparationDomains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudyWorkspaces_PreparationOptions_PreparationOptionId",
                        column: x => x.PreparationOptionId,
                        principalTable: "PreparationOptions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StudyTopics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    PlannedHours = table.Column<double>(type: "float", nullable: false),
                    ActualHours = table.Column<double>(type: "float", nullable: false),
                    TargetDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StudyWorkspaceId = table.Column<int>(type: "int", nullable: false),
                    ParentTopicId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyTopics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudyTopics_StudyTopics_ParentTopicId",
                        column: x => x.ParentTopicId,
                        principalTable: "StudyTopics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudyTopics_StudyWorkspaces_StudyWorkspaceId",
                        column: x => x.StudyWorkspaceId,
                        principalTable: "StudyWorkspaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PreparationDomains",
                columns: new[] { "Id", "IsActive", "Name", "OptionLabel" },
                values: new object[,]
                {
                    { 1, true, "University Study", "Department" },
                    { 2, true, "Job Preparation", "Career Track" },
                    { 3, true, "Bank Job Preparation", "Job Type" },
                    { 4, true, "BCS Preparation", "Preparation Stage" },
                    { 5, true, "Language Learning", "Language" },
                    { 6, true, "Higher Studies Preparation", "Study Goal" }
                });

            migrationBuilder.InsertData(
                table: "PreparationOptions",
                columns: new[] { "Id", "IsActive", "IsSystemDefined", "Name", "PreparationDomainId" },
                values: new object[,]
                {
                    { 1, true, true, "CSE", 1 },
                    { 2, true, true, "EEE", 1 },
                    { 3, true, true, "Civil Engineering", 1 },
                    { 4, true, true, "Pharmacy", 1 },
                    { 5, true, true, "BBA", 1 },
                    { 6, true, true, "Microbiology", 1 },
                    { 7, true, true, "C#/.NET Developer", 2 },
                    { 8, true, true, "Java Developer", 2 },
                    { 9, true, true, "Python Developer", 2 },
                    { 10, true, true, "DevOps Engineer", 2 },
                    { 11, true, true, "Bank IT", 3 },
                    { 12, true, true, "Officer", 3 },
                    { 13, true, true, "Preliminary", 4 },
                    { 14, true, true, "Written", 4 },
                    { 15, true, true, "Viva", 4 },
                    { 16, true, true, "English", 5 },
                    { 17, true, true, "Japanese", 5 },
                    { 18, true, true, "German", 5 },
                    { 19, true, true, "IELTS", 6 },
                    { 20, true, true, "GRE", 6 },
                    { 21, true, true, "Masters Admission", 6 },
                    { 22, true, true, "PhD Admission", 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PreparationOptions_PreparationDomainId",
                table: "PreparationOptions",
                column: "PreparationDomainId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyTopics_ParentTopicId",
                table: "StudyTopics",
                column: "ParentTopicId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyTopics_StudyWorkspaceId",
                table: "StudyTopics",
                column: "StudyWorkspaceId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyWorkspaces_PreparationDomainId",
                table: "StudyWorkspaces",
                column: "PreparationDomainId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyWorkspaces_PreparationOptionId",
                table: "StudyWorkspaces",
                column: "PreparationOptionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudyTopics");

            migrationBuilder.DropTable(
                name: "StudyWorkspaces");

            migrationBuilder.DropTable(
                name: "PreparationOptions");

            migrationBuilder.DropTable(
                name: "PreparationDomains");
        }
    }
}
