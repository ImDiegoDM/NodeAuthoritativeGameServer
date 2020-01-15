using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class EthanScript : NodeBehaviour
{
    CapsuleCollider capsuleCollider;
    Line3 capsuleLine;
    protected override void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();

        base.Start();
    }

    void CalcCapsuleLine(){
        Vector3 bottom = capsuleCollider.center + transform.position;
        bottom.y -= capsuleCollider.height/2 - capsuleCollider.radius;

        Vector3 top = capsuleCollider.center + transform.position;
        top.y += capsuleCollider.height/2 - capsuleCollider.radius;

        capsuleLine = new Line3{
            origim = bottom,
            end = top
        };

        Debug.DrawLine(bottom,top);

        Debug.Log(bottom);
    }
    
    private void Update() {
        CalcCapsuleLine();
    }
}
