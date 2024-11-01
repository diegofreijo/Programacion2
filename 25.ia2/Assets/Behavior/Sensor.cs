using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Sensor : MonoBehaviour
{
    public float detectionRadius = 10f;
    public List<string> targetTags = new();

    readonly List<Transform> detectedObjects = new(10);
    SphereCollider sphereCollider;

    void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.isTrigger = true;
        sphereCollider.radius = detectionRadius;

        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius);
        foreach (var c in colliders)
        {
            AddObject(c);
        }
    }

    private void AddObject(Collider c)
    {
        Debug.Log($"Found {c.gameObject.name}");
        ProcessTrigger(c, transform => detectedObjects.Add(transform));
    }

    void OnTriggerEnter(Collider other)
    {
        AddObject(other);
    }

    void OnTriggerExit(Collider other)
    {
        ProcessTrigger(other, transform => detectedObjects.Remove(transform));
    }

    void ProcessTrigger(Collider other, Action<Transform> action)
    {
        if (other.CompareTag("Untagged")) return;

        foreach (string t in targetTags)
        {
            if (other.CompareTag(t))
            {
                action(other.transform);
            }
        }
    }

    public GameObject GetClosestGameObject(string tag)
    {
        var ret = GetClosestTarget(tag);
        return ret == null ? null : ret.gameObject;
    }

    public Transform GetClosestTarget(string tag)
    {
        if (detectedObjects.Count == 0) return null;

        Transform closestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;

        foreach (Transform potentialTarget in detectedObjects)
        {
            if (potentialTarget.CompareTag(tag))
            {
                Vector3 directionToTarget = potentialTarget.position - currentPosition;
                float dSqrToTarget = directionToTarget.sqrMagnitude;
                if (dSqrToTarget < closestDistanceSqr)
                {
                    closestDistanceSqr = dSqrToTarget;
                    closestTarget = potentialTarget;
                }
            }
        }
        return closestTarget;
    }
}