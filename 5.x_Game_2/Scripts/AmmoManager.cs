using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    public GameObject AmmoPrefab = null;
    public int PoolSize = 100;
    public Queue<Transform> AmmoQue = new Queue<Transform>();

    private GameObject[] AmmoArray;
    public static AmmoManager AmmoManagerSingleton = null;

    private void Awake()
    {
        if(AmmoManagerSingleton != null)
        {
            Object.Destroy(GetComponent<AmmoManager>());
            return;
        }
        AmmoManagerSingleton = this;
        AmmoArray = new GameObject[PoolSize];

        for(int i = 0; i < PoolSize; i++)
        {
            AmmoArray[i] = Instantiate(AmmoPrefab, Vector3.zero, Quaternion.identity) as GameObject;
            Transform tmpTransform = AmmoArray[i].GetComponent<Transform>();
            tmpTransform.parent = GetComponent<Transform>();
            AmmoQue.Enqueue(tmpTransform);
            AmmoArray[i].SetActive(false);
        }
    }

    public static Transform SpawnAmmo(Vector3 Position, Quaternion Rotation)
    {
        Transform SpawnedAmmoTransform = AmmoManagerSingleton.AmmoQue.Dequeue();
        SpawnedAmmoTransform.gameObject.SetActive(true);
        SpawnedAmmoTransform.position = Position;
        SpawnedAmmoTransform.localRotation = Rotation;

        AmmoManagerSingleton.AmmoQue.Enqueue(SpawnedAmmoTransform);

        return SpawnedAmmoTransform;
    }

}
