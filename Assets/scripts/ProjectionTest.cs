using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectionTest : MonoBehaviour
{
    public GameObject origim;
    public GameObject direction;
    public GameObject ToProject;

    public float t = .5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Projection(){
        Vector3 oP = origim.transform.position;
        Vector3 dP = direction.transform.position;
        Vector3 tP = ToProject.transform.position;

        Debug.DrawLine(oP,dP);
        //Debug.DrawLine(oP,tP);

        // calculate and normalize the line direction
        Vector3 d = (dP - oP);
        d = d / d.magnitude;

        // vetor origim ponto
        Vector3 OP = tP - oP;
        // distance between origim and projection point into origim direction vector
        float projectionT = Vector3.Dot(OP,d);

        projectionT = Mathf.Max(0,projectionT);

        projectionT = Mathf.Min(projectionT,Vector3.Distance(oP,dP));

        // the projection vector
        Vector3 p = oP + projectionT * d;

        Debug.DrawLine(tP,p,Color.red);

        Debug.Log(Vector3.Distance(p,tP));
    }

    void Line(){
        Vector3 oP = origim.transform.position;
        Vector3 dP = direction.transform.position;

        Vector3 d = (dP - oP);

        Vector3 p = oP + t * d;

         Debug.DrawLine(oP,p,Color.red);
    }

    // Update is called once per frame
    void Update()
    {
        Projection();
    }
}
