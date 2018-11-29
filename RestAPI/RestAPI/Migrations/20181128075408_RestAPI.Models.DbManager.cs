using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestAPI.Migrations
{
    public partial class RestAPIModelsDbManager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shows",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ShowId = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shows", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ShowCast",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Castid = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    birthday = table.Column<DateTime>(nullable: true),
                    Showsid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowCast", x => x.id);
                    table.ForeignKey(
                        name: "FK_ShowCast_Shows_Showsid",
                        column: x => x.Showsid,
                        principalTable: "Shows",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShowCast_Showsid",
                table: "ShowCast",
                column: "Showsid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShowCast");

            migrationBuilder.DropTable(
                name: "Shows");
        }
    }
}
