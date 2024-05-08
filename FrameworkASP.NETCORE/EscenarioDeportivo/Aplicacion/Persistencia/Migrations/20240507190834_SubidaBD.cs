using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Migrations
{
    public partial class SubidaBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ColegiosInstrucciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nit = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    RazonSocial = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Deporte = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Licencia = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColegiosInstrucciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Municipios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patrocinadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Documento = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Deporte = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Personeria = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patrocinadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Deporte = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Jugadores = table.Column<int>(type: "int", nullable: false),
                    PatrocinadorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipos_Patrocinadores_PatrocinadorId",
                        column: x => x.PatrocinadorId,
                        principalTable: "Patrocinadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Torneos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Deporte = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CantidadEquipos = table.Column<int>(type: "int", nullable: false),
                    Etapa = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    MunicipioId = table.Column<int>(type: "int", nullable: false),
                    PatrocinadorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Torneos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Torneos_Municipios_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "Municipios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Torneos_Patrocinadores_PatrocinadorId",
                        column: x => x.PatrocinadorId,
                        principalTable: "Patrocinadores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Deportistas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Documento = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Deporte = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rh = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Eps = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    EquipoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deportistas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deportistas_Equipos_EquipoId",
                        column: x => x.EquipoId,
                        principalTable: "Equipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Entrenadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Documento = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Deporte = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EquipoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrenadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entrenadores_Equipos_EquipoId",
                        column: x => x.EquipoId,
                        principalTable: "Equipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Arbitros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Documento = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Deporte = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Rh = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    ColegioInstruccionId = table.Column<int>(type: "int", nullable: false),
                    TorneoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arbitros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Arbitros_ColegiosInstrucciones_ColegioInstruccionId",
                        column: x => x.ColegioInstruccionId,
                        principalTable: "ColegiosInstrucciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Arbitros_Torneos_TorneoId",
                        column: x => x.TorneoId,
                        principalTable: "Torneos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TorneoEquipos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipoId = table.Column<int>(type: "int", nullable: false),
                    TorneoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TorneoEquipos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TorneoEquipos_Equipos_EquipoId",
                        column: x => x.EquipoId,
                        principalTable: "Equipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TorneoEquipos_Torneos_TorneoId",
                        column: x => x.TorneoId,
                        principalTable: "Torneos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UnidadesDeportivas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    TorneoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadesDeportivas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnidadesDeportivas_Torneos_TorneoId",
                        column: x => x.TorneoId,
                        principalTable: "Torneos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Escenarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Espectadores = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UnidadDeportivaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escenarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Escenarios_UnidadesDeportivas_UnidadDeportivaId",
                        column: x => x.UnidadDeportivaId,
                        principalTable: "UnidadesDeportivas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Arbitros_ColegioInstruccionId",
                table: "Arbitros",
                column: "ColegioInstruccionId");

            migrationBuilder.CreateIndex(
                name: "IX_Arbitros_Documento",
                table: "Arbitros",
                column: "Documento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Arbitros_TorneoId",
                table: "Arbitros",
                column: "TorneoId");

            migrationBuilder.CreateIndex(
                name: "IX_ColegiosInstrucciones_Nit",
                table: "ColegiosInstrucciones",
                column: "Nit",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Deportistas_Documento",
                table: "Deportistas",
                column: "Documento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Deportistas_EquipoId",
                table: "Deportistas",
                column: "EquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Entrenadores_Documento",
                table: "Entrenadores",
                column: "Documento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entrenadores_EquipoId",
                table: "Entrenadores",
                column: "EquipoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_Nombre",
                table: "Equipos",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_PatrocinadorId",
                table: "Equipos",
                column: "PatrocinadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Escenarios_Nombre",
                table: "Escenarios",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Escenarios_UnidadDeportivaId",
                table: "Escenarios",
                column: "UnidadDeportivaId");

            migrationBuilder.CreateIndex(
                name: "IX_Municipios_Nombre",
                table: "Municipios",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patrocinadores_Documento",
                table: "Patrocinadores",
                column: "Documento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TorneoEquipos_EquipoId",
                table: "TorneoEquipos",
                column: "EquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_TorneoEquipos_TorneoId",
                table: "TorneoEquipos",
                column: "TorneoId");

            migrationBuilder.CreateIndex(
                name: "IX_Torneos_MunicipioId",
                table: "Torneos",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_Torneos_Nombre",
                table: "Torneos",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Torneos_PatrocinadorId",
                table: "Torneos",
                column: "PatrocinadorId");

            migrationBuilder.CreateIndex(
                name: "IX_UnidadesDeportivas_Nombre",
                table: "UnidadesDeportivas",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UnidadesDeportivas_TorneoId",
                table: "UnidadesDeportivas",
                column: "TorneoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arbitros");

            migrationBuilder.DropTable(
                name: "Deportistas");

            migrationBuilder.DropTable(
                name: "Entrenadores");

            migrationBuilder.DropTable(
                name: "Escenarios");

            migrationBuilder.DropTable(
                name: "TorneoEquipos");

            migrationBuilder.DropTable(
                name: "ColegiosInstrucciones");

            migrationBuilder.DropTable(
                name: "UnidadesDeportivas");

            migrationBuilder.DropTable(
                name: "Equipos");

            migrationBuilder.DropTable(
                name: "Torneos");

            migrationBuilder.DropTable(
                name: "Municipios");

            migrationBuilder.DropTable(
                name: "Patrocinadores");
        }
    }
}
