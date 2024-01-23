class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        try
        {
            Console.WriteLine($"Da qui un numero\n");
            int numero=int.Parse(Console.ReadLine()!);
            if(numero<0||numero >10)
            {
                Console.WriteLine("surprise, volevo tra 0 e 10");
                return;
            }
            Console.WriteLine($"\nHai scritto : {numero}");
        }
        catch(Exception e)
        {
            Console.WriteLine("c'è qualcosa di sbagliato...");
            Console.WriteLine("\n"+e.Message);
            return;
        }
        finally
        {
            Console.WriteLine("e niente, c'hai provato");
        }
    }
}