using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Farfetch.Infra.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Protocol = table.Column<string>(nullable: true),
                    DescriptionToggle = table.Column<string>(nullable: true),
                    DescriptionServiceRota = table.Column<string>(nullable: true),
                    DescriptionProduto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceRota",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Authorization = table.Column<string>(nullable: true),
                    Rota = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
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
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toggle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceRotaToggle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Rota = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    ToggleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRotaToggle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceRotaToggle_Toggle_ToggleId",
                        column: x => x.ToggleId,
                        principalTable: "Toggle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ToggleServiceRota",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ToggleId = table.Column<int>(nullable: true),
                    ServiceRotaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToggleServiceRota", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToggleServiceRota_ServiceRota_ServiceRotaId",
                        column: x => x.ServiceRotaId,
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
                name: "IX_ServiceRotaToggle_ToggleId",
                table: "ServiceRotaToggle",
                column: "ToggleId");

            migrationBuilder.CreateIndex(
                name: "IX_ToggleServiceRota_ServiceRotaId",
                table: "ToggleServiceRota",
                column: "ServiceRotaId");

            migrationBuilder.CreateIndex(
                name: "IX_ToggleServiceRota_ToggleId",
                table: "ToggleServiceRota",
                column: "ToggleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "ServiceRotaToggle");

            migrationBuilder.DropTable(
                name: "ToggleServiceRota");

            migrationBuilder.DropTable(
                name: "ServiceRota");

            migrationBuilder.DropTable(
                name: "Toggle");
        }
    }
}
