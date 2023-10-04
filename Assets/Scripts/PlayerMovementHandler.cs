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
    public float speedMult = 1;
    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OnTestKey() { Debug.Log("Test message."); }

    public void OnThrottleUp()
    {
        if (throttleValue < throttleMax) { throttleValue += 1; }
        if (throttleValue > throttleMax) { throttleValue = throttleMax; }
    }

    public void OnThrottleDown()
    {
        if (throttleValue > throttleMin) { throttleValue -= 1; }
        if (throttleValue < throttleMin) { throttleValue = throttleMin; }
    }

    public void OnEscape() { Application.Quit(); }

    // take the vector2 "value" given by OnLook
    public void OnLook(InputValue value)
    {
        lookValue = value.Get<Vector2>();
        //rotate the parent of player stuff by the look value, but multiply it by 0.5
        tf.Rotate(lookValue.y * 0.5f, lookValue.x * 0.5f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.deltaTime * speedMult;
        rb.AddForce(tf.forward * throttleValue * t);
    }
}
