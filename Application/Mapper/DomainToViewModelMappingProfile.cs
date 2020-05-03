using Application.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper
{
    public class DomainToViewModelMappingProfile  : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Cliente , ClienteDTO>();
            CreateMap<Produto , ProdutoDTO>();
        }
    }
}