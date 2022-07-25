using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoAcademia.Models
{
    public class Areas
    {
        [Key]
        public int codigo { get; set; }
        public string nome { get; set; }
        public int capacidade { get; set; }
        public string? descricao { get; set; }
        public int codigo_unidade { get; set; }
    }
}
