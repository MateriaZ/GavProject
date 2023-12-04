using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GavResortsTest.Migrations
{
    /// <inheritdoc />
    public partial class PerfilAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Perfil",
                table: "Usuarios");

            migrationBuilder.AddColumn<int>(
                name: "PerfilId",
                table: "Usuarios",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Perfil",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfil", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_PerfilId",
                table: "Usuarios",
                column: "PerfilId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Perfil_PerfilId",
                table: "Usuarios",
                column: "PerfilId",
                principalTable: "Perfil",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Perfil_PerfilId",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "Perfil");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_PerfilId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "PerfilId",
                table: "Usuarios");

            migrationBuilder.AddColumn<string>(
                name: "Perfil",
                table: "Usuarios",
                type: "TEXT",
                nullable: true);
        }
    }
}
