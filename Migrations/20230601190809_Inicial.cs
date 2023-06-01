using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IDentyfica.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nome_pessoa = table.Column<string>(type: "text", nullable: false),
                    cpf_pessoa = table.Column<string>(type: "text", nullable: false),
                    data_nascimento_pessoa = table.Column<DateOnly>(type: "date", nullable: false),
                    endereco_pessoa = table.Column<string>(type: "text", nullable: false),
                    sexo_pessoa = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pessoas");
        }
    }
}
