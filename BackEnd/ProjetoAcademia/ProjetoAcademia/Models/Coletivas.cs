using System.ComponentModel.DataAnnotations;

namespace ProjetoAcademia.Models
{
    public class Coletivas
    {
        [Key]
        public int id { get; set; }
        public int id_atividade { get; set; }
        public float duracao { get; set; }

        public int nrvagas { get; set; }

        public string modalidade { get; set; }
        public Professores? Professores { get; set; }
    }
}
