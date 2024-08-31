using System;
using Cinemachine;
using UnityEngine;

public class TerceraPersonaDisparadorController : MonoBehaviour
{
    [Header("Cinemachine")]
    [Tooltip("La camara para apuntar")]
    public CinemachineVirtualCamera aimCamera;
    public int prioridadApuntando = 5;

    public LayerMask aimColliderMask = new LayerMask();

    public Animator animator;
    public TerceraPersonaInputs input;
    public GameObject crosshair;

    public Transform aimTarget;

    [Header("Disparo")]
    public GameObject balaPrefab;
    public Transform balaSpawnPosition;


    private int aimLayerIndex;

    private void Start()
    {
        aimLayerIndex = animator.GetLayerIndex("Aim");
    }

    private void Update()
    {
        if (input.aim)
            Aiming();
        else
            NoAiming();
    }

    private void Aiming()
    {
        animator.SetLayerWeight(aimLayerIndex, 1f);
        aimCamera.Priority = prioridadApuntando;


        crosshair.SetActive(true);

        MoveAimTarget();
    }

    private void NoAiming()
    {
        animator.SetLayerWeight(aimLayerIndex, 0f);
        aimCamera.Priority = 0;

        crosshair.SetActive(false);
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
        transform.forward = aimDirection;
        // transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 30f);

        // Disparo
        if (input.shoot)
        {
            var balaDirection = (mouseWorldPosition - balaSpawnPosition.position).normalized;

            Instantiate(
                balaPrefab, balaSpawnPosition.position,
                Quaternion.LookRotation(balaDirection, Vector3.up)
            );
        }
    }
}