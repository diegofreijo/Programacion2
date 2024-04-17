public class Fila2
{
    public void Correr()
    {
        List<string> fila = CrearFila();
        DibujarFila(fila);
    }


    // Dibuja una fila del mapa:
    // #......#
    private List<string> CrearFila()
    {
        var ret = new List<string>
        {
            "#",
            ".",
            ".",
            ".",
            ".",
            ".",
            ".",
            "#"
        };
        return ret;
    }

    private void DibujarFila(List<string> fila)
    {
        foreach (var celda in fila)
        {
            Console.Write(celda);
        }
    }
}