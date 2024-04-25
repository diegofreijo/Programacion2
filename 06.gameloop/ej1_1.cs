namespace ej1_1
{
    public class Program()
    {
        public static void Correr()
        {
            // Inicializacion
            Habitacion habitacionGrande = new Habitacion(10, 5);
            Jugador jugador = new Jugador(2,2);

            // Game Loop!
            while (true)
            {
                // Escucho Input
                var input = Console.ReadKey();

                // Actualizo Datos
                if (input.Key == ConsoleKey.RightArrow)
                    jugador.MoverHacia(1, 0);
                if (input.Key == ConsoleKey.LeftArrow)
                    jugador.MoverHacia(-1, 0);
                if (input.Key == ConsoleKey.UpArrow)
                    jugador.MoverHacia(0, -1);
                if (input.Key == ConsoleKey.DownArrow)
                    jugador.MoverHacia(0, 1);

                // Dibujo Pantalla
                Lienzo lienzo = new Lienzo(10, 5);
                habitacionGrande.Dibujar(lienzo);
                jugador.Dibujar(lienzo);

                lienzo.MostrarEnPantalla();
            }
        }
    }

    class Jugador
    {
        private int x, y;
        public Jugador(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void MoverHacia(int x, int y)
        {
            this.x += x;
            this.y += y;
        }

        public void Dibujar(Lienzo lienzo)
        {
            lienzo.Dibujar(x, y, '@');
        }
    }

    class Lienzo
    {
        private char[,] celdas;
        private int ancho, alto;

        public Lienzo(int ancho, int alto)
        {
            this.ancho = ancho;
            this.alto = alto;
            celdas = new char[ancho, alto];
        }

        public void Dibujar(int x, int y, char celda)
        {
            celdas[x, y] = celda;
        }

        public void MostrarEnPantalla()
        {
            for (int y = 0; y < alto; y++)
            {
                for (int x = 0; x < ancho; x++)
                {
                    Console.Write(celdas[x, y]);
                }
                Console.Write("\n");
            }
        }
    }

    class Habitacion
    {
        private List<Fila> filas;

        public Habitacion(int ancho, int alto)
        {
            // Inicializo filas
            filas = new List<Fila>();

            filas.Add(new FilaBorde(ancho));
            for (int fila = 1; fila < alto - 1; fila++)
            {
                filas.Add(new FilaMedia(ancho));
            }
            filas.Add(new FilaBorde(ancho));
        }

        public void Dibujar(Lienzo lienzo)
        {
            for (int y = 0; y < filas.Count(); y++)
            {
                filas[y].Dibujar(lienzo, y);
            }
        }
    }

    abstract class Fila
    {
        protected List<char> celdas;

        public Fila(int cantidadCeldas)
        {
            this.celdas = new List<char>();

            AgregarPunta();
            for (int i = 1; i < cantidadCeldas - 1; i++)
            {
                AgregarMedio();
            }
            AgregarPunta();
        }

        protected abstract void AgregarMedio();
        protected abstract void AgregarPunta();

        public void Dibujar(Lienzo lienzo, int y)
        {
            for (int x = 0; x < celdas.Count(); x++)
            {
                lienzo.Dibujar(x, y, celdas[x]);
            }
        }
    }

    class FilaMedia : Fila
    {
        public FilaMedia(int cantidadCeldas) : base(cantidadCeldas)
        {
        }

        protected override void AgregarMedio()
        {
            celdas.Add('.');
        }
        protected override void AgregarPunta()
        {
            celdas.Add('#');
        }
    }

    class FilaBorde : Fila
    {
        public FilaBorde(int cantidadCeldas) : base(cantidadCeldas)
        {
        }

        protected override void AgregarMedio()
        {
            celdas.Add('#');
        }
        protected override void AgregarPunta()
        {
            celdas.Add('#');
        }
    }
}
