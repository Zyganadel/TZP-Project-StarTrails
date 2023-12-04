using UnityEngine;
using UnityEngine.UI;

public class ToggleScript : MonoBehaviour
{
    [SerializeField] string ManagerName;
    [SerializeField] int index = 2;

    // Start is called before the first frame update
    void Start()
    {
        Toggle t = GetComponent<Toggle>();
        t.onValueChanged.AddListener(UpdateValue);
    }

    void UpdateValue(bool newValue)
    {
        GameObject manager = GameObject.Find( ManagerName );
        object[] sendable = {index, newValue};
        manager.SendMessage("UpdateValue", sendable);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
