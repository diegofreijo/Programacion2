using System.Runtime.InteropServices;
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

        Debug.Log($"pantalla: {Input.mousePosition} - mundo: {mouseEnMundo}");

        // El vector de direccion es destino - origen
        // El vector tiene que estar normalizado porque es una direccion. Quiero que su
        // longitud sea igual a 1.
        var direccionDisparo = (mouseEnMundo - origen).normalized;
        direccionDisparo.z = 0f;

        // Lanzo el disparo en la direccion que calcule
        var rbDisparo = goDisparo.GetComponent<Rigidbody2D>();
        rbDisparo.AddForce(direccionDisparo * potenciaDisparo);

        // Calculo la rotacion que tengo que darle al proyectil para que mire hacia adonde quiero
        float angulo = Mathf.Atan2(direccionDisparo.y, direccionDisparo.x) * Mathf.Rad2Deg;
        goDisparo.transform.eulerAngles = new Vector3(0, 0, angulo);
    }
}