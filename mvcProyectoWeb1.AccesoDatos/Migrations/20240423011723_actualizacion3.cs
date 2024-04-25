using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mvcProyectoWeb1.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class actualizacion3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProveedorId",
                table: "Proveedores");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProveedorId",
                table: "Proveedores",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
