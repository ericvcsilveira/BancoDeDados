namespace ProjetoAcademia.Models
{
    public class Equipamentos
    {
        public int nserie { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }

        public string? descricao { get; set; }

        public int codigo_unidade { get; set; }
    }
}
