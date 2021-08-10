using DevTraining.Business.Interfaces;
using DevTraining.Business.Models;
using DevTraining.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTraining.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(DevTrainingContext context) : base(context) { }
        public async Task<Produto> ObterProdutoFornecedor(Guid id)
        {
            return await Banco.Produtos.AsNoTracking()
                              .Include(p => p.Fornecedor)
                              .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Produto>> ObterProdutosFornecedores()
        {
            return await Banco.Produtos.AsNoTracking()
                              .Include(p => p.Fornecedor)
                              .OrderBy(p => p.Nome).ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId)
        {
            return await Buscar(p => p.FornecedorId == fornecedorId);
        }
    }
}
