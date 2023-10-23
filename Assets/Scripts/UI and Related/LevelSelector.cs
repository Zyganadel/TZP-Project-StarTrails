using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public int state;
    Dropdown d;
    GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        d = GetComponent<Dropdown>();
        Debug.Log(d);
        d.onValueChanged.AddListener(delegate{OnValueChanged(d);});
        button = GameObject.Find("GoButton");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnValueChanged(Dropdown d)
    {
        state = d.value;
        button.SendMessage("SetScene", d.value);
    }
}
