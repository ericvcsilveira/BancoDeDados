namespace ProjetoAcademia.Models
{
    public class Treinos
    {

        public int id { get; set; }
        public string objetivo { get; set; }
        public string data_inicio { get; set; }

        public float duracao { get; set; }

        public string observacoes { get; set; }
        public int matricula { get; set; }
        public int codigo_professor { get; set; }
       
    }
}
