using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mvcProyectoWeb1.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class actMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Categorias");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Categorias",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
