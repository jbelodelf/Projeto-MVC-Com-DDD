using JoseBeloDelfino.Domain.Entidades;
using JoseBeloDelfino.DTOs;
using AutoMapper;


namespace JoseBeloDelfino.WebApi.App_Start
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<LoginDTO, LoginEntity>().ReverseMap();
            CreateMap<FuncionarioDTO, FuncionarioEntity>().ReverseMap();
            //CreateMap<AmigoDTO, AmigoEntity>().ReverseMap();

        }
    }
}