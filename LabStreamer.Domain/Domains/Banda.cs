namespace LabStreamer.Domain.Domains
{
    public class Banda
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public List<Album> Albuns { get; set; } = new List<Album>(); // Inicialize a lista de Albuns
        public List<Musica> Musicas { get; set; } = new List<Musica>(); // Inicialize a lista de Musicas

        // Construtor
        public Banda()
        {
            // Inicialize as listas se necessário
            Albuns = new List<Album>();
            Musicas = new List<Musica>();
        }
    }
}
