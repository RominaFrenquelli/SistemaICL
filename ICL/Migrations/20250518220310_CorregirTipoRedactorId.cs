using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ICL.Migrations
{
    public partial class CorregirTipoRedactorId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoPostulante_Redactor_RedactorId1",
                table: "PedidoPostulante");

            migrationBuilder.DropIndex(
                name: "IX_PedidoPostulante_RedactorId1",
                table: "PedidoPostulante");

            migrationBuilder.DropColumn(
                name: "RedactorId1",
                table: "PedidoPostulante");

            migrationBuilder.AlterColumn<int>(
                name: "RedactorId",
                table: "PedidoPostulante",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PedidoPostulante_RedactorId",
                table: "PedidoPostulante",
                column: "RedactorId");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoPostulante_Redactor_RedactorId",
                table: "PedidoPostulante",
                column: "RedactorId",
                principalTable: "Redactor",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoPostulante_Redactor_RedactorId",
                table: "PedidoPostulante");

            migrationBuilder.DropIndex(
                name: "IX_PedidoPostulante_RedactorId",
                table: "PedidoPostulante");

            migrationBuilder.AlterColumn<string>(
                name: "RedactorId",
                table: "PedidoPostulante",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RedactorId1",
                table: "PedidoPostulante",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PedidoPostulante_RedactorId1",
                table: "PedidoPostulante",
                column: "RedactorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoPostulante_Redactor_RedactorId1",
                table: "PedidoPostulante",
                column: "RedactorId1",
                principalTable: "Redactor",
                principalColumn: "Id");
        }
    }
}
