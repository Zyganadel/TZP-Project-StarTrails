using UnityEngine;
using UnityEngine.UI;

public class ToggleScript : MonoBehaviour
{
    [SerializeField] string ManagerName;
    [SerializeField] int index = 2;
    GameObject manager;
    PrefsManager prefsManager;
    bool doneLoading = false;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find(ManagerName);
        prefsManager = manager.GetComponent<PrefsManager>();
        AttemptLoading();
    }

    void UpdateValue(bool newValue)
    {
        GameObject manager = GameObject.Find( ManagerName );
        object[] sendable = {index, newValue};
        manager.SendMessage("UpdateValue", sendable);
    }

    void AttemptLoading()
    {
        if (prefsManager.doneLoading)
        {
            Toggle t = GetComponent<Toggle>();
            t.isOn = prefsManager.useWrongFlightControls;
            t.onValueChanged.AddListener(UpdateValue);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!doneLoading) { AttemptLoading(); }
    }
}
