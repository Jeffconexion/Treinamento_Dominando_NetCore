using DevTraining.Business.Models;
using System;
using System.Threading.Tasks;

namespace DevTraining.Business.Interfaces
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId);
    }
}
