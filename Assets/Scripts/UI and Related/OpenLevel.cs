using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpenLevel : MonoBehaviour
{
    public Button b;
    public int sceneID;

    void Start()
    {
        // This is redundant, but just to be sure.
        Cursor.lockState = CursorLockMode.None;

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