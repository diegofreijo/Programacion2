
namespace p5
{
    abstract class Item
    {
        public string nombre;
        public abstract void Usar(Salud salud);
    }

    class Arma : Item
    {
        int danio;

        public Arma(int danio)
        {
            this.danio = danio;
        }

        public override string ToString()
        {
            return $"{nombre} hace {danio} de danio";
        }

        public override void Usar(Salud salud)
        {
            salud.Daniar(this.danio);
        }
    }

    class Pocion : Item
    {
        int curacion;

        public Pocion(int curacion)
        {
            this.curacion = curacion;
        }

        public override void Usar(Salud salud)
        {
            salud.Curar(this.curacion);
        }
    }


    class Salud
    {
        private int valor;

        public Salud(int valorInicial)
        {
            this.valor = valorInicial;
        }

        public void Daniar(int danio)
        {
            Console.WriteLine($"Me estan daniando por {danio}");
            this.valor -= danio;
            Console.WriteLine($"Ahora tengo {valor}");

            if (valor <= 0)
            {
                this.valor = 0;
                Console.WriteLine("Me mori!");
            }
        }

        public void Curar(int curacion)
        {
            Console.WriteLine($"Me estan curando por {curacion}");
            this.valor += curacion;
            Console.WriteLine($"Ahora tengo {valor}");
        }
    }

    public class Main
    {
        public static void Correr()
        {
            var inventario = new Item[] {
                new Arma(10) { nombre = "Espada"},
                new Pocion(30),
            };

            var salud = new Salud(25);

            foreach (Item item in inventario)
            {
                item.Usar(salud);
            }
        }
    }
}