public class ej1_3
{
    public void Correr()
    {
        List<string> fila = CrearFila(10);
        DibujarFila(fila);
    }


    // Dibuja una fila del mapa:
    // #......#
    private List<string> CrearFila(int tamanio)
    {
        var ret = new List<string>();

        ret.Add("#");
        for (int i = 1; i < tamanio - 1; i++)
        {
            ret.Add(".");
        }
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