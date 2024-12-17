namespace GerenciamentoDeTarefas.entities
{
    public enum StatusTarefa
    {
        Pendente,
        Concluída,
        Cancelada
    }
    public class Tarefas
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public StatusTarefa Status { get; set; }
        public bool Ativo { get; set; }
    }
}