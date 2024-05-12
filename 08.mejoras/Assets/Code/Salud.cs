using UnityEngine;

public class Salud : MonoBehaviour
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