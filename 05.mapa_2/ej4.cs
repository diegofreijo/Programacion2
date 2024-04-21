namespace ej4
{
    public class Program()
    {
        public static void Correr()
        {
            Console.WriteLine("Habitacion chica:");
            Habitacion habitacionChica = new Habitacion(5, 4);
            habitacionChica.Dibujar();

            Console.WriteLine("Habitacion grande:");
            Habitacion habitacionGrande = new Habitacion(15, 5);
            habitacionGrande.Dibujar();


        }
    }

    class Habitacion
    {
        private List<Fila> filas;

        public Habitacion(int ancho, int alto)
        {
            filas = new List<Fila>();

            filas.Add(new FilaBorde(ancho));
            for (int fila = 1; fila < alto - 1; fila++)
            {
                filas.Add(new FilaMedia(ancho));
            }
            filas.Add(new FilaBorde(ancho));
        }

        public void Dibujar()
        {
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
