//////////////
// Caso vacio

// Creo un arreglo de 3 posiciones. Cada posicion va a tener "" (string vacio)
var arregloVacio = new string[3];
// Devuelve ""
Console.WriteLine(arregloVacio[0]);

// Creo una lista vacia pero le aviso a C# que voy a tener 3 cosas
var listaVacia = new List<string>(3);
// Tira error
Console.WriteLine(listaVacia[0]);


//////////////
// Agregando elementos

// Solo puedo pisar los valores ya definidos
var arreglo = new string[3];
arreglo[0] = "Hola";
arreglo[1] = "que";
arreglo[2] = "tal";

// Puedo agregar todos los valores que quiera
var lista = new List<string>();
lista.Add("Hola");
lista.Add("que");
lista.Add("tal");


//////////////
// Iterando

for (int i = 0; i < arreglo.Length; i++)
{
    Console.WriteLine(arreglo[i]);
}

for (int i = 0; i < arreglo.Count(); i++)
{
    Console.WriteLine(lista[i]);
}


//////////////
// Iterando con foreach

foreach (var item in arreglo)
{
    Console.WriteLine(item);
}


foreach (var item in lista)
{
    Console.WriteLine(item);
}
