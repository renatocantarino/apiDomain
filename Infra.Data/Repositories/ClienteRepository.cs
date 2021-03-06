using Domain.Core.Interfaces.Repositories;
using Domain.Entities;
using Infra.Data.Context;
using Infra.Data.Repositories.Base;

namespace Infra.Data.Repositories
{
    public class ClienteRepository : RepositoryAsyncBase<DataContext, Cliente> , IClienteRepository
    {

    }
}