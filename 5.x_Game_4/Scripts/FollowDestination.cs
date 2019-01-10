using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowDestination : MonoBehaviour
{
    private NavMeshAgent ThisAgent = null;
    public Transform Destination = null;

    // 初始化函数
    void Awake()
    {
        ThisAgent = GetComponent<NavMeshAgent>();
    }
    // Update函数会在每一帧调用一次
    void Update()
    {
        ThisAgent.SetDestination(Destination.position);
    }
}
