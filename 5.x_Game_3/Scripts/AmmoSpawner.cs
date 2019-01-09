using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSpawner : MonoBehaviour
{
    //--------------------------------
    //对炮弹预设体的引用
    public GameObject AmmoPrefab = null;

    //对transform的引用
    private Transform ThisTransform = null;

    //时间范围向量
    public Vector2 TimeDelayRange = Vector2.zero;

    //炮弹的生命周期
    public float AmmoLifeTime = 2f;
    //炮弹的速度
    public float AmmoSpeed = 4f;

    //炮弹的伤害值
    public float AmmoDamage = 100f;

    void Awake()
    {
        ThisTransform = GetComponent<Transform>();
    }
    //--------------------------------
    void Start()
    {
        FireAmmo();
    }
    //--------------------------------
    public void FireAmmo()
    {
        GameObject Obj = Instantiate(AmmoPrefab,
          ThisTransform.position, ThisTransform.rotation) as
            GameObject;
        Ammo AmmoComp = Obj.GetComponent<Ammo>();
        Mover MoveComp = Obj.GetComponent<Mover>();
        AmmoComp.LifeTime = AmmoLifeTime;
        AmmoComp.Damage = AmmoDamage;
        Obj.transform.localRotation = Quaternion.LookRotation(new Vector3(0f, -1f, 0f));
        //Debug.Log(Obj.transform.forward);
        MoveComp.Speed = AmmoSpeed;

        //等待直到下一个周期开始
        Invoke("FireAmmo", Random.Range(TimeDelayRange.x,
          TimeDelayRange.y));
    }
    //--------------------------------
}
