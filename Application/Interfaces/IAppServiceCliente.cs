using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Dtos;


namespace Application.Interfaces
{
    public interface IAppServiceCliente
    {
        ValueTask<ClienteDTO> GetById(int id);
        Task<ClienteDTO> Add(ClienteDTO entity);

        Task<List<ClienteDTO>> AddRange(List<ClienteDTO> Listentity);

        Task<ClienteDTO> Update(ClienteDTO entity);
        Task Remove(ClienteDTO entity);
        Task<IEnumerable<ClienteDTO>> GetAll();

    }
}