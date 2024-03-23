internal class Program
{
    private static async Task Main(string[] args)
    {
        await Task.WhenAll(DoWorkAsync("Tarefa 1"), DoWorkAsync("Tarefa 2"));

        Console.WriteLine("Ambas as tarefas foram concluídas.");
    }

    static async Task DoWorkAsync(string taskName)
    {
        Console.WriteLine($"{taskName} iniciada.");

        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine($"{taskName}: Trabalhando... ({i}/5)");
            await Task.Delay(1000);
        }

        Console.WriteLine($"{taskName} concluída.");
    }
}
