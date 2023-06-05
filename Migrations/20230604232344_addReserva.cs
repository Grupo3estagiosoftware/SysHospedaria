using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoNugets.Migrations
{
    public partial class addReserva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataEntrada = table.Column<DateTime>(nullable: false),
                    DataSaida = table.Column<DateTime>(nullable: false),
                    NumPessoas = table.Column<int>(nullable: false),
                    Estado = table.Column<bool>(nullable: false),
                    HospedeId = table.Column<int>(nullable: false),
                    QuartoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reserva_Hospedes_HospedeId",
                        column: x => x.HospedeId,
                        principalTable: "Hospedes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reserva_Quartos_QuartoId",
                        column: x => x.QuartoId,
                        principalTable: "Quartos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_HospedeId",
                table: "Reserva",
                column: "HospedeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_QuartoId",
                table: "Reserva",
                column: "QuartoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reserva");
        }
    }
}
