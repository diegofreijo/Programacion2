public class Fila1
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
        var ret = new List<string>();
        ret.Add("#");
        ret.Add(".");
        ret.Add(".");
        ret.Add(".");
        ret.Add(".");
        ret.Add(".");
        ret.Add(".");
        ret.Add("#");
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