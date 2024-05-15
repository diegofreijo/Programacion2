using UnityEngine;

// Esta interfaz la tuve que hacer para que en el mismo proyecto pueda tener
// varias versiones de la Salud. Puede que ustedes no lo necesiten.
public interface ISalud
{
    void Daniar(int danio);
}

public class Salud : MonoBehaviour, ISalud
{
    public int restante = 100;
    public GameObject canvas;

    public void Daniar(int danio)
    {
        this.restante -= danio;
        if (restante <= 0)
        {
            Debug.Log("Me mori");
            Destroy(gameObject);

            // mostrar game over
            canvas.SetActive(true);
        }
    }
}