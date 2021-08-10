using DevTraining.Business.Interfaces;
using DevTraining.Business.Models;
using DevTraining.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevTraining.Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(DevTrainingContext context) : base(context) { }

        public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
            return await Banco.Fornecedores.AsNoTracking()
                              .Include(f => f.Endereco)
                              .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
        {
            return await Banco.Fornecedores.AsNoTracking()
                              .Include(f => f.Produtos)
                              .Include(f => f.Endereco)
                              .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
