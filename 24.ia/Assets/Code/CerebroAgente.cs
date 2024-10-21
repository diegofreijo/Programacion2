using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CerebroAgente : Cerebro
{
    public GameObject[] puntosPatrulla;
    public NavMeshAgent agente;

    private int puntoPatrullaActual = 0;

    void Start()
    {
        agente.autoBraking = false;

        IrAlSiguientePunto();
    }

    private void IrAlSiguientePunto()
    {
        puntoPatrullaActual++;

        if (puntoPatrullaActual == puntosPatrulla.Length)
            puntoPatrullaActual = 0;

        agente.destination = puntosPatrulla[puntoPatrullaActual].transform.position;
    }

    protected override void TomaDecision()    
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!agente.pathPending && agente.remainingDistance < 0.5f)
            IrAlSiguientePunto();
    }
}
