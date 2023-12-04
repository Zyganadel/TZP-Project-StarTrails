using UnityEngine;
using UnityEngine.UI;

public class ControlsSlider : MonoBehaviour
{
    [SerializeField] string ManagerName = "PrefsManager";
    [SerializeField] int index;
    GameObject manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find(ManagerName);
        PrefsManager managerComponent = manager.GetComponent<PrefsManager>();
        Slider slider = GetComponent<Slider>();

        switch (index)
        {
            case 0:
                slider.value = managerComponent.lookSensitivity; break;
            case 1:
                slider.value = managerComponent.rollSensitivity; break;
        }

        slider.onValueChanged.AddListener(UpdateValue);
    }

    void UpdateValue(float value)
    {
        object[] sendable = { index, value };
        manager.SendMessage("UpdateValue", sendable);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
