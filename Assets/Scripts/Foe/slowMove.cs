using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowMove : MonoBehaviour
{
    public float xMove;
    public float yMove;
    public float zMove = -0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 p = transform.position;
        p.x += xMove * Time.deltaTime;
        p.y += yMove * Time.deltaTime;
        p.z += zMove * Time.deltaTime;
        transform.position = p;
    }
}
