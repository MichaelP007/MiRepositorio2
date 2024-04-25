using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mvcProyectoWeb1.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class actualizacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Tipo",
                table: "Transacciones",
                type: "char(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Tipo",
                table: "Transacciones",
                type: "char(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(20)");
        }
    }
}
