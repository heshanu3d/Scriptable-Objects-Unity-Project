using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float Speed = 10f;
    private Transform ThisTransform = null;
    //--------------------------------
    // 初始化函数
    void Awake()
    {
        ThisTransform = GetComponent<Transform>();
    }
    //--------------------------------
    // Update函数在每一帧调用一次

    void Update ()
    {
        //更新对象的位置
        ThisTransform.position += ThisTransform.forward * Speed * Time.deltaTime;
    }
}
