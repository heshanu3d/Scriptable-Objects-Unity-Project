using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject DeathParticlesPrefab = null;
    private Transform ThisTransform = null;
    public bool ShouldDestroyOnDeath = true;
    [SerializeField]
    private float _HealthPoints = 100f;

    public float HealthPoints
    {
        get
        {
            return _HealthPoints;
        }

        set
        {
            _HealthPoints = value;
            if(_HealthPoints <= 0)
            {
                SendMessage("Die", SendMessageOptions.DontRequireReceiver);

                if (DeathParticlesPrefab != null)
                {
                    Instantiate(DeathParticlesPrefab, ThisTransform.position, ThisTransform.rotation);
                }

                if (ShouldDestroyOnDeath)
                    Object.Destroy(gameObject);
            }
        }
    }

    private void Start()
    {
        ThisTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.V))
        {
            HealthPoints = 0;
        }
    }
}
