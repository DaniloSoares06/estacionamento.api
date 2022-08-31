using Microsoft.EntityFrameworkCore.Migrations;

namespace Estacionamento.API.Migrations
{
    public partial class InclusaoDePropriedadesEmPatioEVeiculoPatio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VagasDisponiveis",
                table: "VEICULO_PATIO",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "PATIO",
                type: "varchar(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VagasDisponiveis",
                table: "VEICULO_PATIO");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "PATIO");
        }
    }
}
