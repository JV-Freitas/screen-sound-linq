using ScreenSound_Api.Modelos;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ScreenSound_Api.Filtros;

internal class LinqFilter
{
    public static void FiltrarTodosGeneros(List<Musica> musicas)
    {
        var todosGeneros = musicas.Select(generos => generos.Genero).Distinct().ToList();
        //Selecionou a lista de musicas .Select()
        //armazenou cada genero em generos (generos => generos.Genero) arrow function
        //tirou os repetidos com o .Distinct()
        //o resultado de tudo isso em lista .ToList()

        Console.WriteLine("### Lista de Gêneros ###");
        foreach (var genero in todosGeneros)
        {
            Console.WriteLine($"- {genero}");
        }
    }

    public static void FiltrarArtistaPorGenero(List<Musica> musicas, string genero)
    {
        var artistaPorGenero = musicas.Where(musica => musica.Genero.Contains(genero)).Select(musica => musica.Artista).Distinct().ToList();
        //>WHERE() Pega na lista a musica(o obejto completo) que contem aquele genero que foi passado (vai vir, nome, artista, tudo)
        //.SELECT() selecionar apenas os artistas
        //.DISTINCT tira os artistas duplicado
        //.TOLIST() transforma em lista

        Console.WriteLine("### Lista de Artista por Gêneros ###");
        foreach (var artista in artistaPorGenero)
        {
            Console.WriteLine($"- {artista}");
        }
    }

    public static void FiltrarMusicasArtista(List<Musica> musicas, string artista)
    {
        var musicaPorArtista = musicas.Where(musica => musica.Artista.Equals(artista)).ToList();
        Console.WriteLine(artista);
        foreach (var musica in musicaPorArtista)
        {
            Console.WriteLine($"- {musica.Nome}");
        }
    }

    public static void FiltrarPorAno(List<Musica> musicas, int ano)
    {
        var musicasPorAno = musicas.Where(musica => musica.Ano == ano)// Pega as musicas que tiver a propiedade ano igual ao que parametro ano
            .OrderBy(musica => musica.Nome) // ordena as músicas pelo nome
            .Select(musica => musica.Nome) // seleciona apenas o nome das músicas
            .Distinct() // remove as duplicidades
            .ToList(); // converte o resultado em uma lista

        Console.WriteLine($"### Lista de Musicas por Ano - {ano}###");
        foreach (var musica in musicasPorAno)
        {
            Console.WriteLine($"Musica: {musica}");
        }
    }

    public static void FiltrarPorCSharp(List<Musica> musicas)
    {
        var musicasTonalidadeCsharp = musicas.Where(musica => musica.Key == 1).OrderBy(musica => musica.Nome).Select(musica => musica.Nome).Distinct().ToList();
        Console.WriteLine($"### Lista de Musicas de tonalidade C# ###");
        
        foreach (var musica in musicasTonalidadeCsharp)
        {
            Console.WriteLine($"Musica: {musica}");
        }
    }

}
