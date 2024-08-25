using UnityEngine;

public class Apuntador : MonoBehaviour
{
    [Header("Cinemachine")]
    [Tooltip("La camara de movimiento")]
    public GameObject moviendoCamara;
    [Tooltip("La camara para apuntar")]
    public GameObject apuntandoCamara;

    [Header("Acciones")]
    [Tooltip("Las acciones de input a usar")]
    public PersonaInputs _input;

    [Header("UI")]
    public GameObject crosshair;

    [Header("Animaciones")]
    public Animator animator;

    private void Start()
    {
        crosshair.SetActive(false);
    }

    private void Update()
    {
        if (_input.aim && !apuntandoCamara.activeInHierarchy)
        {
            moviendoCamara.SetActive(false);
            apuntandoCamara.SetActive(true);

            crosshair.SetActive(true);

            animator.SetBool("Aim", true);
        }
        else if (!_input.aim && !moviendoCamara.activeInHierarchy)
        {
            moviendoCamara.SetActive(true);
            apuntandoCamara.SetActive(false);

            crosshair.SetActive(false);

            animator.SetBool("Aim", false);
        }
    }
}