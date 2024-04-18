namespace ej3_1
{
    public class Program()
    {
        public static void Correr()
        {
            Console.WriteLine("Fila media:");
            FilaMedia filaMedia = new FilaMedia(10);
            filaMedia.Dibujar();

            Console.WriteLine("Fila borde:");
            FilaBorde filaBorde = new FilaBorde(10);
            filaBorde.Dibujar();
        }
    }

    class FilaMedia
    {
        private List<string> celdas;

        public FilaMedia(int cantidadCeldas)
        {
            this.celdas = new List<string>();

            celdas.Add("#");
            for (int i = 1; i < cantidadCeldas - 1; i++)
            {
                celdas.Add(".");
            }
            celdas.Add("#");
        }


        public void Dibujar()
        {
            foreach (var celda in celdas)
            {
                Console.Write(celda);
            }
            Console.WriteLine();
        }
    }

    class FilaBorde
    {
        private List<string> celdas;

        public FilaBorde(int cantidadCeldas)
        {
            this.celdas = new List<string>();

            celdas.Add("#");
            for (int i = 1; i < cantidadCeldas - 1; i++)
            {
                celdas.Add("#");
            }
            celdas.Add("#");
        }


        public void Dibujar()
        {
            foreach (var celda in celdas)
            {
                Console.Write(celda);
            }
            Console.WriteLine();
        }
    }
}
