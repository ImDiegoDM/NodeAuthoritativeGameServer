using UnityEngine;
public struct Line3{
    public Vector3 origim;
    public Vector3 end;

    public bool finite;

    public Line3(Vector3 origim,Vector3 end): this(origim,end,true) {}

    public Line3(Vector3 origim,Vector3 end, bool finite){
        this.origim = origim;
        this.end = end;
        this.finite = finite;
    }

    public Vector3 LineDirection(){
        return end - origim;
    }

    public float Distance(Vector3 point){
        // calculate and normalize de line direction
        Vector3 d = (end - origim);
        d = d / d.magnitude;

        // vetor origim ponto
        Vector3 OP = point - origim;
        // distance between origim and projection point into origim direction vector
        float t = Vector3.Dot(OP,d);
        // the projection vector
        Vector3 p = origim + t * d;

        return Vector3.Distance(p,point);
    }

    public Vector3? GetPoint(float t){
        if(finite && (t < 0 || t > 1)){
            return null;
        }

        return origim + t * LineDirection();
    }
}