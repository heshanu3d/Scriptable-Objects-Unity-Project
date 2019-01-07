using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody ThisBody = null;
    private Transform ThisTransform = null;

    public bool MouseLook = true;
    public string HorzAxis = "Horizontal";
    public string VertAxis = "Vertical";
    public string FireAxis = "Fire1";
    public float MaxSpeed = 5f;

    private void Awake()
    {
        ThisBody = GetComponent<Rigidbody>();
        ThisTransform = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        float Horz = Input.GetAxis(HorzAxis);
        float Vert = Input.GetAxis(VertAxis);
        Vector3 MoveDirection = new Vector3(Horz, 0f, Vert);
        ThisBody.AddForce(MoveDirection.normalized * MaxSpeed);

        ThisBody.velocity = new Vector3(
            Mathf.Clamp(MoveDirection.x, -MaxSpeed, MaxSpeed),
            Mathf.Clamp(MoveDirection.y, -MaxSpeed, MaxSpeed),
            Mathf.Clamp(MoveDirection.z, -MaxSpeed, MaxSpeed));
        
        if (MouseLook)
        {
            Vector3 MousePosWorld = Camera.main.ScreenToWorldPoint(new Vector3(
                Input.mousePosition.x, Input.mousePosition.y, 0f));
            MousePosWorld = new Vector3(MousePosWorld.x, 0f, MousePosWorld.z);
            Vector3 LookDirection = MousePosWorld - ThisTransform.position;
            ThisTransform.localRotation = Quaternion.LookRotation(LookDirection.normalized,Vector3.up);
        }
    }
}
