using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackableManager : MonoBehaviour
{
    public int hp = 1;
    public string defeatMsg;
    public int scoreValue;
    int dTake = 0;
    public ProgControllerDemo1 prc;
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
            prc = other.GetComponentInParent<ProgControllerDemo1>();
            PlayerController pc = other.GetComponentInParent<PlayerController>();
            dTake = pc.currentDamage;
            if (hp - dTake <= 0) { gameObject.SetActive(false); other.SendMessage(defeatMsg, scoreValue); }
            else { hp -= dTake; }
        }
    }
}
