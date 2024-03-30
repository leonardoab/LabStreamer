namespace LabStreamer.Domain.Domains
{
    public class Banda
    {
        public Guid IdBanda { get; set; }
        public string Nome { get; set; }

        public List<Album> Albuns { get; set; } 
        public List<Musica> Musicas { get; set; } 

      
    }
}
