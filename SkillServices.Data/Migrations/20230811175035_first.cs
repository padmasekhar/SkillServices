using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillServices.Data.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblSkillCategories",
                columns: table => new
                {
                    SkillCategoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSkillCategories", x => x.SkillCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "tblSkillSubCategories",
                columns: table => new
                {
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SkillCategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSkillSubCategories", x => x.SubCategoryId);
                    table.ForeignKey(
                        name: "FK_tblSkillSubCategories_tblSkillCategories_SkillCategoryId",
                        column: x => x.SkillCategoryId,
                        principalTable: "tblSkillCategories",
                        principalColumn: "SkillCategoryId");
                });

            migrationBuilder.CreateTable(
                name: "tblSkills",
                columns: table => new
                {
                    SkillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SubCategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSkills", x => x.SkillId);
                    table.ForeignKey(
                        name: "FK_tblSkills_tblSkillSubCategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "tblSkillSubCategories",
                        principalColumn: "SubCategoryId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblSkills_SubCategoryId",
                table: "tblSkills",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tblSkillSubCategories_SkillCategoryId",
                table: "tblSkillSubCategories",
                column: "SkillCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblSkills");

            migrationBuilder.DropTable(
                name: "tblSkillSubCategories");

            migrationBuilder.DropTable(
                name: "tblSkillCategories");
        }
    }
}
