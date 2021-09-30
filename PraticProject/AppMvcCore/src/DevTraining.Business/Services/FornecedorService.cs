using DevTraining.Business.Interfaces;
using DevTraining.Business.Models;
using DevTraining.Business.Models.Validations;
using System;
using System.Threading.Tasks;

namespace DevTraining.Business.Services
{
    public class FornecedorService : BaseService, IFornecedorService
    {
        public async Task Adicionar(Fornecedor fornecedor)
        {
            //validar o estado da entidade

            if (!ExecutarValidacao(new FornecedorValidation(), fornecedor) && !ExecutarValidacao(new EnderecoValidation(), fornecedor.Endereco))
                return;


            //se não existe fornecedor com o mesmo documento
            return;
        }

        public async Task Atualizar(Fornecedor fornecedor)
        {
            if (!ExecutarValidacao(new FornecedorValidation(), fornecedor)) return;

        }

        public async Task AtualizarEndereco(Endereco endereco)
        {
            if (!ExecutarValidacao(new EnderecoValidation(), endereco)) return;

        }

        public async Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
