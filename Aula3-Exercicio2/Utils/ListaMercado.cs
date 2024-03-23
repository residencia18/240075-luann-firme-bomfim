using ConsoleTables;

namespace Aula3_Exercicio2;

public static class ListaMercado
{
    public static List<ItemMercado> PopularLista()
    {
        List<ItemMercado> lista = new List<ItemMercado>{
            new ItemMercado("Arroz", Tipo.Comida, 3.90),
            new ItemMercado("Azeite", Tipo.Comida, 2.50),
            new ItemMercado("Macarrão", Tipo.Comida, 3.90),
            new ItemMercado("Cerveja", Tipo.Bebida, 22.90),
            new ItemMercado("Refrigerante", Tipo.Bebida, 5.50),
            new ItemMercado("Shampoo", Tipo.Higiene, 7.00),
            new ItemMercado("Sabonete", Tipo.Higiene, 2.40),
            new ItemMercado("Cotonete", Tipo.Higiene, 5.70),
            new ItemMercado("Sabão em pó", Tipo.Limpeza, 8.20),
            new ItemMercado("Detergente", Tipo.Limpeza, 2.60),
            new ItemMercado("Amaciante", Tipo.Limpeza, 6.40)
        };

        return lista;
    }

    public static void ListaTipoHigiente(this List<ItemMercado> itensMercado)
    {
        var listaHigiene = itensMercado.Where(item => item.Tipo == Tipo.Higiene).OrderByDescending(item => item.Preco).ToList();

        var table = new ConsoleTable(" Nome ", " Tipo ", " Preço ");
        listaHigiene.ForEach(item =>
        {
            table.AddRow(item.Nome, item.Tipo, $"R$ {item.Preco:F2}");
        });
        table.Write();
        Console.WriteLine();
    }

    public static void ListaPorPreco(this List<ItemMercado> itensMercado)
    {
        var listaPrecoMaiorIgual5 = itensMercado.Where(item => item.Preco >= 5.00).OrderBy(item => item.Preco).ToList();

        var table = new ConsoleTable(" Nome ", " Tipo ", " Preço ");
        listaPrecoMaiorIgual5.ForEach(item =>
        {
            table.AddRow(item.Nome, item.Tipo, $"R$ {item.Preco:F2}");
        });
        table.Write();
        Console.WriteLine();
    }

    public static void ListaTipoComidaBebida(this List<ItemMercado> itensMercado)
    {
        var listaComidaBebida = itensMercado.Where(item => item.Tipo == Tipo.Comida || item.Tipo == Tipo.Bebida).OrderBy(item => item.Nome).ToList();

        var table = new ConsoleTable(" Nome ", " Tipo ", " Preço ");
        listaComidaBebida.ForEach(item =>
        {
            table.AddRow(item.Nome, item.Tipo, $"R$ {item.Preco:F2}");
        });
        table.Write();
        Console.WriteLine();
    }

    public static void ListaQuantidadeTipo(this List<ItemMercado> itensMercado)
    {
        var quantidadePorTipo = itensMercado.GroupBy(item => item.Tipo).Select(group => new { Tipo = group.Key, Quantidade = group.Count() }).ToList();

        var table = new ConsoleTable(" Tipo ", " Quantidade ");
        quantidadePorTipo.ForEach(item =>
        {
            table.AddRow(item.Tipo, item.Quantidade);
        });
        table.Write();
        Console.WriteLine();
    }

    public static void ListaPorPrecoComMetricas(this List<ItemMercado> itensMercado)
    {
        var metricasPorTipo = itensMercado.GroupBy(item => item.Tipo).Select(group => new
        {
            Tipo = group.Key,
            PrecoMaximo = group.Max(item => item.Preco),
            PrecoMinimo = group.Min(item => item.Preco),
            PrecoMedio = group.Average(item => item.Preco)
        }).ToList();

        var table = new ConsoleTable(" Tipo ", " Preço Máximo ", " Preço Mínimo ", " Preço Médio ");
        metricasPorTipo.ForEach(item =>
        {
            table.AddRow(item.Tipo, $"R$ {item.PrecoMaximo:F2}", $"R$ {item.PrecoMinimo:F2}", $"R$ {item.PrecoMedio:F2}");
        });
        table.Write();
        Console.WriteLine();
    }
}
