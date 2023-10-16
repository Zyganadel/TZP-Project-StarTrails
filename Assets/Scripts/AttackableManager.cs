using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackableManager : MonoBehaviour
{
    public int hp = 1;
    public string message;
    int dTake = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerAttack"))
        {
            if (hp - dTake <= 0) { gameObject.SetActive(false); other.SendMessage(message); }
            else { hp -= dTake; }
        }
    }
}
