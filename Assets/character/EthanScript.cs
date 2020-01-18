using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class EthanScript : NodeBehaviour
{
    const string mouseXAxis = "Mouse X";
    const string mouseYAxis = "Mouse Y";
    const float gravity = 0.3f;

    BoxCollider boxCollider;
    NodeBox nodeBox;
    bool coliding = false;
    Camera childCamera;
    bool grounded = false;
    Vector3 jumpVelocity = Vector3.zero;

    public float speed = .01f;
    public float rotationSpeed = 1f;
    public float jumpSpeed = 1f;
    public float jumpForce = 2f;
    protected override void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        nodeBox = new NodeBox{
            center = boxCollider.bounds.center,
            extends = boxCollider.bounds.extents
        };

        childCamera = GetComponentInChildren<Camera>();
        base.Start();
    }

    void UpdateNodeBox(){
        nodeBox.center = boxCollider.bounds.center;
        nodeBox.extends = boxCollider.bounds.extents;
    }

    void DrawNodeBox(){
        foreach (Vector3 point in nodeBox.Points)
        {
            foreach (Vector3 point2 in nodeBox.Points)
            {
                if(point != point2){
                    Debug.DrawLine(point2,point,coliding ? Color.red:Color.white);
                }
            }
        }
    }

    private void CheckColision(){
        coliding = nodeBox.isColliding();
    }

    private bool Move(Vector3 position){
        if(nodeBox.CanGoThere(position)){
            transform.position = position;
            return true;
        }

        return false;
    }

    private void CalcGravity(){
        Vector3 gforce = Vector3.down * gravity;
        if(Move(transform.position + gforce)){
            grounded = false;
            return;
        }

        grounded = true;
    }

    private void CheckInput(){
        Vector3 direction = Vector3.zero;

        if(Input.GetKey(KeyCode.W)){
            direction += transform.forward;
        }

        if(Input.GetKey(KeyCode.S)){
            direction -= transform.forward;
        }

        if(Input.GetKey(KeyCode.A)){
            direction -= transform.right;
        }

        if(Input.GetKey(KeyCode.D)){
            direction += transform.right;
        }

        Vector3 velocity = direction * speed;
        if(velocity.magnitude > 0){
            Move(transform.position + velocity);
        }
    }

    private void CheckJump(){
        if(Input.GetKey(KeyCode.Space) && grounded){
            jumpVelocity = Vector3.up * jumpForce;
        }
        if(jumpVelocity.magnitude > 0.2f){
            Vector3 velocity = jumpVelocity * jumpSpeed;
            Vector3 negativeVelocity = jumpVelocity * -1;
            Debug.Log(negativeVelocity);
            jumpVelocity += negativeVelocity * jumpSpeed;
            Move(transform.position + velocity);
        }else{
            jumpVelocity = Vector3.zero;
        }
    }

    void CalcMouseMove(){
        float yRotation = Input.GetAxis(mouseXAxis);
        if(yRotation != 0){
            Vector3 eulerRotation = Vector3.up * yRotation * rotationSpeed;
            Quaternion calcedRotation = Quaternion.Euler(eulerRotation);
            transform.rotation *= calcedRotation;
        }

        float xRotation = Input.GetAxis(mouseYAxis);
        if(xRotation != 0){
            float rotation = xRotation * rotationSpeed;

            childCamera.transform.Rotate(rotation * -1,0,0);
        }
    }
    
    private void Update() {
        CheckColision();
        UpdateNodeBox();
        DrawNodeBox();
    }

    private void FixedUpdate() {
        CheckJump();
        CalcMouseMove();
        CheckInput();
        CalcGravity();
    }
}
