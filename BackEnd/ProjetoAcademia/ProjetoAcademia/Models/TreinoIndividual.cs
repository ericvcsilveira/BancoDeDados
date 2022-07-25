namespace ProjetoAcademia.Models
{
    public class TreinoIndividual
    {
        public int id { get; set; }
        public int id_treino { get; set; }
        public int id_individual { get; set; }
        public string treino_letra { get; set; }
        public int series { get; set; }
        public int? repeticoes { get; set; }
        public int? duracao { get; set; }
        public int? tempo_descanso { get; set; }
        public string? observacao { get; set; }
    }
}
