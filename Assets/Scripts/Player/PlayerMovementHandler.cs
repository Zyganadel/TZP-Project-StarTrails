using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementHandler : MonoBehaviour
{
    public float lookSensitivity = 1f;
    public float rollSensitivity = 1;
    public float throttleMax = 10.0f;
    public float throttleMin = 0.0f;
    public float throttleValue = 0.0f;
    float throttleMod;
    float rollValue;
    public Vector2 lookValue;
    private Transform tf;
    private Rigidbody rb;
    public float speedMult = 1;
    public Vector3 forward;
    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OnTestKey() { Debug.Log("Test message."); }

    public void OnThrottle(InputValue value)
    {
        float rValue = value.Get<float>();
        throttleMod = rValue;
        Debug.Log(rValue);
    }

    public void OnEscape() { Application.Quit(); }

    // take the vector2 "value" given by OnLook
    public void OnLook(InputValue value)
    {
        lookValue = value.Get<Vector2>();
    }

    void OnRoll(InputValue value)
    {
        rollValue = value.Get<float>();
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.deltaTime;
        float timedRot = t * lookSensitivity * 50;
        float timedRoll = t * rollSensitivity * 50;

        //rotate the parent of player stuff by whatever values we have.
        rb.AddRelativeTorque(lookValue.y * timedRot, lookValue.x * timedRot, rollValue * timedRoll);

        float timedMove = t * speedMult;

        throttleValue += throttleMod * t;

        if (throttleValue > throttleMax) { throttleValue = throttleMax; }
        if (throttleValue < throttleMin) { throttleValue = throttleMin; }

        rb.AddForce(tf.forward * throttleValue * timedMove);
    }
}
