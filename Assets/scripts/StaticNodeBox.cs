using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class StaticNodeBox : MonoBehaviour
{
    BoxCollider boxCollider;
    NodeBox nodeBox;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        
        nodeBox = new NodeBox{
            center = boxCollider.bounds.center,
            extends = boxCollider.bounds.extents
        };
    }

    void UpdateNodeBox(){
        
        nodeBox.center = boxCollider.bounds.center;
        nodeBox.extends = boxCollider.bounds.extents;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy() {
        NodeBox.RemoveBox(nodeBox.id);
    }
}
