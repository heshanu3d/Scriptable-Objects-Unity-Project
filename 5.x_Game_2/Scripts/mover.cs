using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover : MonoBehaviour
{
    private Transform ThisTransform = null;
    public float MaxSpeed = 10f;

    void Start()
    {
        ThisTransform = GetComponent<Transform>();
    }

    void Update()
    {
        ThisTransform.position += ThisTransform.forward * MaxSpeed * Time.deltaTime;    
    }
}
