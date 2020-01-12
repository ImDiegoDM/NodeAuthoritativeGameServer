using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class EthanScript : NodeBehaviour
{
    const string horizontalAxis = "Horizontal";
    const string verticalAxis = "Vertical";
    const string mouseXAxis = "Mouse X";
    const string mouseYAxis = "Mouse Y";

    Rigidbody rb;
    Vector3 velocity = Vector3.zero;
    Camera childCamera;

    public float friction = .1f;
    public float Speed = 17f;
    public float RotationSpeed = 1f;

    // Start is called before the first frame update
    protected override void Start()
    {
        rb = GetComponent<Rigidbody>();
        childCamera = GetComponentInChildren<Camera>();

        base.Start();
    }

    Vector3 Move(Vector3 dir){
        return dir * Speed;
    }

    void CalcMove(){
        if(Input.GetAxis(verticalAxis) > 0){
            velocity += Move(transform.forward);
        }

        if(Input.GetAxis(verticalAxis) < 0){
            velocity -= Move(transform.forward);
        }

        if(Input.GetAxis(horizontalAxis) < 0){
            velocity -= Move(transform.right);
        }

        if(Input.GetAxis(horizontalAxis) > 0){
            velocity += Move(transform.right);
        }

        if(velocity.magnitude < 0.1f){
            velocity = Vector3.zero;
        }

        velocity -= (velocity * friction);
        rb.AddForce(velocity);
    }

    void CalcMouseMove(){
        float yRotation = Input.GetAxis(mouseXAxis);
        if(yRotation != 0){
            Vector3 eulerRotation = Vector3.up * yRotation * RotationSpeed;
            Quaternion calcedRotation = Quaternion.Euler(eulerRotation);
            rb.MoveRotation(rb.rotation * calcedRotation);
        }

        float xRotation = Input.GetAxis(mouseYAxis);
        if(xRotation != 0){
            float rotation = xRotation * RotationSpeed;

            childCamera.transform.Rotate(rotation * -1,0,0);
        }
    }
    
    void FixedUpdate() {
        CalcMove();
        CalcMouseMove();
    }
}
