using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Farfetch.Infra.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceRota",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Rota = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRota", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Toggle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    Flag = table.Column<bool>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toggle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToggleServiceRota",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ToggleId = table.Column<int>(nullable: true),
                    RotaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToggleServiceRota", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToggleServiceRota_ServiceRota_RotaId",
                        column: x => x.RotaId,
                        principalTable: "ServiceRota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ToggleServiceRota_Toggle_ToggleId",
                        column: x => x.ToggleId,
                        principalTable: "Toggle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToggleServiceRota_RotaId",
                table: "ToggleServiceRota",
                column: "RotaId");

            migrationBuilder.CreateIndex(
                name: "IX_ToggleServiceRota_ToggleId",
                table: "ToggleServiceRota",
                column: "ToggleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToggleServiceRota");

            migrationBuilder.DropTable(
                name: "ServiceRota");

            migrationBuilder.DropTable(
                name: "Toggle");
        }
    }
}
