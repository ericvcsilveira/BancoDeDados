using System.Numerics;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoAcademia.Models
{
    public class Alunos
    {
        [Key]
        public int Id { get; set; }
        public int pontos { get; set; }
        public string nome { get; set; }
        public BigInteger cpf { get; set; }
        public string datanasc { get; set; }
        public string data_cadastro { get; set; }
        public string email { get; set; }
        public string celular { get; set; }
        public string sexo { get; set; }
        public string cep { get; set; }
        public string rua { get; set; }
        public int numero { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }

        
        public int codigo_unidade { get; set; }

        public string data_contratacao { get; set; }

        
        public int id_plano { get; set; }

        public int? codigo_professor { get; set; }
        public int? preco { get; set; }
    }
}
