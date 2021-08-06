using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevTraining.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_fornecedor",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    documento = table.Column<string>(type: "varchar(14)", nullable: false),
                    ativo = table.Column<bool>(nullable: false),
                    TipoFornecedor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_fornecedor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_endereco",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    estado = table.Column<string>(type: "varchar(50)", nullable: false),
                    cidade = table.Column<string>(type: "varchar(100)", nullable: false),
                    logradouro = table.Column<string>(type: "varchar(200)", nullable: false),
                    complemento = table.Column<string>(type: "varchar(250)", nullable: false),
                    cep = table.Column<string>(type: "varchar(8)", nullable: false),
                    bairro = table.Column<string>(type: "varchar(200)", nullable: false),
                    numero = table.Column<string>(type: "varchar(50)", nullable: false),
                    FornecedorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_endereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_endereco_t_fornecedor_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "t_fornecedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_produto",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    descricao = table.Column<string>(type: "varchar(1000)", nullable: false),
                    imagem = table.Column<string>(type: "varchar(100)", nullable: false),
                    valor = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    ativo = table.Column<bool>(nullable: false),
                    FornecedorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_produto_t_fornecedor_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "t_fornecedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_endereco_FornecedorId",
                table: "t_endereco",
                column: "FornecedorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_produto_FornecedorId",
                table: "t_produto",
                column: "FornecedorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_endereco");

            migrationBuilder.DropTable(
                name: "t_produto");

            migrationBuilder.DropTable(
                name: "t_fornecedor");
        }
    }
}
