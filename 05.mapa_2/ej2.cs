namespace ej2
{
    public class Program()
    {
        public static void Correr()
        {
            Fila fila = new Fila(100);
            fila.Dibujar();
        }
    }

    class Fila
    {
        private List<string> celdas;

        public Fila(int tamanio)
        {
            this.celdas = new List<string>();

            celdas.Add("#");
            for (int i = 1; i < tamanio - 1; i++)
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
        }
    }
}
