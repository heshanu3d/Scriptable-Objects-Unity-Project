using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjFace : MonoBehaviour
{
    public Transform ObjToFollow = null;
    public bool FollowPlayer = false;
    private Transform ThisTransform = null;

    private void Awake()
    {
        ThisTransform = GetComponent<Transform>();
        if (!FollowPlayer) return;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
        {
            ObjToFollow = player.GetComponent<Transform>();
        }

        //ObjToFollow = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (ObjToFollow == null) return;
        Vector3 DirectionToPlayer = ObjToFollow.position - ThisTransform.position;
        if (DirectionToPlayer != Vector3.zero)
        {
            ThisTransform.localRotation = Quaternion.LookRotation(DirectionToPlayer.normalized, Vector3.up);
        }
    }
}
