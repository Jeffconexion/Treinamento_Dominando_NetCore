using System;

namespace DevTraining.Business.Models
{
    public class Endereco : Entity
    {
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }

        //EF Relation
        public Guid FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; }
    }
}
