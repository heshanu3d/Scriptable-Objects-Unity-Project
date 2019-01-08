using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public float Damage = 100f;
    public float LifeTime = 2f;

    private void OnEnable()
    {
        CancelInvoke();
        Invoke("Die", LifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Health hp = other.gameObject.GetComponent<Health>();
        if (hp == null) return;
        hp.HealthPoints -= Damage;
    }

    void Die()
    {
        gameObject.SetActive(false);
    }
}
