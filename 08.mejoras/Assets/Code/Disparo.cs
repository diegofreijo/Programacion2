using UnityEngine;
using UnityEngine.InputSystem;

public class Disparo : MonoBehaviour
{
    public GameObject prefabImpacto;

    void OnCollisionEnter2D(Collision2D other)
    {
        // Instancio el prefab del impacto y lo ubico en mi posicion
        var goImpacto = Instantiate(prefabImpacto);
        goImpacto.transform.position = transform.position;

        // Me destruyo
        Destroy(gameObject);
    }
}