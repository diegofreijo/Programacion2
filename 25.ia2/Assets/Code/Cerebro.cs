using System;
using UnityEngine;

public abstract class Cerebro : MonoBehaviour
{
    protected bool vivo = true;

    private void FixedUpdate()
    {
        if (vivo)
            TomaDecision();
    }

    protected abstract void TomaDecision();
}