using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace WebAPIPeliculas.Migrations
{
    public partial class refa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false, comment: "Nombre del Actor"),
                    Biografia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actor", x => x.Id);
                },
                comment: "Actores");

            migrationBuilder.CreateTable(
                name: "Cine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identificador consecutivo Unico")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false, comment: "Nombre del Cine"),
                    Ubicacion = table.Column<Point>(type: "geography", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cine", x => x.Id);
                },
                comment: "Lista de los datos de los Cines");

            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false, comment: "Nombre del Genero de Pelicula")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.Id);
                },
                comment: "Generos de Peliculas");

            migrationBuilder.CreateTable(
                name: "Pelicula",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false, comment: "Titulo de la Pelicula"),
                    EnCartelera = table.Column<bool>(type: "bit", nullable: false, comment: "Si esta en Cartelera"),
                    FechaEstreno = table.Column<DateTime>(type: "date", nullable: true, comment: "Fecha de Estreno"),
                    PosterURL = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false, comment: "Imagen del poster de la Pelicula")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pelicula", x => x.Id);
                },
                comment: "Listado de Peliculas");

            migrationBuilder.CreateTable(
                name: "Refaccionaria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false, comment: "Nombre de la Refaccionaria"),
                    Ubicacion = table.Column<Point>(type: "geography", nullable: true, comment: "La Ubicacion de la Refaccionaria (Longitud y Latitud)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refaccionaria", x => x.Id);
                },
                comment: "Lista de todas las Refaccionarias");

            migrationBuilder.CreateTable(
                name: "CineOferta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaInicio = table.Column<DateTime>(type: "date", nullable: false, comment: "Fecha de Inicio de la Oferta"),
                    FechaFin = table.Column<DateTime>(type: "date", nullable: false, comment: "Fecha de Fin de la Oferta"),
                    PorcentajeDescuento = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    CineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CineOferta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CineOferta_Cine_CineId",
                        column: x => x.CineId,
                        principalTable: "Cine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Ofertas de descuento del cine");

            migrationBuilder.CreateTable(
                name: "SalaCine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoSalaCine = table.Column<int>(type: "int", nullable: false, defaultValue: 1, comment: "Tipo de sala de cine"),
                    Precio = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false, comment: "Precio de la entrada a la Sala de Cine"),
                    CineId = table.Column<int>(type: "int", nullable: false, comment: "el Id del cine al que pertenece la sala")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaCine", x => x.Id);
                    table.ForeignKey(
                        name: "Fk_SalaCine_Cine",
                        column: x => x.CineId,
                        principalTable: "Cine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Salas de Cine");

            migrationBuilder.CreateTable(
                name: "PeliculaActor",
                columns: table => new
                {
                    IdPelicula = table.Column<int>(type: "int", nullable: false, comment: "Id consecutivo de la tabla de peliculas"),
                    IdActor = table.Column<int>(type: "int", nullable: false, comment: "Id consecutivo de la tabla de actores"),
                    Personaje = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Nombre del personaje del actor"),
                    Orden = table.Column<int>(type: "int", nullable: false, comment: "Orden de importancia en la pelicula")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeliculaActor", x => new { x.IdPelicula, x.IdActor });
                    table.ForeignKey(
                        name: "Fk_PeliculaActor_Actor",
                        column: x => x.IdActor,
                        principalTable: "Actor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Fk_PeliculaActor_Pelicula",
                        column: x => x.IdPelicula,
                        principalTable: "Pelicula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Relacion de actores y peliculas");

            migrationBuilder.CreateTable(
                name: "PeliculaGenero",
                columns: table => new
                {
                    IdPelicula = table.Column<int>(type: "int", nullable: false, comment: "El Id consecutivo de la tabla de Pelicula"),
                    IdGenero = table.Column<int>(type: "int", nullable: false, comment: "El Id consecutivo de la tabla de generos")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeliculaGenero", x => new { x.IdPelicula, x.IdGenero });
                    table.ForeignKey(
                        name: "Fk_PeliculaGenero_Genero",
                        column: x => x.IdGenero,
                        principalTable: "Genero",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "Fk_PeliculaGenero_Pelicula",
                        column: x => x.IdPelicula,
                        principalTable: "Pelicula",
                        principalColumn: "Id");
                },
                comment: "Relacion de muchos a muchos entre genero y pelicula");

            migrationBuilder.CreateTable(
                name: "PeliculaSalaCine",
                columns: table => new
                {
                    IdPelicula = table.Column<int>(type: "int", nullable: false, comment: "El id de la tabla de Pelicula"),
                    IdSalaCine = table.Column<int>(type: "int", nullable: false, comment: "El id de la tabla de Sala de Cine")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeliculaSalaCine", x => new { x.IdPelicula, x.IdSalaCine });
                    table.ForeignKey(
                        name: "Fk_PeliculaSalaCine_Pelicula",
                        column: x => x.IdPelicula,
                        principalTable: "Pelicula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Fk_PeliculaSalaCine_SalaCine",
                        column: x => x.IdSalaCine,
                        principalTable: "SalaCine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Relacion de las peliculas en las salas de cine");

            migrationBuilder.InsertData(
                table: "Actor",
                columns: new[] { "Id", "Biografia", "FechaNacimiento", "Nombre" },
                values: new object[,]
                {
                    { 1, "Thomas Stanley Holland (Kingston upon Thames, Londres; 1 de junio de 1996), conocido simplemente como Tom Holland, es un actor, actor de voz y bailarín británico.", new DateTime(1996, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tom Holland" },
                    { 2, "Samuel Leroy Jackson (Washington D. C., 21 de diciembre de 1948), conocido como Samuel L. Jackson, es un actor y productor de cine, televisión y teatro estadounidense. Ha sido candidato al premio Óscar, a los Globos de Oro y al Premio del Sindicato de Actores, así como ganador de un BAFTA al mejor actor de reparto.", new DateTime(1948, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Samuel L. Jackson" },
                    { 3, "Robert John Downey Jr. (Nueva York, 4 de abril de 1965) es un actor, actor de voz, productor y cantante estadounidense. Inició su carrera como actor a temprana edad apareciendo en varios filmes dirigidos por su padre, Robert Downey Sr., y en su infancia estudió actuación en varias academias de Nueva York.", new DateTime(1965, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert Downey Jr." },
                    { 4, null, new DateTime(1981, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chris Evans" },
                    { 5, null, new DateTime(1972, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dwayne Johnson" },
                    { 6, null, new DateTime(2000, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Auli'i Cravalho" },
                    { 7, null, new DateTime(1984, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Scarlett Johansson" },
                    { 8, null, new DateTime(1964, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Keanu Reeves" }
                });

            migrationBuilder.InsertData(
                table: "Cine",
                columns: new[] { "Id", "Nombre", "Ubicacion" },
                values: new object[,]
                {
                    { 1, "Agora Mall", (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-69.9388777 18.4839233)") },
                    { 2, "Sambil", (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-69.911582 18.482455)") },
                    { 3, "Megacentro", (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-69.856309 18.506662)") },
                    { 4, "Acropolis", (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-69.939248 18.469649)") }
                });

            migrationBuilder.InsertData(
                table: "Genero",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Acción" },
                    { 2, "Animación" },
                    { 3, "Comedia" },
                    { 4, "Ciencia ficción" },
                    { 5, "Drama" }
                });

            migrationBuilder.InsertData(
                table: "Pelicula",
                columns: new[] { "Id", "EnCartelera", "FechaEstreno", "PosterURL", "Titulo" },
                values: new object[,]
                {
                    { 1, false, new DateTime(2012, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://upload.wikimedia.org/wikipedia/en/8/8a/The_Avengers_%282012_film%29_poster.jpg", "Avengers" },
                    { 2, false, new DateTime(2017, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://upload.wikimedia.org/wikipedia/en/9/98/Coco_%282017_film%29_poster.jpg", "Coco" },
                    { 3, false, new DateTime(2021, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg", "Spider-Man: No way home" },
                    { 4, false, new DateTime(2019, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg", "Spider-Man: Far From Home" },
                    { 5, true, new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Local), "https://upload.wikimedia.org/wikipedia/en/5/50/The_Matrix_Resurrections.jpg", "The Matrix Resurrections" }
                });

            migrationBuilder.InsertData(
                table: "Refaccionaria",
                columns: new[] { "Id", "Nombre", "Ubicacion" },
                values: new object[,]
                {
                    { 1, "Auto Partes LALO I", (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-97.830609 25.666709)") },
                    { 2, "Auto Partes LALO II", (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-97.80884 25.672184)") },
                    { 3, "Auto Partes LALO III", (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-97.806409 25.666665)") },
                    { 4, "Auto Partes LALO IV", (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-97.815993 25.661466)") },
                    { 5, "Auto Partes LALO V", (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-97.513383 25.823908)") }
                });

            migrationBuilder.InsertData(
                table: "CineOferta",
                columns: new[] { "Id", "CineId", "FechaFin", "FechaInicio", "PorcentajeDescuento" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 3, 22, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Local), 10m },
                    { 2, 4, new DateTime(2022, 3, 20, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Local), 15m }
                });

            migrationBuilder.InsertData(
                table: "PeliculaActor",
                columns: new[] { "IdActor", "IdPelicula", "Orden", "Personaje" },
                values: new object[,]
                {
                    { 3, 1, 2, "Iron Man" },
                    { 4, 1, 1, "Capitán América" },
                    { 7, 1, 3, "Black Widow" },
                    { 1, 3, 1, "Peter Parker" },
                    { 1, 4, 1, "Peter Parker" },
                    { 2, 4, 2, "Samuel L. Jackson" },
                    { 8, 5, 1, "Neo" }
                });

            migrationBuilder.InsertData(
                table: "PeliculaGenero",
                columns: new[] { "IdGenero", "IdPelicula" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 4, 1 },
                    { 2, 2 },
                    { 1, 3 },
                    { 3, 3 },
                    { 4, 3 },
                    { 1, 4 },
                    { 3, 4 },
                    { 4, 4 },
                    { 1, 5 },
                    { 4, 5 },
                    { 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "SalaCine",
                columns: new[] { "Id", "CineId", "Precio", "TipoSalaCine" },
                values: new object[,]
                {
                    { 1, 1, 220m, 1 },
                    { 2, 1, 320m, 2 },
                    { 3, 2, 200m, 1 },
                    { 4, 2, 290m, 2 },
                    { 5, 3, 250m, 1 },
                    { 6, 3, 330m, 2 },
                    { 7, 3, 450m, 3 },
                    { 8, 4, 250m, 1 }
                });

            migrationBuilder.InsertData(
                table: "PeliculaSalaCine",
                columns: new[] { "IdPelicula", "IdSalaCine" },
                values: new object[,]
                {
                    { 5, 1 },
                    { 5, 2 },
                    { 5, 3 },
                    { 5, 4 },
                    { 5, 5 },
                    { 5, 6 },
                    { 5, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "Ix_NoDuplicadoNombre",
                table: "Actor",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Ix_NoDupNombre",
                table: "Cine",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CineOferta_CineId",
                table: "CineOferta",
                column: "CineId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Ix_NoDuplicado",
                table: "CineOferta",
                columns: new[] { "CineId", "FechaInicio", "FechaFin" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NoDuplicadoNombre",
                table: "Genero",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NoDupTitulo",
                table: "Pelicula",
                column: "Titulo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Ix_NoDuplicado1",
                table: "PeliculaActor",
                columns: new[] { "IdActor", "IdPelicula" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Ix_NoDuplicado2",
                table: "PeliculaGenero",
                columns: new[] { "IdPelicula", "IdGenero" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PeliculaGenero_IdGenero",
                table: "PeliculaGenero",
                column: "IdGenero");

            migrationBuilder.CreateIndex(
                name: "Ix_NoDuplicado3",
                table: "PeliculaSalaCine",
                columns: new[] { "IdPelicula", "IdSalaCine" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PeliculaSalaCine_IdSalaCine",
                table: "PeliculaSalaCine",
                column: "IdSalaCine");

            migrationBuilder.CreateIndex(
                name: "Ix_NoDupNombreRefa",
                table: "Refaccionaria",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Ix_NoDuplicado4",
                table: "SalaCine",
                columns: new[] { "CineId", "Precio" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CineOferta");

            migrationBuilder.DropTable(
                name: "PeliculaActor");

            migrationBuilder.DropTable(
                name: "PeliculaGenero");

            migrationBuilder.DropTable(
                name: "PeliculaSalaCine");

            migrationBuilder.DropTable(
                name: "Refaccionaria");

            migrationBuilder.DropTable(
                name: "Actor");

            migrationBuilder.DropTable(
                name: "Genero");

            migrationBuilder.DropTable(
                name: "Pelicula");

            migrationBuilder.DropTable(
                name: "SalaCine");

            migrationBuilder.DropTable(
                name: "Cine");
        }
    }
}
