using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jugador : MonoBehaviour
{
    public void OnMove(InputValue input)
    {
        var movimiento = input.Get<Vector2>();
        transform.position = new Vector3(
            transform.position.x + movimiento.x,
            transform.position.y + movimiento.y,
            0
        );
    }
}
