using System.ComponentModel.DataAnnotations;

namespace ProjetoAcademia.Models

{
    public class Atividades
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        public string? informacoes { get; set; }
        public Areas Areas { get; set; }

    }
}
