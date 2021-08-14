using Microsoft.EntityFrameworkCore.Migrations;

namespace aec_webapi_entity_framework.Migrations
{
    public partial class CarroAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "marcas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marcas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "carros",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    modelo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    marca_id = table.Column<int>(type: "int", nullable: false),
                    ano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carros", x => x.id);
                    table.ForeignKey(
                        name: "FK_carros_marcas_marca_id",
                        column: x => x.marca_id,
                        principalTable: "marcas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_carros_marca_id",
                table: "carros",
                column: "marca_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "carros");

            migrationBuilder.DropTable(
                name: "marcas");
        }
    }
}
