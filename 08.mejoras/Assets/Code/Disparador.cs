using UnityEngine;
using UnityEngine.InputSystem;

public class Disparador : MonoBehaviour
{
    public GameObject prefabDisparo;
    public Camera camaraPrincipal;
    public float potenciaDisparo = 10f;

    public void OnFire(InputValue input)
    {
        var origen = transform.position;

        // Instancio un prefab de disparo
        var goDisparo = Instantiate(prefabDisparo);

        // El disparo arranca en mi posicion
        goDisparo.transform.position = origen;

        // Conviero la posicion del mouse (en coordenadas de pantalla) a posicion en el mundo.
        // Lo tiene que hacer la camara porque es la unica que entiende que se esta viendo y adonde.
        var mouseEnMundo = camaraPrincipal.ScreenToWorldPoint(Input.mousePosition);

        // El vector de direccion es destino - origen
        var direccionDisparo = mouseEnMundo - origen;
        direccionDisparo.z = 0f;

        // Lanzo el disparo en la direccion que calcule
        var rbDisparo = goDisparo.GetComponent<Rigidbody2D>();
        // var destino = new Vector3(
        //     mouseEnMundo.x,
        //     mouseEnMundo.y,
        //     0
        // );
        rbDisparo.AddForce(direccionDisparo * potenciaDisparo);
    }
}