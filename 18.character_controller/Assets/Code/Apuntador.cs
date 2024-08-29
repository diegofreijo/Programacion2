using System;
using Cinemachine;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class Apuntador : MonoBehaviour
{
    [Header("Cinemachine")]
    [Tooltip("La camara para apuntar")]
    public CinemachineVirtualCamera apuntandoCamara;
    public int prioridadApuntando = 5;

    [Header("Acciones")]
    [Tooltip("Las acciones de input a usar")]
    public PersonaInputs _input;

    [Header("UI")]
    public GameObject crosshair;

    [Header("Animaciones")]
    public Animator animator;

    public Rig aimRig;

    public Transform aimTarget;
    public LayerMask aimColliderMask = new LayerMask();

    [Header("Disparo")]
    public GameObject balaPrefab;
    public Transform balaSpawnPosition;



    private int aimLayerIndex;

    private void Start()
    {
        crosshair.SetActive(false);
        aimLayerIndex = animator.GetLayerIndex("Aim");
    }

    private void Update()
    {
        if (_input.aim)
            Aiming();
        else
            NoAiming();
    }

    private void Aiming()
    {
        aimTarget.gameObject.SetActive(true);
        apuntandoCamara.Priority = prioridadApuntando;

        crosshair.SetActive(true);
        animator.SetBool("Aim", true);

        animator.SetLayerWeight(aimLayerIndex, 1f);
        aimRig.weight = 1f;

        MoveAimTarget();
    }


    private void NoAiming()
    {
        aimTarget.gameObject.SetActive(false);
        apuntandoCamara.Priority = 0;

        crosshair.SetActive(false);
        animator.SetBool("Aim", false);

        animator.SetLayerWeight(aimLayerIndex, 0f);
        aimRig.weight = 0f;
    }

    private void MoveAimTarget()
    {
        // Aim
        var mouseWorldPosition = Vector3.zero;

        var screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
        var ray = Camera.main.ScreenPointToRay(screenCenter);
        if (Physics.Raycast(ray, out RaycastHit hit, 999f, aimColliderMask))
        {
            aimTarget.position = hit.point;
            mouseWorldPosition = hit.point;
        }

        var aimDirection = (mouseWorldPosition - transform.position).normalized;
        transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 30f);

        // Disparo
        if (_input.shoot)
        {
            var balaDirection = (mouseWorldPosition - balaSpawnPosition.position).normalized;

            Instantiate(balaPrefab, balaSpawnPosition.position, Quaternion.LookRotation(balaDirection, Vector3.up));
        }

    }
}