class Program
{
    static async Task Main(string[] args)
    {
        //Console.BackgroundColor=ConsoleColor.DarkCyan;

        int timeoutSeconds=5;   //tempo di attesa di 5 secondi

        Task inputTask= Task.Run(()=>
        {
            Console.WriteLine($"Metti n'input entro {timeoutSeconds} secondi:");
            return Console.ReadLine();
        });
        Task delayTask= Task.Delay(TimeSpan.FromSeconds(timeoutSeconds));

        //ricorda, await necessita di essere asincrono, quindi modificare lo static di inizio
        //con "static async Task main(string[] args)
        if(await Task.WhenAny(inputTask, delayTask)==inputTask)
        {
            //congrats, hai scritto in tempo
            string input= await (inputTask as Task<string>);
            Console.WriteLine($"Hai inserito: {input}");
        }
        else
        {
            //oof, manco 5 secondi ce la fai, eh?
            Console.WriteLine("Tempo scaduto...");
        }
    }
}