using System.IO;
using UnityEngine;

public class PrefsManager : MonoBehaviour
{
    private string userPrefLoc = "userprefs.cfg";
    public float lookSensitivity = 1f;
    public float rollSensitivity = 1f;
    public bool useWrongFlightControls;

    // Start is called before the first frame update
    void Start()
    {
        UpdateControlPrefs();
    }

    void UpdateControlPrefs()
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

    // Update is called once per frame
    void UpdateValue(object[] data)
    {
        int index = (int)data[0];
        switch (data[0])
        {
            case 0:
                lookSensitivity = (float)data[1]; break;
            case 1:
                rollSensitivity = (float)data[1]; break;
            case 2:
                useWrongFlightControls = (bool)data[1]; break;
        }
        string[] write =
            {
                $"{lookSensitivity}",
                $"{rollSensitivity}",
                $"{useWrongFlightControls}"
            };
        File.WriteAllLines(userPrefLoc, write);
    }
}
