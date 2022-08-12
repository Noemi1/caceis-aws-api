using Microsoft.EntityFrameworkCore.Migrations;

namespace caceis_aws_api.Migrations
{
    public partial class caceisaws : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arquivo",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(nullable: true),
                    permitida = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arquivo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Monitor",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    transStatus = table.Column<string>(nullable: true),
                    tipoTransferencia = table.Column<string>(nullable: true),
                    dataHoraInicia = table.Column<string>(nullable: true),
                    dataHoraFinal = table.Column<string>(nullable: true),
                    bucketOrigem = table.Column<string>(nullable: true),
                    bucketDestino = table.Column<string>(nullable: true),
                    nomeArquivo = table.Column<string>(nullable: true),
                    observacoes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monitor", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Parceiros",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(nullable: true),
                    codigo = table.Column<string>(nullable: true),
                    autenticacaoId = table.Column<int>(nullable: false),
                    conexaoId = table.Column<int>(nullable: false),
                    conexaoHost = table.Column<string>(nullable: true),
                    conexaoPorta = table.Column<string>(nullable: true),
                    usuario = table.Column<string>(nullable: true),
                    senha = table.Column<string>(nullable: true),
                    senhaPrivada = table.Column<string>(nullable: true),
                    chavePrivada = table.Column<string>(nullable: true),
                    dataDaCriacao = table.Column<string>(nullable: true),
                    dataDaAlteracao = table.Column<string>(nullable: true),
                    autenticacao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parceiros", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Red",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codClienteFrom = table.Column<string>(nullable: true),
                    codClienteTo = table.Column<string>(nullable: true),
                    prefixo = table.Column<string>(nullable: true),
                    palavraChave1 = table.Column<string>(nullable: true),
                    palavraChave2 = table.Column<string>(nullable: true),
                    observacoes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Red", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TipoAutenticacao",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoAutenticacao", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TipoConexao",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoConexao", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arquivo");

            migrationBuilder.DropTable(
                name: "Monitor");

            migrationBuilder.DropTable(
                name: "Parceiros");

            migrationBuilder.DropTable(
                name: "Red");

            migrationBuilder.DropTable(
                name: "TipoAutenticacao");

            migrationBuilder.DropTable(
                name: "TipoConexao");
        }
    }
}
