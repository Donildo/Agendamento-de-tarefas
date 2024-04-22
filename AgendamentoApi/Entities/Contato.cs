namespace AgendamentoApi.Entities
{
    public class Contato
    {
        public int Id { get; set; }

        public string Titulo{get; set;}
        public string Nome { get; set;}
        public string Descricao { get; set; }
        public DateTime Data {get; set;}
        public EnumStatusTarefa Status{ get;set;}

    }
}