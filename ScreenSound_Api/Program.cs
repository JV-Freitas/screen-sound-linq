using ScreenSound_Api.Filtros;
using ScreenSound_Api.Modelos;
using System.Text.Json;

using (HttpClient client = new HttpClient())
{
    try
    {
        string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
        //Console.WriteLine(resposta);
        var musicas = JsonSerializer.Deserialize<List<Musica>>(resposta); //usou a classe JsonSerializer para deserializar o json e colocar na lista

        Console.WriteLine($"Quantidade de musicas: {musicas.Count()}\n");
        musicas[2].ExibirDetalhes();

        //LinqFilter.FiltrarTodosGeneros(musicas);
        //LinqOrder.OrdenarPorArtista(musicas);
        //LinqFilter.FiltrarArtistaPorGenero(musicas, "rock");
        //LinqFilter.FiltrarMusicasArtista(musicas, "Red Hot Chili Peppers");
        //LinqFilter.FiltrarPorAno(musicas, 2010);

        var playlistDoJoao = new Playlist("j0ttinha 1.0");
        playlistDoJoao.AddMusica(musicas[70]);
        playlistDoJoao.AddMusica(musicas[80]);
        playlistDoJoao.AddMusica(musicas[90]);
        playlistDoJoao.AddMusica(musicas[100]);
        playlistDoJoao.AddMusica(musicas[110]);
        playlistDoJoao.ExibirPlaylist();


        //Playlist playlistJoao = new Playlist("j0ttinha 2.0");
        //playlistJoao.AddMusica(musicas[20]);
        //playlistJoao.AddMusica(musicas[30]);
        //playlistJoao.AddMusica(musicas[40]);
        //playlistJoao.AddMusica(musicas[50]);
        //playlistJoao.AddMusica(musicas[60]);

        //playlistJoao.ExibirPlaylist();
        playlistDoJoao.GerarArquivoJson();

        LinqFilter.FiltrarPorCSharp(musicas);

    }
    catch (Exception ex)
    {
        Console.WriteLine($"Houve um problema: {ex.Message}");
    }
   
}