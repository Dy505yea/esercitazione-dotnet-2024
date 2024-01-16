class Program
{
    static async Task Main(string[] args)
    {
        int timeoutSeconds=5;   //tempo di attesa di 5 secondi

        //oggetto task, probabilkmente per creare un mini thread tramite .Run(()=>{});
        Task inputTask= Task.Run(()=>
        {
            //Questo minithread si occupa solo di prendere in input qualsiasi cosa, usando variabili dal thread principale
            Console.WriteLine($"Metti n'input entro {timeoutSeconds} secondi:");
            //finisce il momento in cui si prema invio
            return Console.ReadLine();
        });
        //il .Delay è per aprire una task dopo x tempo, in sto caso si chiama delayTask
        Task delayTask= Task.Delay(TimeSpan.FromSeconds(timeoutSeconds));

        //ricorda, await necessita di essere asincrono, quindi modificare lo static di inizio
        //con "static async Task main(string[] args)
        if(await Task.WhenAny(inputTask, delayTask)==inputTask)
        //comunque, await fa attendere l'if che una task finisca, in sto caso .WhenAny, una qualsiasi task che finisca per prima
        {
            //se inputTask (quello che attende un input) finisce prima della task ritardata (delayTask, che non ha niente da eseguire, per cui già torna subito)
            //allora .WhenAny ritornerà ciò che ha inputTask (e dato che allora diviene inputTask==inputTask, diverrà vero)
            string input= await (inputTask as Task<string>);
            Console.WriteLine($"Hai inserito: {input}");
        }
        else
        {
            //altrimenti, il momento in cui viene avviato delayTask, .WhenAny diverrà ciò, comparando allora delayTask==inputTask
            Console.WriteLine("\nTempo scaduto...");
        }
    }
}