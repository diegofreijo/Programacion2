using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeHitArea : MonoBehaviour
{
    // public GameObject impactPrefab;

    private void OnTriggerEnter(Collider other)
    {
        // Instantiate(impactPrefab, transform.position, transform.rotation);
        Debug.Log(other.gameObject.name);

        // other.GetComponent<Salud>().Damage(100)
    }
}
