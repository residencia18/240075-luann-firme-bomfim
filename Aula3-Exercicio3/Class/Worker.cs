namespace Aula3_Exercicio3;

public class Worker
{
        public void Work()
    {
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}: Trabalhando... ({i}/5)");
            Thread.Sleep(1000);
        }
    }
}
