using UnityEngine;
using UnityEngine.InputSystem;

public class Disparo : MonoBehaviour
{
    public GameObject prefabImpacto;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Si me choque contra algo que tiene Salud (un enemigo), le hago danio
        var saludDelOtro = collision.gameObject.GetComponent<Salud>();
        if (saludDelOtro != null)
            saludDelOtro.Daniar(100);
        
        // Instancio el prefab del impacto y lo ubico en mi posicion
        var goImpacto = Instantiate(prefabImpacto);
        goImpacto.transform.position = transform.position;

        // Me destruyo
        Destroy(gameObject);
    }
}