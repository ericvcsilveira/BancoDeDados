using System.Numerics;
using System.ComponentModel.DataAnnotations;

namespace ProjetoAcademia.Models
{
    public class Professores
    {
        [Key]
        public int ProfessoresID { get; set; }
        public float salario { get; set; }
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
        public bool? instrutor { get; set; }
        public bool? personal { get; set; }
        public bool? professor { get; set; }
        public string turno { get; set; }
        public Unidades Unidades { get; set; }

    }
}
