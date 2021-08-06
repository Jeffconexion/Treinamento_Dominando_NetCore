using System.Collections.Generic;

namespace DevTraining.Business.Models
{
    public class Fornecedor : Entity
    {
        public string Nome { get; set; }
        public string Documento { get; set; }       
        public bool Ativo { get; set; }
        public TipoFornecedor TipoFornecedor { get; set; }

        //EF Relations
        public IEnumerable<Produto> Produtos { get; set; }
        public Endereco Endereco { get; set; }


    }
}
