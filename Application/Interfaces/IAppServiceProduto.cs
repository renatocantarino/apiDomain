using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Dtos;


namespace Application.Interfaces
{
    public interface IAppServiceProduto
    {
        ValueTask<ProdutoDTO> GetById(int id);
        Task<ProdutoDTO> Add(ProdutoDTO entity);
        Task<ProdutoDTO> Update(ProdutoDTO entity);
        Task Remove(ProdutoDTO entity);
        Task<IEnumerable<ProdutoDTO>> GetAll();

        Task<List<ProdutoDTO>> AddRange(List<ProdutoDTO> Listentity);

    }
}