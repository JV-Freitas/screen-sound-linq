using System.Text.Json;

namespace ScreenSound_Api.Modelos;

internal class Playlist
{
    public string Nome { get; set; }
    public List<Musica> playlist { get; set; }

    public Playlist(string nome)
    {
        Nome = nome;
        playlist = new List<Musica>();
    }
    public void AddMusica(Musica musica)
    {
        playlist.Add(musica);
    }

    public void ExibirPlaylist()
    {
        Console.WriteLine($"Playlist de {Nome}");
        foreach(var musica in playlist)
        {
            Console.WriteLine($"Musica: {musica.Nome} -> Artista: {musica.Artista}");
        }
        Console.WriteLine();
    }

    public void GerarArquivoJson()
    {
        string json = JsonSerializer.Serialize(new
        {
            nome = Nome,
            musicas = playlist
        });

        string nomeDoArquivo = $"playlist-favorita-{Nome}.json";

        File.WriteAllText(nomeDoArquivo, json);
        Console.WriteLine($"O arquivo Json foi criado com sucesso! - {Path.GetFullPath(nomeDoArquivo)}");
    }
}
