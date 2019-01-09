//--------------------------------
using UnityEngine;
using System.Collections;
//--------------------------------
public class CollideDestroy : MonoBehaviour
{
    //--------------------------------
    //当击中了具有相关tag属性的对象之后就会销毁
    public string TagCompare = string.Empty;
    //--------------------------------
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(TagCompare)) return;

        Object.Destroy(gameObject);
    }
}