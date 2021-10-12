using DevTraining.Business.Models;
using System;
using System.Threading.Tasks;

namespace DevTraining.Business.Interfaces
{
    public interface IProdutoService : IDisposable
    {
        Task Adicionar(Produto produto);
        Task Atualizar(Produto produto);
        Task Remover(Guid id);
    }
}
