public class p1
{
    public static void Correr()
    {
        var valores = new int[] { 2, 4, 1, 3 };
        var resultado = sumarTodos(valores);
        Console.WriteLine($"La suma dio {resultado}");
    }

    private static int sumarTodos(int[] valores)
    {
        var ret = 0;
        foreach (var item in valores)
        {
            ret += item;
        }
        return ret;
    }
}