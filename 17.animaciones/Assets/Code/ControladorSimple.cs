using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControladorSimple : MonoBehaviour
{
    public Animator animator;

    public void OnJump()
    {
        animator.SetTrigger("Jump");
    }
}
