using System.ComponentModel.DataAnnotations;

namespace ProjetoAcademia.Models
{
    public class Unidades
    {
        [Key]
        public int UnidadesID { get; set; }
        public string nome { get; set; }
        public string site { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public string cep { get; set; }
        public string rua { get; set; }
        public int numero { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }


    }
}
