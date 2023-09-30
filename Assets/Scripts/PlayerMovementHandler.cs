using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementHandler : MonoBehaviour
{
    public float throttleMax = 10.0f;
    public float throttleMin = 0.0f;
    public float throttleValue;
    public Vector2 lookValue;
    private Transform tf;
    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
    }

    public void OnTestKey() { Debug.Log("Test message."); }

    public void OnThrottleUp()
    {
        Debug.Log("I'm supposed to do something");
        if (throttleValue < throttleMax) { throttleValue += 1 / Time.deltaTime; }
        if (throttleValue > throttleMax) { throttleValue = throttleMax; }
    }

    public void OnThrottleDown()
    {
        Debug.Log("I'm supposed to do something");
        if (throttleValue > throttleMin) { throttleValue -= 1 / Time.deltaTime; }
        if (throttleValue < throttleMin) { throttleValue = throttleMin; }
    }

    // take the vector2 "value" given by OnLook
    public void OnLook(InputValue value)
    {
        Debug.Log("I'm supposed to do something");
        lookValue = value.Get<Vector2>();
        tf.Rotate(lookValue.y, lookValue.x, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
