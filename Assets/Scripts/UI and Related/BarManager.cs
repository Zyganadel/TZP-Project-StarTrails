using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarManager : MonoBehaviour
{
    public float hpFloat;
    Transform tf;
    void Start()
    {
        tf = GetComponent<Transform>();
    }

    
    void Update()
    {
        Vector3 scale = tf.localScale;
        scale.y = hpFloat;
        tf.localScale = scale;
    }
}
