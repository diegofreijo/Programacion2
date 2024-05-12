using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public MovedorEnGrilla movedor;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Mover());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var saludDelOtro = collision.gameObject.GetComponent<Salud>();
        if (saludDelOtro != null)
            saludDelOtro.Daniar(100);
    }

    private IEnumerator Mover()
    {
        while (true)
        {
            // Debug.Log("Moviendo enemigo");
            var movimiento = new Vector2(
                Random.Range(-1, 2),
                Random.Range(-1, 2)
            );

            movedor.Mover(movimiento);

            yield return new WaitForSeconds(2);
        }
    }
}
