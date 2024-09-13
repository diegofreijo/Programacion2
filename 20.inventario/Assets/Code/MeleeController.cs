using System;
using Cinemachine;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class MeleeController : MonoBehaviour
{
    public LayerMask aimColliderMask = new LayerMask();

    public Animator animator;
    public TerceraPersonaInputs input;

    protected bool canShoot = true;

    private int animIDShoot;

    void Start()
    {
        animIDShoot = Animator.StringToHash("Shoot");
        InitializeWeapon();
    }

    protected virtual void InitializeWeapon()
    {
    }

    private void Update()
    {
        if (canShoot)
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