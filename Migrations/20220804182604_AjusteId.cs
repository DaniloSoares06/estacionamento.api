using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace Estacionamento.API.Migrations
{
    public partial class AjusteId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PATIO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Endereco = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    Capacidade = table.Column<int>(type: "int", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    Bairro = table.Column<string>(type: "varchar(24)", maxLength: 24, nullable: false),
                    UF = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false),
                    Faturado = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PATIO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VEICULO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Placa = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false),
                    Cor = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    Modelo = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    Proprietario = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VEICULO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VEICULO_PATIO",
                columns: table => new
                {
                    VeiculoId = table.Column<int>(type: "int", nullable: false),
                    PatioId = table.Column<int>(type: "int", nullable: false),
                    HoraEntrada = table.Column<DateTime>(type: "datetime", nullable: false),
                    HoraSaida = table.Column<DateTime>(type: "datetime", nullable: false),
                    Valor = table.Column<double>(type: "double", nullable: false),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VEICULO_PATIO", x => new { x.VeiculoId, x.PatioId });
                    table.ForeignKey(
                        name: "FK_VEICULO_PATIO_PATIO_PatioId",
                        column: x => x.PatioId,
                        principalTable: "PATIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VEICULO_PATIO_VEICULO_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "VEICULO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VEICULO_PATIO_PatioId",
                table: "VEICULO_PATIO",
                column: "PatioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VEICULO_PATIO");

            migrationBuilder.DropTable(
                name: "PATIO");

            migrationBuilder.DropTable(
                name: "VEICULO");
        }
    }
}
