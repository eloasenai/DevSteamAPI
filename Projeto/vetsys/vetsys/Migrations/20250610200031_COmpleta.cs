using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vetsys.Migrations
{
    /// <inheritdoc />
    public partial class COmpleta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Automatico",
                columns: table => new
                {
                    AutomaticoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Animal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImagemUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Automatico", x => x.AutomaticoId);
                });

            migrationBuilder.CreateTable(
                name: "Cachorro",
                columns: table => new
                {
                    CachorroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Racao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Petisco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brinquedo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IngredienteOuSabor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tamanho = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Idade = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cachorro", x => x.CachorroId);
                });

            migrationBuilder.CreateTable(
                name: "Cadastro",
                columns: table => new
                {
                    CadastroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cadastro", x => x.CadastroId);
                });

            migrationBuilder.CreateTable(
                name: "Gato",
                columns: table => new
                {
                    GatoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Racao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Petisco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Areia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IngredienteOuSabor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tamanho = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Idade = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gato", x => x.GatoId);
                });

            migrationBuilder.CreateTable(
                name: "Itens",
                columns: table => new
                {
                    ItensId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImagemUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itens", x => x.ItensId);
                });

            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    LoginId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.LoginId);
                });

            migrationBuilder.CreateTable(
                name: "Oferta",
                columns: table => new
                {
                    OfertaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Remedio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coleira = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Petisco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Desconto = table.Column<double>(type: "float", nullable: false),
                    ValidoAte = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oferta", x => x.OfertaId);
                });

            migrationBuilder.CreateTable(
                name: "Passaros",
                columns: table => new
                {
                    PassarosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Racao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brinquedo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Acessorio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IngredienteOuSabor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tamanho = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Idade = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passaros", x => x.PassarosId);
                });

            migrationBuilder.CreateTable(
                name: "Roedores",
                columns: table => new
                {
                    RoedoresId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Racao = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Petisco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Acessorio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IngredienteOuSabor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tamanho = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Idade = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roedores", x => x.RoedoresId);
                });

            migrationBuilder.CreateTable(
                name: "Sacola",
                columns: table => new
                {
                    SacolaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sacola", x => x.SacolaId);
                });

            migrationBuilder.CreateTable(
                name: "TelaPagamento",
                columns: table => new
                {
                    TelaPagamentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MetodoPagamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelaPagamento", x => x.TelaPagamentoId);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    ProdutosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SacolaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.ProdutosId);
                    table.ForeignKey(
                        name: "FK_Produto_Sacola_SacolaId",
                        column: x => x.SacolaId,
                        principalTable: "Sacola",
                        principalColumn: "SacolaId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produto_SacolaId",
                table: "Produto",
                column: "SacolaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Automatico");

            migrationBuilder.DropTable(
                name: "Cachorro");

            migrationBuilder.DropTable(
                name: "Cadastro");

            migrationBuilder.DropTable(
                name: "Gato");

            migrationBuilder.DropTable(
                name: "Itens");

            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropTable(
                name: "Oferta");

            migrationBuilder.DropTable(
                name: "Passaros");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Roedores");

            migrationBuilder.DropTable(
                name: "TelaPagamento");

            migrationBuilder.DropTable(
                name: "Sacola");
        }
    }
}
