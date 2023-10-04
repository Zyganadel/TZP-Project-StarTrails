using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playerAttack;
    private int score = 0;

    //temp stuff
    public TextMeshProUGUI scoreUI;
    void SetScoreText() { scoreUI.SetText($"Score: {score}"); }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnFire()
    {
        playerAttack.SetActive(true);
    }

    void FoeDestroyed() { score += 1; SetScoreText(); }
}
