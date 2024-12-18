using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Cathedra.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "worker",
                columns: table => new
                {
                    worker_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_worker", x => x.worker_id);
                });

            migrationBuilder.CreateTable(
                name: "discipline",
                columns: table => new
                {
                    discipline_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    professor_id = table.Column<long>(type: "bigint", nullable: false),
                    helper_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_discipline", x => x.discipline_id);
                    table.ForeignKey(
                        name: "FK_discipline_worker_helper_id",
                        column: x => x.helper_id,
                        principalTable: "worker",
                        principalColumn: "worker_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_discipline_worker_professor_id",
                        column: x => x.professor_id,
                        principalTable: "worker",
                        principalColumn: "worker_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lesson",
                columns: table => new
                {
                    lesson_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    discipline_id = table.Column<long>(type: "bigint", nullable: false),
                    start_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lesson", x => x.lesson_id);
                    table.ForeignKey(
                        name: "FK_lesson_discipline_discipline_id",
                        column: x => x.discipline_id,
                        principalTable: "discipline",
                        principalColumn: "discipline_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_discipline_helper_id",
                table: "discipline",
                column: "helper_id");

            migrationBuilder.CreateIndex(
                name: "IX_discipline_professor_id",
                table: "discipline",
                column: "professor_id");

            migrationBuilder.CreateIndex(
                name: "IX_lesson_discipline_id",
                table: "lesson",
                column: "discipline_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "lesson");

            migrationBuilder.DropTable(
                name: "discipline");

            migrationBuilder.DropTable(
                name: "worker");
        }
    }
}
