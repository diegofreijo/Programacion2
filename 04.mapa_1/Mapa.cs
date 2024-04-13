public class Mapa
{
    private List<List<string>> celdas;

    public Mapa(int columnas, int filas)
    {
        this.celdas = new List<List<string>>();

        // Caso pared de arriba
        celdas.Add(new List<string>());
        for (int columna = 0; columna < columnas; columna++)
        {
            celdas[0].Add("#");
        }

        // Caso pared del medio
        for (int fila = 1; fila < filas - 1; fila++)
        {
            celdas.Add(new List<string>());
            celdas[fila].Add("#");
            for (int columna = 1; columna < columnas - 1; columna++)
            {
                celdas[fila].Add(" ");
            }
            celdas[fila].Add("#");
        }


        // Caso pared de abajo
        celdas.Add(new List<string>());
        for (int columna = 0; columna < columnas; columna++)
        {
            celdas[filas - 1].Add("#");
        }





    }

    public void Dibujar()
    {
        for (int fila = 0; fila < celdas.Count; fila++)
        {
            for (int columna = 0; columna < celdas[fila].Count; columna++)
            {
                Console.Write(celdas[fila][columna]);
            }
            Console.Write("\n");
        }

        //         Console.WriteLine(
        // """
        // ############################
        // #                          #
        // #                          #
        // #                          #
        // #                          #
        // #                          #
        // #                          #
        // #                          #
        // ############################
        // """);
    }
}