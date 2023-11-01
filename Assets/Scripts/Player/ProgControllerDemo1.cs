using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgControllerDemo1 : MonoBehaviour
{
    public int reqScore = 10;
    public TextMeshProUGUI scoreUI;
    PlayerController playerController;
    void SetScoreText()
    {
        scoreUI.SetText($"Score: {score}");
        if (score >= reqScore)
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(2);
        }
    }
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        SetScoreText();
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.hp < 1)
        {

            SceneManager.LoadScene(3);
        }
    }

    void FoeDestroyed(int value = 1) { score += value; SetScoreText(); }
}
