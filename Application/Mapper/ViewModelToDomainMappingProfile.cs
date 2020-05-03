using Application.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper
{
    public class ViewModelToDomainMappingProfile  : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ClienteDTO, Cliente>();
            CreateMap<ProdutoDTO,Produto>();
        }
    }
}