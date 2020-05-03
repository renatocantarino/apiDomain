using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Core.Interfaces.Services;
using Domain.Entities;

namespace Application
{
    public class ProdutoApplicationService :  IAppServiceProduto
    {
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public ProdutoApplicationService(IProdutoService produtoService ,
            IMapper mapper )
        {
            this._mapper = mapper;
            this._produtoService = produtoService;
        }
        public async ValueTask<ProdutoDTO> GetById(int id)
        {
            var entidade = await  _produtoService.GetById(id);
            return  _mapper.Map<ProdutoDTO>(entidade);
        }
        public async Task<ProdutoDTO> Add(ProdutoDTO entity)
        {
            var produto = _mapper.Map<Produto>(entity);
            await _produtoService.Add(produto);

            return entity;
        }
        public async Task<ProdutoDTO> Update(ProdutoDTO entity)
        {
            var produto = _mapper.Map<Produto>(entity);
            await _produtoService.Update(produto);

            return entity;
        }

        public Task Remove(ProdutoDTO entity)
        {
            var produto = _mapper.Map<Produto>(entity);
            _produtoService.Remove(produto);

            return Task.CompletedTask;
        }

        public async Task<IEnumerable<ProdutoDTO>> GetAll()
        {
            var entidades  = await _produtoService.GetAll();
            return _mapper.Map<IEnumerable<ProdutoDTO>>(entidades);
        }

        public async Task<List<ProdutoDTO>> AddRange(List<ProdutoDTO> Listentity)
        {
            var prods = _mapper.Map<List<Produto>>(Listentity);
             var retorno = await _produtoService.AddRange(prods);

            return _mapper.Map<List<ProdutoDTO>>(retorno);
        }
    }
}