using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackableManager : MonoBehaviour
{
    public int hp = 1;
    public string message;
    int dTake = 0;
    public PlayerController pc;
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
            pc = other.GetComponentInParent<PlayerController>();
            switch (pc.weapon)
            {
                case Weapon.beam: dTake = pc.beamDamage; break;
                case Weapon.kinetic: dTake = pc.kineticDamage; break;
                case Weapon.missile: dTake = pc.missileDamage; break;
            }
            if (hp - dTake <= 0) { gameObject.SetActive(false); other.SendMessage(message); }
            else { hp -= dTake; }
        }
    }
}
