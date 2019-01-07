using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProxyDamage : MonoBehaviour
{
    public float DamageRate = 10f;

    private void OnTriggerStay(Collider other)
    {
        Health hp = other.gameObject.GetComponent<Health>();
        if (hp == null) return;
        hp.HealthPoints -= DamageRate * Time.deltaTime;
    }
}
