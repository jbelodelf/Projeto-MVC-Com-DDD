using AutoMapper;
using JoseBeloDelfino.Domain.Entidades;
using JoseBeloDelfino.DTOs;
using JoseBeloDelfino.ViewModels;

namespace JoseBeloDelfino.WebApplication.App_Start
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<LoginDTO, LoginEntity>().ReverseMap();
            CreateMap<FuncionarioDTO, FuncionarioEntity>().ReverseMap();
            //CreateMap<AmigoDTO, AmigoEntity>().ReverseMap();

            CreateMap<LoginDTO, LoginViewModel>().ReverseMap();
            CreateMap<FuncionarioDTO, FuncionarioViewModel>().ReverseMap();
            //CreateMap<AmigoDTO, AmigoViewModel>().ReverseMap();
        }
    }
}