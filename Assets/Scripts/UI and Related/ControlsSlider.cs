using UnityEngine;
using UnityEngine.UI;

public class ControlsSlider : MonoBehaviour
{
    [SerializeField] string ManagerName = "PrefsManager";
    [SerializeField] int index;
    GameObject manager;
    bool doneLoading;
    Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();

        AttemptLoading();

        //slider.onValueChanged.AddListener(UpdateValue);
    }

    void AttemptLoading()
    {
        manager = GameObject.Find(ManagerName);
        PrefsManager managerComponent = manager.GetComponent<PrefsManager>();

        if (managerComponent.doneLoading)
        {
            switch (index)
            {
                case 0:
                    slider.value = managerComponent.lookSensitivity; break;
                case 1:
                    slider.value = managerComponent.rollSensitivity; break;
            }
            doneLoading = true;

            slider.onValueChanged.AddListener(UpdateValue);
        }
    }

    void UpdateValue(float value)
    {
        object[] sendable = { index, value };
        manager.SendMessage("UpdateValue", sendable);
    }

    // Update is called once per frame
    void Update()
    {
        if (!doneLoading) { AttemptLoading(); }
    }
}
