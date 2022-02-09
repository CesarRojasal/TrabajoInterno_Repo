using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrabajoInterno_Api_Persona.Migrations
{
    public partial class MigrationMySqlInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "persona",
                columns: table => new
                {
                    id_persona = table.Column<int>(type: "int", nullable: false, comment: "Id persona")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false, comment: "Nombre persona")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    apellido = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false, comment: "Apellidos persona")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    identificacion = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false, comment: "Identificacion persona")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    edad = table.Column<int>(type: "int", nullable: false, comment: "Edad persona"),
                    ciudad_Nacimiento = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false, comment: "Ciudad de nacimiento persona")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    correo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "Correo")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persona", x => x.id_persona);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "persona");
        }
    }
}
