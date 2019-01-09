using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private RectTransform ThisTransform = null;

    //速度
    public float MaxSpeed = 10f;

    void Awake()
    {

        //获取 transform组件
        ThisTransform = GetComponent<RectTransform>();
    }

    void Start()
    {
        //设置初始的生命值
        if (PlayerControl.PlayerInstance != null)
            ThisTransform.sizeDelta = new
              Vector2(Mathf.Clamp(PlayerControl.Health, 0, 100), ThisTransform.sizeDelta.y);
    }

    // Update函数在每一帧调用一次
    void Update()
    {
        //更新生命值属性
        float HealthUpdate = 0f;

        if (PlayerControl.PlayerInstance != null)
            HealthUpdate = Mathf.MoveTowards(ThisTransform.rect.width,PlayerControl.Health, MaxSpeed);

        ThisTransform.sizeDelta = new
          Vector2(Mathf.Clamp(HealthUpdate, 0, 100), ThisTransform.sizeDelta.y);
    }
}
