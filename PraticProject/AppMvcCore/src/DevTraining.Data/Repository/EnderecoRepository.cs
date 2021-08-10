using DevTraining.Business.Interfaces;
using DevTraining.Business.Models;
using DevTraining.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DevTraining.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(DevTrainingContext context) : base(context) { }

        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid FornecedorId)
        {
            return await Banco.Enderecos.AsNoTracking()
                              .FirstOrDefaultAsync(f => f.FornecedorId == FornecedorId);
        }
    }
}
