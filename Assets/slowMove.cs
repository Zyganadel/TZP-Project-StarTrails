using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 p = transform.position;
        p.z -= 1 * Time.deltaTime;
        transform.position = p;
    }
}
