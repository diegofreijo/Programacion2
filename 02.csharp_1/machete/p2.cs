namespace p2
{
    public class Arma
    {
        public string nombre;
        public int danio;

        public override string ToString()
        {
            return $"{nombre} hace {danio} de danio";
        }
    }
    public class Main
    {
        public static void Correr()
        {
            var armas = new Arma[] {
                new Arma() {nombre= "Daga", danio= 2},
                new Arma() {nombre= "Espada", danio= 10},
                new Arma() {nombre= "Bomba", danio= 30},
             };

            ListarArmas(armas);
        }

        private static void ListarArmas(Arma[] armas)
        {
            foreach (var item in armas)
                Console.WriteLine(item);
        }
    }
}