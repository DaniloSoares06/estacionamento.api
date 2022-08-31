using Microsoft.EntityFrameworkCore.Migrations;

namespace Estacionamento.API.Migrations
{
    public partial class AlteraçãoDaPropriedadeVagas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VagasDisponiveis",
                table: "VEICULO_PATIO");

            migrationBuilder.AddColumn<int>(
                name: "VagasDisponiveis",
                table: "PATIO",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VagasDisponiveis",
                table: "PATIO");

            migrationBuilder.AddColumn<int>(
                name: "VagasDisponiveis",
                table: "VEICULO_PATIO",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
