class Program
{
    static void Main(string[] args)
    {
        int a=0;
        int b=0;
        Console.WriteLine($"Ammira come cambio {a} e {b} con una funzione");
        (a, b)=OneIntoTwo(2);
        Console.WriteLine($"Ecco a voi...   I NUOVI A E B: {a}, {b}");
    }

    static (int, int) OneIntoTwo(int numero)
    {
        int picco=0;
        int seco=0;
        if(numero%2==0)
        {
            picco=numero/2;
            seco=numero*2;
        }
        else
        {
            picco=numero;
            seco=numero;
        }
        return (picco, seco);
    }
}