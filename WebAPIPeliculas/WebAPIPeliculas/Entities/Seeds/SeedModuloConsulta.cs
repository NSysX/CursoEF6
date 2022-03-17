using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using WebAPIPeliculas.Enum;

namespace WebAPIPeliculas.Entities.Seeds
{
    public static class SeedModuloConsulta
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var acción = new Genero { Id = 1, Nombre = "Acción" };
            var animación = new Genero { Id = 2, Nombre = "Animación" };
            var comedia = new Genero { Id = 3, Nombre = "Comedia" };
            var cienciaFicción = new Genero { Id = 4, Nombre = "Ciencia ficción" };
            var drama = new Genero { Id = 5, Nombre = "Drama" };

            modelBuilder.Entity<Genero>().HasData(acción, animación, comedia, cienciaFicción, drama);

            var tomHolland = new Actor() { Id = 1, Nombre = "Tom Holland", FechaNacimiento = new DateTime(1996, 6, 1), Biografia = "Thomas Stanley Holland (Kingston upon Thames, Londres; 1 de junio de 1996), conocido simplemente como Tom Holland, es un actor, actor de voz y bailarín británico." };
            var samuelJackson = new Actor() { Id = 2, Nombre = "Samuel L. Jackson", FechaNacimiento = new DateTime(1948, 12, 21), Biografia = "Samuel Leroy Jackson (Washington D. C., 21 de diciembre de 1948), conocido como Samuel L. Jackson, es un actor y productor de cine, televisión y teatro estadounidense. Ha sido candidato al premio Óscar, a los Globos de Oro y al Premio del Sindicato de Actores, así como ganador de un BAFTA al mejor actor de reparto." };
            var robertDowney = new Actor() { Id = 3, Nombre = "Robert Downey Jr.", FechaNacimiento = new DateTime(1965, 4, 4), Biografia = "Robert John Downey Jr. (Nueva York, 4 de abril de 1965) es un actor, actor de voz, productor y cantante estadounidense. Inició su carrera como actor a temprana edad apareciendo en varios filmes dirigidos por su padre, Robert Downey Sr., y en su infancia estudió actuación en varias academias de Nueva York." };
            var chrisEvans = new Actor() { Id = 4, Nombre = "Chris Evans", FechaNacimiento = new DateTime(1981, 06, 13) };
            var laRoca = new Actor() { Id = 5, Nombre = "Dwayne Johnson", FechaNacimiento = new DateTime(1972, 5, 2) };
            var auliCravalho = new Actor() { Id = 6, Nombre = "Auli'i Cravalho", FechaNacimiento = new DateTime(2000, 11, 22) };
            var scarlettJohansson = new Actor() { Id = 7, Nombre = "Scarlett Johansson", FechaNacimiento = new DateTime(1984, 11, 22) };
            var keanuReeves = new Actor() { Id = 8, Nombre = "Keanu Reeves", FechaNacimiento = new DateTime(1964, 9, 2) };

            modelBuilder.Entity<Actor>().HasData(tomHolland, samuelJackson,
                            robertDowney, chrisEvans, laRoca, auliCravalho, scarlettJohansson, keanuReeves);

            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

            var agora = new Cine() { Id = 1, Nombre = "Agora Mall", Ubicacion = geometryFactory.CreatePoint(new Coordinate(-69.9388777, 18.4839233)) };
            var sambil = new Cine() { Id = 2, Nombre = "Sambil", Ubicacion = geometryFactory.CreatePoint(new Coordinate(-69.911582, 18.482455)) };
            var megacentro = new Cine() { Id = 3, Nombre = "Megacentro", Ubicacion = geometryFactory.CreatePoint(new Coordinate(-69.856309, 18.506662)) };
            var acropolis = new Cine() { Id = 4, Nombre = "Acropolis", Ubicacion = geometryFactory.CreatePoint(new Coordinate(-69.939248, 18.469649)) };

            var refa1 = new Refaccionaria { Id = 1, Nombre = "Auto Partes LALO I", Ubicacion = geometryFactory.CreatePoint(new Coordinate(-97.830609, 25.666709)) };

            var refa2 = new Refaccionaria { Id = 2, Nombre = "Auto Partes LALO II", Ubicacion = geometryFactory.CreatePoint(new Coordinate(-97.808840, 25.672184)) };

            var refa3 = new Refaccionaria { Id = 3, Nombre = "Auto Partes LALO III", Ubicacion = geometryFactory.CreatePoint(new Coordinate(-97.806409, 25.666665)) };

            var refa4 = new Refaccionaria { Id = 4, Nombre = "Auto Partes LALO IV", Ubicacion = geometryFactory.CreatePoint(new Coordinate(-97.815993, 25.661466)) };

            var refa5 = new Refaccionaria { Id = 5, Nombre = "Auto Partes LALO V", Ubicacion = geometryFactory.CreatePoint(new Coordinate(-97.513383, 25.823908)) };

            var agoraCineOferta = new CineOferta { Id = 1, CineId = agora.Id, FechaInicio = DateTime.Today, FechaFin = DateTime.Today.AddDays(7), PorcentajeDescuento = 10 };

            modelBuilder.Entity<Refaccionaria>().HasData(refa1, refa2, refa3, refa4, refa5);

            var salaDeCine2DAgora = new SalaCine()
            {
                Id = 1,
                CineId = agora.Id,
                Precio = 220,
                TipoSalaCine = TipoSalaCine.DosDimensiones
            };

            var salaDeCine3DAgora = new SalaCine()
            {
                Id = 2,
                CineId = agora.Id,
                Precio = 320,
                TipoSalaCine = TipoSalaCine.TresDimensiones
            };

            var salaDeCine2DSambil = new SalaCine()
            {
                Id = 3,
                CineId = sambil.Id,
                Precio = 200,
                TipoSalaCine = TipoSalaCine.DosDimensiones
            };

            var salaDeCine3DSambil = new SalaCine()
            {
                Id = 4,
                CineId = sambil.Id,
                Precio = 290,
                TipoSalaCine = TipoSalaCine.TresDimensiones
            };

            var salaDeCine2DMegacentro = new SalaCine()
            {
                Id = 5,
                CineId = megacentro.Id,
                Precio = 250,
                TipoSalaCine = TipoSalaCine.DosDimensiones
            };
            var salaDeCine3DMegacentro = new SalaCine()
            {
                Id = 6,
                CineId = megacentro.Id,
                Precio = 330,
                TipoSalaCine = TipoSalaCine.TresDimensiones
            };
            var salaDeCineCXCMegacentro = new SalaCine()
            {
                Id = 7,
                CineId = megacentro.Id,
                Precio = 450,
                TipoSalaCine = TipoSalaCine.CXC
            };

            var salaDeCine2DAcropolis = new SalaCine()
            {
                Id = 8,
                CineId = acropolis.Id,
                Precio = 250,
                TipoSalaCine = TipoSalaCine.DosDimensiones
            };

            var acropolisCineOferta = new CineOferta { Id = 2, CineId = acropolis.Id, FechaInicio = DateTime.Today, FechaFin = DateTime.Today.AddDays(5), PorcentajeDescuento = 15 };

            modelBuilder.Entity<Cine>().HasData(acropolis, sambil, megacentro, agora);
            modelBuilder.Entity<CineOferta>().HasData(acropolisCineOferta, agoraCineOferta);
            modelBuilder.Entity<SalaCine>().HasData(salaDeCine2DMegacentro, salaDeCine3DMegacentro, salaDeCineCXCMegacentro, salaDeCine2DAcropolis, salaDeCine2DAgora, salaDeCine3DAgora, salaDeCine2DSambil, salaDeCine3DSambil);


            var avengers = new Pelicula()
            {
                Id = 1,
                Titulo = "Avengers",
                EnCartelera = false,
                FechaEstreno = new DateTime(2012, 4, 11),
                PosterURL = "https://upload.wikimedia.org/wikipedia/en/8/8a/The_Avengers_%282012_film%29_poster.jpg",
            };

            var coco = new Pelicula()
            {
                Id = 2,
                Titulo = "Coco",
                EnCartelera = false,
                FechaEstreno = new DateTime(2017, 11, 22),
                PosterURL = "https://upload.wikimedia.org/wikipedia/en/9/98/Coco_%282017_film%29_poster.jpg"
            };

            var noWayHome = new Pelicula()
            {
                Id = 3,
                Titulo = "Spider-Man: No way home",
                EnCartelera = false,
                FechaEstreno = new DateTime(2021, 12, 17),
                PosterURL = "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg"
            };

            var farFromHome = new Pelicula()
            {
                Id = 4,
                Titulo = "Spider-Man: Far From Home",
                EnCartelera = false,
                FechaEstreno = new DateTime(2019, 7, 2),
                PosterURL = "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg"
            };

            var theMatrixResurrections = new Pelicula()
            {
                Id = 5,
                Titulo = "The Matrix Resurrections",
                EnCartelera = true,
                FechaEstreno = DateTime.Today,
                PosterURL = "https://upload.wikimedia.org/wikipedia/en/5/50/The_Matrix_Resurrections.jpg",
            };

            modelBuilder.Entity<Pelicula>().HasData(avengers, coco, noWayHome, farFromHome, theMatrixResurrections);

            // ----  hasta aqudi debe de agregar las peliculas
            //----------------------------------------------------

            List<PeliculaGenero> lstPeliculaGenero = new();

            var peliculaGeneroAvengers = new PeliculaGenero() { IdPelicula = avengers.Id, IdGenero = acción.Id };
            var peliculaGenero2Avengers = new PeliculaGenero() { IdPelicula = avengers.Id, IdGenero = cienciaFicción.Id };

            lstPeliculaGenero.Add(peliculaGeneroAvengers);
            lstPeliculaGenero.Add(peliculaGenero2Avengers);

            var pgnoWayHome = new PeliculaGenero() { IdPelicula = noWayHome.Id, IdGenero = cienciaFicción.Id };
            var pgnoWayHome1 = new PeliculaGenero() { IdPelicula = noWayHome.Id, IdGenero = acción.Id };
            var pgnoWayHome2 = new PeliculaGenero() { IdPelicula = noWayHome.Id, IdGenero = comedia.Id };

            lstPeliculaGenero.Add(pgnoWayHome);
            lstPeliculaGenero.Add(pgnoWayHome1);
            lstPeliculaGenero.Add(pgnoWayHome2);

            var pgFarFromHome = new PeliculaGenero() { IdPelicula = farFromHome.Id, IdGenero = cienciaFicción.Id };
            var pgFarFromHome2 = new PeliculaGenero() { IdPelicula = farFromHome.Id, IdGenero = acción.Id };
            var pgFarFromHome3 = new PeliculaGenero() { IdPelicula = farFromHome.Id, IdGenero = comedia.Id };

            lstPeliculaGenero.Add(pgFarFromHome);
            lstPeliculaGenero.Add(pgFarFromHome2);
            lstPeliculaGenero.Add(pgFarFromHome3);

            var pgCoco = new PeliculaGenero() { IdPelicula = coco.Id, IdGenero = animación.Id };

            lstPeliculaGenero.Add(pgCoco);

            var pgMatrix = new PeliculaGenero() { IdPelicula = theMatrixResurrections.Id, IdGenero = cienciaFicción.Id };
            var pgMatrix2 = new PeliculaGenero() { IdPelicula = theMatrixResurrections.Id, IdGenero = acción.Id };
            var pgMatrix3 = new PeliculaGenero() { IdPelicula = theMatrixResurrections.Id, IdGenero = drama.Id };

            lstPeliculaGenero.Add(pgMatrix);
            lstPeliculaGenero.Add(pgMatrix2);
            lstPeliculaGenero.Add(pgMatrix3);

            modelBuilder.Entity<PeliculaGenero>().HasData(lstPeliculaGenero);

            List<PeliculaSalaCine> lstPeliculaSalaCine = new();

            var matrixSalaCine  = new PeliculaSalaCine() { IdPelicula = theMatrixResurrections.Id, IdSalaCine = salaDeCine2DSambil.Id };
            var matrixSalaCine1 = new PeliculaSalaCine() { IdPelicula = theMatrixResurrections.Id, IdSalaCine = salaDeCine3DSambil.Id };
            var matrixSalaCine2 = new PeliculaSalaCine() { IdPelicula = theMatrixResurrections.Id, IdSalaCine = salaDeCine2DAgora.Id };
            var matrixSalaCine3 = new PeliculaSalaCine() { IdPelicula = theMatrixResurrections.Id, IdSalaCine = salaDeCine3DAgora.Id };
            var matrixSalaCine4 = new PeliculaSalaCine() { IdPelicula = theMatrixResurrections.Id, IdSalaCine = salaDeCine2DMegacentro.Id };
            var matrixSalaCine5 = new PeliculaSalaCine() { IdPelicula = theMatrixResurrections.Id, IdSalaCine = salaDeCine3DMegacentro.Id };
            var matrixSalaCine6 = new PeliculaSalaCine() { IdPelicula = theMatrixResurrections.Id, IdSalaCine = salaDeCineCXCMegacentro.Id };

            lstPeliculaSalaCine.Add(matrixSalaCine);
            lstPeliculaSalaCine.Add(matrixSalaCine1);
            lstPeliculaSalaCine.Add(matrixSalaCine2);
            lstPeliculaSalaCine.Add(matrixSalaCine3);
            lstPeliculaSalaCine.Add(matrixSalaCine4);
            lstPeliculaSalaCine.Add(matrixSalaCine5);
            lstPeliculaSalaCine.Add(matrixSalaCine6);

            modelBuilder.Entity<PeliculaSalaCine>().HasData(lstPeliculaSalaCine);

            var keanuReevesMatrix = new PeliculaActor
            {
                IdActor = keanuReeves.Id,
                IdPelicula = theMatrixResurrections.Id,
                Orden = 1,
                Personaje = "Neo"
            };

            var avengersChrisEvans = new PeliculaActor
            {
                IdActor = chrisEvans.Id,
                IdPelicula = avengers.Id,
                Orden = 1,
                Personaje = "Capitán América"
            };

            var avengersRobertDowney = new PeliculaActor
            {
                IdActor = robertDowney.Id,
                IdPelicula = avengers.Id,
                Orden = 2,
                Personaje = "Iron Man"
            };

            var avengersScarlettJohansson = new PeliculaActor
            {
                IdActor = scarlettJohansson.Id,
                IdPelicula = avengers.Id,
                Orden = 3,
                Personaje = "Black Widow"
            };

            var tomHollandFFH = new PeliculaActor
            {
                IdActor = tomHolland.Id,
                IdPelicula = farFromHome.Id,
                Orden = 1,
                Personaje = "Peter Parker"
            };

            var tomHollandNWH = new PeliculaActor
            {
                IdActor = tomHolland.Id,
                IdPelicula = noWayHome.Id,
                Orden = 1,
                Personaje = "Peter Parker"
            };

            var samuelJacksonFFH = new PeliculaActor
            {
                IdActor = samuelJackson.Id,
                IdPelicula = farFromHome.Id,
                Orden = 2,
                Personaje = "Samuel L. Jackson"
            };

            
            modelBuilder.Entity<PeliculaActor>().HasData(samuelJacksonFFH, tomHollandFFH, tomHollandNWH, avengersRobertDowney,        avengersScarlettJohansson,avengersChrisEvans, keanuReevesMatrix);

        }
    }
}
