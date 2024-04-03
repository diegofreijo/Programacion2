namespace p5
{
    abstract class Item
    {
        public string nombre;
    }

    interface IEquipable
    {
        void Equipar();
    }


    interface IUsable
    {
        void Usar(Salud salud);
    }

    class Arma : Item, IEquipable, IUsable
    {
        int danio;

        public Arma(int danio)
        {
            this.danio = danio;
        }

        public void Equipar()
        {
            Console.WriteLine($"Equipando el arma {nombre}");
        }

        public override string ToString()
        {
            return $"{nombre} hace {danio} de danio";
        }

        public void Usar(Salud salud)
        {
            salud.Daniar(this.danio);
        }
    }

    class Pocion : Item, IUsable
    {
        int curacion;

        public Pocion(int curacion)
        {
            this.curacion = curacion;
        }

        public void Usar(Salud salud)
        {
            salud.Curar(this.curacion);
        }
    }

    class Armadura : Item, IEquipable
    {
        public void Equipar()
        {
            Console.WriteLine($"Equipando la armadura {nombre}");
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
            Console.WriteLine("Probando IUsable");

            var usables = new IUsable[] {
                new Arma(10) { nombre = "Espada"},
                new Pocion(30),
            };

            var salud = new Salud(25);

            foreach (IUsable item in usables)
            {
                item.Usar(salud);
            }

            Console.WriteLine("--------------------------------------");

            Console.WriteLine("Probando IEquipable");

            var equipables = new IEquipable[] {
                new Arma(10) { nombre = "Espada"},
                new Armadura() { nombre = "Cota de Malla" },
            };

            foreach (IEquipable e in equipables)
            {
                e.Equipar();
            }
        }
    }
}