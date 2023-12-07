using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missileTargeter : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;

    private void Start()
    {
        GetTarget();
    }

    public RaycastHit GetTarget()
    {
        GameObject player = GameObject.Find("Player");
        ray = new Ray();
        ray.direction = transform.forward;
        ray.origin = transform.position;
        Physics.Raycast(ray, out hit);
        return hit;
    }

    private void Update()
    {
        GetTarget();
        Debug.DrawRay(ray.origin,ray.direction, Color.green);
    }
}
