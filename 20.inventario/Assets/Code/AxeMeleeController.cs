using UnityEngine;

public class AxeMeleeController : MeleeController
{
    public bool hasAxe = false;
    public GameObject[] axeArms;

    protected override void InitializeWeapon()
    {
        SetActiveArms(false);
        base.canShoot = false;
    }

    public void GrabbedAxe()
    {
        SetActiveArms(true);
        base.canShoot = true;
        hasAxe = true;
    }

    private void SetActiveArms(bool active)
    {
        foreach (var go in axeArms)
            go.SetActive(active);
    }

    private void OnTriggerEnter(Collider other)
    {
        var pickup = other.GetComponent<AxePickup>();
        if (pickup != null)
        {
            this.GrabbedAxe();
            Destroy(pickup.gameObject);
        }
    }
}

// Salud.cs
// Mana.cs
// Armadura.cs
// LevantadorDeBurbujas.cs
