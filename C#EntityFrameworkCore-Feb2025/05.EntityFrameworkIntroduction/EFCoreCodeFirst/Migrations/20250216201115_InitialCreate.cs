using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreCodeFirst.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Record indetifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Article title"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Article content"),
                    Author = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "Article author")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                },
                comment: "Articles posted on my blog");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
