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

}
