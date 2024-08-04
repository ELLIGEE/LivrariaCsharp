using AutoMapper;
using Livraria.DTO.Input;
using Livraria.DTO.Modelo;
using Livraria.Models;

namespace Livraria.Config
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            CreateMap<Livro, LivroDTO>()
                    .ForMember(dest => dest.Autores, opt => opt.MapFrom(src => src.Autores.Select(la => la.Autor)));

            CreateMap<Autor, AutorDTO>();

            //map para update do livro e ignorar o id
            CreateMap<Livro, Livro>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            //map para update de autor e ignorar o id 
            CreateMap<Autor, Autor>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<LivroInputDTO, Livro>()
            .ForMember(dest => dest.Autores, opt => opt.MapFrom(src => src.AutorInputIdDTO.AutoresIds.Select(id => new LivroAutor { AutorId = id })));

            CreateMap<AutorInputDTO, Autor>();

        }
    }
}
