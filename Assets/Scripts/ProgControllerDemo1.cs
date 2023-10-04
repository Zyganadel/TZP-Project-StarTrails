using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class ProgControllerDemo1 : MonoBehaviour
{
    public TextMeshProUGUI scoreUI;
    void SetScoreText()
    {
        scoreUI.SetText($"Score: {score}");
        if (score >= 4)
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(1);
        }
    }
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        SetScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FoeDestroyed() { score += 1; SetScoreText(); }
}
