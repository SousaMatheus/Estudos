using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudBasicoClientes.Server.Migrations
{
    /// <inheritdoc />
    public partial class Idade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Idade",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Idade",
                table: "Clientes");
        }
    }
}
