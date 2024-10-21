using System;
using Cinemachine;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class MeleeController : MonoBehaviour
{
    public LayerMask aimColliderMask = new LayerMask();

    public Animator animator;
    public CerebroJugador input;

    public Transform aimTarget;

    private void Update()
    {
        MoveAimTarget();
    }

    private void MoveAimTarget()
    {
        // Aim
        var mouseWorldPosition = Vector3.zero;

        var screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenter);
        if (Physics.Raycast(ray, out RaycastHit hit, 999f, aimColliderMask))
        {
            // Muevo el objetivo para que la pistola lo mire
            aimTarget.position = hit.point;
            mouseWorldPosition = hit.point;
        }

        // Hago que el jugador mire en la direccion del mouse en el mundo
        var aimDirection = (mouseWorldPosition - transform.position).normalized;
        // transform.forward = aimDirection;
        transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 1f);

        // Disparo
        if (input.shoot)
        {
            // var balaDirection = (mouseWorldPosition - balaSpawnPosition.position).normalized;

            // Instantiate(
            //     balaPrefab, balaSpawnPosition.position,
            //     Quaternion.LookRotation(balaDirection, Vector3.up)
            // );
        }
    }
}