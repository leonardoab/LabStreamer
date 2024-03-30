namespace LabStreamer.Domain.Domains
{
    public class Banda
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public virtual IList<Album> Albuns { get; set; } = new List<Album>();
        public virtual IList<Musica> Musicas { get; set; } = new List<Musica>();


    }
}
