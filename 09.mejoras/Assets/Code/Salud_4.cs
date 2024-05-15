using UnityEngine;
using UnityEngine.Events;

public class Salud_4 : MonoBehaviour, ISalud
{
    public int restante = 100;

    public UnityEvent alMorir;

    public void Daniar(int danio)
    {
        this.restante -= danio;
        if (restante <= 0)
        {
            Debug.Log("Me mori");
            Destroy(gameObject);

            // Si hay alguna accion seteada al morir, hacerla
            if (alMorir != null)
                alMorir.Invoke();

            // Tambien se puede escribir en una sola linea:
            // alMorir?.Invoke();
        }
    }
}