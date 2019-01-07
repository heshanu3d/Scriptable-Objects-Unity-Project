using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static int CoinCount = 0;
    void Start()
    {
        Coin.CoinCount++;
    }

    private void OnDestroy()
    {
        Coin.CoinCount--;
        if(Coin.CoinCount <= 0)
        {
            GameObject Timer = GameObject.Find("LevelTimer");
            //Destroy(Timer);
            Object.Destroy(Timer);
            GameObject[] FireworkSystem = GameObject.FindGameObjectsWithTag("Fireworks");
            foreach(GameObject go in FireworkSystem)
            {
                go.GetComponent<ParticleSystem>().Play();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ( other.CompareTag("Player") )
        {
            Object.Destroy(gameObject);
            //Destroy(gameObject);
        }
    }
}
