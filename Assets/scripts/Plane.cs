using UnityEngine;

public enum LinePlaneIntersection{
    ContainsLine,IntersectLine,Perpendicular
}

public struct PlanePosition{
    public Vector3 xLeft;
    public Vector3 xRight;
    public Vector3 yLeft;
    public Vector3 yRight;
}

public struct Plane{
    public Vector3 normal;
    public Vector3 offset;

    public LinePlaneIntersection Intersection(Line3 line){
        // test if the line is parallel to the plane
        if(Vector3.Dot(normal,line.LineDirection()) == 0){
            if(Vector3.Dot(normal,(line.origim - offset)) == 0){
                return LinePlaneIntersection.ContainsLine;
            }

            return LinePlaneIntersection.Perpendicular;
        }

        return LinePlaneIntersection.IntersectLine;
    }

    public Vector3? IntersectionPoint(Line3 line){
        if(Intersection(line) != LinePlaneIntersection.IntersectLine){
            return null;
        }

        float t = Vector3.Dot(normal,offset-line.origim)/Vector3.Dot(normal,line.LineDirection());
        return line.GetPoint(t);
    }
}