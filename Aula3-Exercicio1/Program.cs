internal class Program
{
    private static void Main(string[] args)
    {
        List<double> originalList = new List<double> { 3, 7, 2, 4, 6 };

        List<double> novaLista = originalList.ConvertAll(x => x / 2);

        novaLista.ForEach(x => Console.WriteLine(x));
    }
}
