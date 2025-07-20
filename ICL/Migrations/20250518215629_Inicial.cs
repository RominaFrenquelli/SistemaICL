using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ICL.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RazonSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cuil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Enable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DetalleDeListaDePrecios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServicioId = table.Column<int>(type: "int", nullable: false),
                    Servicio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Enable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleDeListaDePrecios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ListaDePrecios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Enable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaDePrecios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Enable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Redactor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Enable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Redactor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servicio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Enable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Solicitud",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    Enable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitud", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Solicitud_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PedidoPostulante",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoPedido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DNI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaDeNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaDeIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaDeEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolicitudId = table.Column<int>(type: "int", nullable: false),
                    ServicioId = table.Column<int>(type: "int", nullable: false),
                    RedactorId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RedactorId1 = table.Column<int>(type: "int", nullable: true),
                    ProveedorId = table.Column<int>(type: "int", nullable: true),
                    ClienteId = table.Column<int>(type: "int", nullable: true),
                    Enable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoPostulante", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidoPostulante_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PedidoPostulante_Proveedor_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PedidoPostulante_Redactor_RedactorId1",
                        column: x => x.RedactorId1,
                        principalTable: "Redactor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PedidoPostulante_Servicio_ServicioId",
                        column: x => x.ServicioId,
                        principalTable: "Servicio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoPostulante_Solicitud_SolicitudId",
                        column: x => x.SolicitudId,
                        principalTable: "Solicitud",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PedidoPostulante_ClienteId",
                table: "PedidoPostulante",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoPostulante_ProveedorId",
                table: "PedidoPostulante",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoPostulante_RedactorId1",
                table: "PedidoPostulante",
                column: "RedactorId1");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoPostulante_ServicioId",
                table: "PedidoPostulante",
                column: "ServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoPostulante_SolicitudId",
                table: "PedidoPostulante",
                column: "SolicitudId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitud_ClienteId",
                table: "Solicitud",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleDeListaDePrecios");

            migrationBuilder.DropTable(
                name: "ListaDePrecios");

            migrationBuilder.DropTable(
                name: "PedidoPostulante");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "Redactor");

            migrationBuilder.DropTable(
                name: "Servicio");

            migrationBuilder.DropTable(
                name: "Solicitud");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
