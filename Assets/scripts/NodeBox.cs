using System.Collections.Generic;
using UnityEngine;

public class NodeBox{
    private static Dictionary<int,NodeBox> boxes = new Dictionary<int,NodeBox>();
    private static int increment = 0;

    public static void RemoveBox(int id){
        boxes.Remove(id);
    }

    public int id;
    public Vector3 center;
    public Vector3 extends;
    public Vector3 min { 
        get {
            return new Vector3(
                center.x-extends.x,
                center.y-extends.y,
                center.z-extends.z
            );
        } 
    }
    public Vector3 max { 
        get {
            return new Vector3(
                center.x+extends.x,
                center.y+extends.y,
                center.z+extends.z
            );
        } 
    }

    public Vector3[] Points {
        get {
            return new Vector3[]{
                new Vector3(min.x,min.y,min.z),
                new Vector3(max.x,min.y,min.z),
                new Vector3(min.x,min.y,max.z),
                new Vector3(max.x,min.y,max.z),
                new Vector3(max.x,max.y,max.z),
                new Vector3(min.x,max.y,max.z),
                new Vector3(max.x,max.y,min.z),
                new Vector3(min.x,max.y,min.z),
            };
        }
    }

    public NodeBox(){
        id = increment;
        increment++;
        boxes.Add(id,this);
    }

    public bool intersect(NodeBox box){
        return (min.x <= box.max.x && max.x >= box.min.x) &&
            (min.y <= box.max.y && max.y >= box.min.y) &&
            (min.z <= box.max.z && max.z >= box.min.z);
    }

    public bool isPointInside(Vector3 point){
        return (point.x >= min.x && point.x <= max.x) &&
         (point.y >= min.y && point.y <= max.y) &&
         (point.z >= min.z && point.z <= max.z);
    }

    public bool isColliding(){
        foreach (NodeBox box in boxes.Values)
        {
            if(box.id != id){
                if(intersect(box)){
                    return true;
                }
            }
        }

        return false;
    }

    public bool CanGoThere(Vector3 position){
        Vector3 oldPosition = center;

        center = position;

        if(isColliding()){
            center = oldPosition;
            return false;
        }
        
        return true;
    }

}