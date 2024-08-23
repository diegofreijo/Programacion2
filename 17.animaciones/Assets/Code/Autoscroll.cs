using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autoscroll : MonoBehaviour
{
    public float velocidad = 1.0f;

    void FixedUpdate()
    {
        transform.Translate(Vector2.up * velocidad * Time.deltaTime);
    }
}
