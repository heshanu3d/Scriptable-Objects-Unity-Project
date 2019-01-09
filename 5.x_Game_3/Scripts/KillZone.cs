using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    //--------------------------------
    //Amount to damage player per second
    public float Damage = 100f;
    //--------------------------------
    void OnTriggerStay2D(Collider2D other)
    {
        //如果player不存在则退出
        if (!other.CompareTag("Player")) return;

        //按指定的速度对玩家造成伤害
        if (PlayerControl.PlayerInstance != null)
            PlayerControl.Health -= Damage * Time.deltaTime;
    }
    //--------------------------------
}