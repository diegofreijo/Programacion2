using System;
using Cinemachine;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class MeleeController : MonoBehaviour
{
    public LayerMask aimColliderMask = new LayerMask();

    public Animator animator;
    public TerceraPersonaInputs input;

    private int animIDShoot;

    private void Start()
    {
        animIDShoot = Animator.StringToHash("Shoot");
    }

    private void Update()
    {
        animator.SetBool(animIDShoot, input.shoot);
        // Disparo
        // if (input.shoot)
        // {

        // var balaDirection = (mouseWorldPosition - balaSpawnPosition.position).normalized;

        // Instantiate(
        //     balaPrefab, balaSpawnPosition.position,
        //     Quaternion.LookRotation(balaDirection, Vector3.up)
        // );
        // }
    }
}