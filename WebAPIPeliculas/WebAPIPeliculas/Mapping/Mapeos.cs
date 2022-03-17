using AutoMapper;
using WebAPIPeliculas.DTOS;
using WebAPIPeliculas.Entities;

namespace WebAPIPeliculas.Mapping
{
    public class Mapeos : Profile
    {
        public Mapeos()
        {
            #region Actores
              CreateMap<Actor,ActorDTO>().ReverseMap();
            #endregion

            #region Cines
            CreateMap<Cine, CineDTO>()
                   .ForMember(dto => dto.Latitud, ent => ent.MapFrom(prop => prop.Ubicacion.Y))
                   .ForMember(dto => dto.Longitud, ent => ent.MapFrom(prop => prop.Ubicacion.X));
            #endregion

            #region Refaccionarias
            CreateMap<Refaccionaria, RefaccionariaDTO>()
                    .ForMember(dto => dto.Latitud, ent => ent.MapFrom(prop => prop.Ubicacion.Y))
                    .ForMember(dto => dto.Longitud, ent => ent.MapFrom(prop => prop.Ubicacion.X));
            #endregion

            #region Genero
            CreateMap<Genero, GeneroDTO>();
            #endregion

            #region SalaCine
            CreateMap<SalaCine, SalaCineDTO>();
            #endregion

            #region Pelicula
            CreateMap<Pelicula, PeliculaDTO>()
                //.ForMember(dto => dto.Genero, ent => ent.MapFrom(prop => prop.PeliculaGenero.Select(s => s.Genero).OrderByDescending(r => r.Nombre)))
                .ForMember(dto => dto.Cine, ent => ent.MapFrom(prop => prop.PeliculaSalaCine.Select(c => c.SalaCine.Cine)))
                .ForMember(dto => dto.Actor, ent => ent.MapFrom(prop => prop.PeliculaActores.Select(a => a.Actor)));

            //CreateMap<PeliculaGenero, PeliculaGeneroDTO>();
            //CreateMap<PeliculaSalaCine, PeliculaSalaCineDTO>();
            //CreateMap<PeliculaActor, PeliculaActorDTO>();
            #endregion

        }
    }
}
