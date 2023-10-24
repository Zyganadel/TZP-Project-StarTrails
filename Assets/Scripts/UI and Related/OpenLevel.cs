using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class OpenLevel : MonoBehaviour
{
    public Button b;
    public int sceneID;

    void Start()
    {
        Button btn = b.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        SceneManager.LoadScene(sceneID);
    }
    
    void SetScene(int n)
    {
        sceneID = n;
        Debug.Log(n);
    }
}