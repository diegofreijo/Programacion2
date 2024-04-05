namespace p3_3
{
    class Arma
    {
        public string nombre;
        public int danio;

        public override string ToString()
        {
            return $"{nombre} hace {danio} de danio";
        }

        public void Daniar(Salud salud)
        {
            salud.Daniar(this.danio);
        }
    }

    class Salud
    {
        int valor;

        public Salud(int valorInicial)
        {
            this.valor = valorInicial;
        }

        public void Daniar(int danio)
        {
            Console.WriteLine($"Me estan daniando por {danio}");
            this.valor -= danio;
            if (valor <= 0)
            {
                this.valor = 0;
                Console.WriteLine("Me mori!");
            }
        }
    }

    public class Main
    {
        public static void Correr()
        {
            var espada = new Arma() { nombre = "Espada", danio = 10 };
            // Y el valor inicial?
            var salud = new Salud(25);

            espada.Daniar(salud);
            espada.Daniar(salud);
            espada.Daniar(salud);
        }
    }
}