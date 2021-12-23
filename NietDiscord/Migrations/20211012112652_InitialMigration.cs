using Microsoft.EntityFrameworkCore.Migrations;

namespace NietDiscord.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sendfrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    messagecontents = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isedited = table.Column<bool>(type: "bit", nullable: false),
                    ispinned = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");
        }
    }
}
