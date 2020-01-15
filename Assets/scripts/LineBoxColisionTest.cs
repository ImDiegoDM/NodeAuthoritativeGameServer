using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineBoxColisionTest : MonoBehaviour
{
    public GameObject lineO;
    public GameObject lineEnd;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Calc(){
        Vector3 origemP = lineO.transform.position;
        Vector3 endP = lineEnd.transform.position;

        Debug.DrawLine(origemP,endP);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
