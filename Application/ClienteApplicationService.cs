using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Core.Interfaces.Services;
using Domain.Entities;

namespace Application
{
    public class ClienteApplicationService : IAppServiceCliente
    {
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;

        public ClienteApplicationService(IClienteService clienteService ,
            IMapper mapper )
        {
            this._mapper = mapper;
            this._clienteService = clienteService;
        }
        public async ValueTask<ClienteDTO> GetById(int id)
        {
            var entidade = await  _clienteService.GetById(id);
            return  _mapper.Map<ClienteDTO>(entidade);
        }

        public async Task<ClienteDTO> Add(ClienteDTO entity)
        {
            var cliente = _mapper.Map<Cliente>(entity);
            await _clienteService.Add(cliente);

            return entity;
        }

        public async Task<List<ClienteDTO>> AddRange(List<ClienteDTO> Listentity)
        {
            var clientes = _mapper.Map<List<Cliente>>(Listentity);
            var retorno = await _clienteService.AddRange(clientes);

            return _mapper.Map<List<ClienteDTO>>(retorno);
        }

        public async Task<ClienteDTO> Update(ClienteDTO entity)
        {
            var cliente = _mapper.Map<Cliente>(entity);
            await _clienteService.Update(cliente);

            return entity;
        }

        public Task Remove(ClienteDTO entity)
        {
            var cliente = _mapper.Map<Cliente>(entity);
            _clienteService.Remove(cliente);

            return Task.CompletedTask;

        }

        public async Task<IEnumerable<ClienteDTO>> GetAll()
        {
            var entidades  = await _clienteService.GetAll();
            return _mapper.Map<IEnumerable<ClienteDTO>>(entidades);
        }
    }


}