using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
//-----------------------------------------
    //对玩家造成的伤害
    public float Damage = 100f;

    //炮弹的生命周期
    public float LifeTime = 1f;
    //-----------------------------------------
    void Start()
    {
        Invoke("Die", LifeTime);
    }//-----------------------------------------

    void OnTriggerEnter2D(Collider2D other)
    {
        //如果玩家对象不存在，则退出游戏
        if (!other.CompareTag("Player")) return;

        //造成伤害
        PlayerControl.Health -= Damage;
    }
    //-----------------------------------------
    public void Die()
    {
        Destroy(gameObject);
    }
}
