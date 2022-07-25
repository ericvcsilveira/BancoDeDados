using System.ComponentModel.DataAnnotations;

namespace ProjetoAcademia.Models
{
    public class Planos
    {
        [Key]
        public int PlanosID { get; set; }
        public string nome { get; set; }

        public float preco { get; set; }

        public int duracao { get; set; }
        public string? descricao { get; set; }
        public float? desconto { get; set; }
       

    }
}
