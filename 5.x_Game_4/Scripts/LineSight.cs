using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSight : MonoBehaviour
{
    public enum SightSensitivity { STRICT, LOOSE };

    //瞄准具灵敏度
    public SightSensitivity Sensitity = SightSensitivity.STRICT;

    //我们能看到目标吗？
    public bool CanSeeTarget = false;

    //视野
    public float FieldOfView = 45f;

    //对目标的引用
    private Transform Target = null;

    //对眼睛的引用
    public Transform EyePoint = null;

    //对“transform”组件的引用
    private Transform ThisTransform = null;

    //对球状碰撞体的引用
    private SphereCollider ThisCollider = null;

    //对最后对象视野的引用
    public Vector3 LastKnowSighting = Vector3.zero;
    
    void Awake()
    {
        ThisTransform = GetComponent<Transform>();
        ThisCollider = GetComponent<SphereCollider>();
        LastKnowSighting = ThisTransform.position;
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    
    bool InFOV()
    {
        //获取到目标的方向
        Vector3 DirToTarget = Target.position - EyePoint.position;

        //获取正前方和目标之间的角度
        float Angle = Vector3.Angle(EyePoint.forward, DirToTarget);

        //我们在视野中吗?
        if (Angle <= FieldOfView)
            return true;

        //不在视野中
        return false;
    }
    
    bool ClearLineofSight()
    {
        RaycastHit Info;

        if (Physics.Raycast(EyePoint.position, (Target.position - EyePoint.position).normalized, out Info, ThisCollider.radius))
        {
            //如果看到Player了
            if (Info.transform.CompareTag("Player"))
                return true;
        }

        return false;
    }
    
    void UpdateSight()
    {
        switch (Sensitity)
        {
            case SightSensitivity.STRICT:
                CanSeeTarget = InFOV() && ClearLineofSight();
                break;

            case SightSensitivity.LOOSE:
                CanSeeTarget = InFOV() || ClearLineofSight();
                break;
        }
    }
    
    void OnTriggerStay(Collider Other)
    {
        UpdateSight();

        //更新最后的视野
        if (CanSeeTarget)
            LastKnowSighting = Target.position;
    }
    
    void OnTriggerExit(Collider Other)
    {
        if (!Other.CompareTag("Player")) return;

        CanSeeTarget = false;
    }
}
