namespace ej3_2
{
    public class Program()
    {
        public static void Correr()
        {
            List<Fila> filas = new List<Fila>()
            {
                new FilaBorde(10),
                new FilaMedia(10),
                new FilaMedia(10),
                new FilaMedia(10),
                new FilaBorde(10),
            };

            foreach (var fila in filas)
            {
                fila.Dibujar();
            }
        }
    }

    abstract class Fila
    {
        protected List<string> celdas;

        public Fila(int cantidadCeldas)
        {
            this.celdas = new List<string>();

            AgregarPunta();
            for (int i = 1; i < cantidadCeldas - 1; i++)
            {
                AgregarMedio();
            }
            AgregarPunta();
        }

        protected abstract void AgregarMedio();
        protected abstract void AgregarPunta();

        public void Dibujar()
        {
            foreach (var celda in celdas)
            {
                Console.Write(celda);
            }
            Console.WriteLine();
        }
    }

    class FilaMedia : Fila
    {
        public FilaMedia(int cantidadCeldas) : base(cantidadCeldas)
        {
        }

        protected override void AgregarMedio()
        {
            celdas.Add(".");
        }
        protected override void AgregarPunta()
        {
            celdas.Add("#");
        }
    }

    class FilaBorde : Fila
    {
        public FilaBorde(int cantidadCeldas) : base(cantidadCeldas)
        {
        }

        protected override void AgregarMedio()
        {
            celdas.Add("#");
        }
        protected override void AgregarPunta()
        {
            celdas.Add("#");
        }
    }
}
