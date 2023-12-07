using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementHandler : MonoBehaviour
{
    [SerializeField] string userPrefLoc = "userprefs.cfg";
    [SerializeField] float lookSensitivity = 1f;
    [SerializeField] float rollSensitivity = 1;
    [SerializeField] float throttleMax = 10.0f;
    [SerializeField] float throttleMin = 0.0f;
    [SerializeField] float throttleValue = 0.0f;
    [SerializeField] float speedMult = 1;
    [SerializeField] bool useWrongFlightControls = false;
    float throttleMod;
    float rollValue;
    public Vector2 lookValue;
    private Transform tf;
    private Rigidbody rb;
    public Vector3 forward;

    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        ImportControlPrefs();
    }

    void ImportControlPrefs()
    {
        // Create file with default values if userprefs doesn't exist.
        if (!File.Exists(userPrefLoc))
        {
            string[] write =
            {
                $"{lookSensitivity}",
                $"{rollSensitivity}",
                $"{useWrongFlightControls}"
            };
            File.WriteAllLines(userPrefLoc, write);
        }
        // But read things if the file does exist.
        else
        {
            string[] read = File.ReadAllLines(userPrefLoc);
            lookSensitivity = float.Parse(read[0]);
            rollSensitivity = float.Parse(read[1]);
            useWrongFlightControls = bool.Parse(read[2]);
        }
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
        if (useWrongFlightControls) { lookValue.y *= -1; }
    }

    void OnRoll(InputValue value)
    {
        rollValue = value.Get<float>();
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.deltaTime;
        float timedRot = t * lookSensitivity * 15;
        float timedRoll = t * rollSensitivity * 25;

        //rotate the parent of player stuff by whatever values we have.
        rb.AddRelativeTorque(lookValue.y * timedRot, lookValue.x * timedRot, rollValue * timedRoll);

        float timedMove = t * speedMult;

        throttleValue += throttleMod * t;

        if (throttleValue > throttleMax) { throttleValue = throttleMax; }
        if (throttleValue < throttleMin) { throttleValue = throttleMin; }

        rb.AddForce(tf.forward * throttleValue * timedMove);
    }
}
