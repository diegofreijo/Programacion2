public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Iniciando mapa");
        var mapa = new Mapa(20, 10);
        mapa.Dibujar();
    }
}