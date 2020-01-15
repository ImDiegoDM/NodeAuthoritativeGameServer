using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneTest : MonoBehaviour
{
    public GameObject normal;
    public GameObject offset;

    public float xSize = 1f;
    public float ySize = 2f;

    private Plane plane;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void CalcPlane(){
    }

    // Update is called once per frame
    void Update()
    {
        CalcPlane();
    }
}
