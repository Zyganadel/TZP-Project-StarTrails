using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class OpenLevel : MonoBehaviour
{
    public Dropdown d1;
    public Button b;
    public int sceneID;

    void Start()
    {
        Button btn = b.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
        Dropdown d2 = d1.GetComponent<Dropdown>();
        d2.onValueChanged.AddListener(delegate { OnValueChanged(d2); });
    }

    void OnClick()
    {
        SceneManager.LoadScene(sceneID);
    }
    void OnValueChanged(Dropdown change)
    {
        sceneID = change.value;
        Debug.Log(change.value);
    }
}