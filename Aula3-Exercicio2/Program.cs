using Aula3_Exercicio2;

internal class Program
{
    private static void Main(string[] args)
    {
        List<ItemMercado> listaMercado = ListaMercado.PopularLista();

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine("1 - Listar itens do tipo Higiene ordenados por preço decrescente");
            Console.WriteLine("2 - Listar itens cujo preço seja maior ou igual a R$ 5,00 por preço crescente");
            Console.WriteLine("3 - Listar itens cujo tipo seja Comida ou Bebida por nome em ordem alfabética");
            Console.WriteLine("4 - Listar cada um dos tipos associado com a quantidade de itens de cada tipo");
            Console.WriteLine("5 - Listar cada um dos tipos associado com o preço máximo, preço mínimo e média de preço de cada tipo");
            Console.WriteLine("0 - Sair");
            Console.Write("R: ");

            if (!int.TryParse(Console.ReadLine(), out int opcao))
            {
                Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                continue;
            }

            switch (opcao)
            {
                case 1:
                    Console.WriteLine("");
                    listaMercado.ListaTipoHigiente();
                    break;
                case 2:
                    listaMercado.ListaPorPreco();
                    break;
                case 3:
                    Console.WriteLine("");
                    listaMercado.ListaTipoComidaBebida();
                    break;
                case 4:
                    Console.WriteLine("");
                    listaMercado.ListaQuantidadeTipo();
                    break;
                case 5:
                    Console.WriteLine("");
                    listaMercado.ListaPorPrecoComMetricas();
                    break;
                case 0:
                    Console.WriteLine("");
                    Console.WriteLine("Aplicação encerrada...");
                    Console.WriteLine("");
                    return;
                default:
                    Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                    break;
            }

            if (opcao == 0)
                break;
        }
    }
}