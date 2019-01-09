using UnityEngine;
using System.Collections;
//--------------------------------
public class PingPongMotion : MonoBehaviour
{
  //--------------------------------
  //对象的transformation属性
  private Transform ThisTransform = null;

  //原始位置
  private Vector3 OrigPos = Vector3.zero;

  //移动的轴
  public Vector3 MoveAxes = Vector2.zero;

  //速度
  public float Distance = 3f;
  //--------------------------------
  // 初始化函数
  void Awake ()
  {
    //获取 transform组件
    ThisTransform = GetComponent<Transform>();

    //Copy original position
    OrigPos = ThisTransform.position;
    }
  //--------------------------------
  // Update函数在每一帧被调用一次”
  void Update()
    {
        //使用ping pong函数来更新平台的位置
        ThisTransform.position = OrigPos + MoveAxes * Mathf.PingPong(Time.
    time, Distance);
    }
    //--------------------------------
}