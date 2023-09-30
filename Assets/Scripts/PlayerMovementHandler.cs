using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementHandler : MonoBehaviour
{
    public float throttleMax = 10.0f;
    public float throttleMin = 0.0f;
    public float throttleValue = 0.0f;
    public Vector2 lookValue;
    private Transform tf;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }

    public void OnTestKey() { Debug.Log("Test message."); }

    public void OnThrottleUp()
    {
        if (throttleValue < throttleMax) { throttleValue += 1 / Time.deltaTime; }
        if (throttleValue > throttleMax) { throttleValue = throttleMax; }
    }

    public void OnThrottleDown()
    {
        if (throttleValue > throttleMin) { throttleValue -= 1 / Time.deltaTime; }
        if (throttleValue < throttleMin) { throttleValue = throttleMin; }
    }

    // take the vector2 "value" given by OnLook
    public void OnLook(InputValue value)
    {
        lookValue = value.Get<Vector2>();
        tf.Rotate(lookValue.y, lookValue.x, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rb.velocity.magnitude.ToString());
        rb.AddForce(tf.forward * throttleValue * Time.deltaTime);
    }
}
