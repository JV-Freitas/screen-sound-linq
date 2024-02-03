using ScreenSound_Api.Modelos;

namespace ScreenSound_Api.Filtros;

internal class LinqOrder
{
    public static void OrdenarPorArtista(List<Musica> musicas)
    {
        var artistasOrdenado = musicas.OrderBy(musica => musica.Artista).Select(musica => musica.Artista).Distinct().ToList();
        //Está ordenando a lista de musicas pela propiedade Artista
        //Selecionando só os artistas da lista
        //Aplicando o Distinct para nao vir repetido
        //DEixando em lista
        Console.WriteLine("### Lista de Artistas - Ordenado ###");
        foreach (var artista in artistasOrdenado)
        {
            Console.WriteLine($"- {artista}");
        }
    }
}
