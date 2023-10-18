using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum Weapon
{
    beam,
    kinetic,
    missile
}

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject beamWeapon;
    public int beamDamage = 2;
    public GameObject kineticWeapon;
    public int kineticDamage = 2;
    public GameObject missileWeapon;
    public int missileDamage = 4;
    // add missile later.

    public GameObject currentWeapon;
    public int currentDamage;
    public Weapon weapon;

    private int score = 0;

    public int sp = 10; //shield
    public int hp = 10; //health


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnChangeWeapon() // eventually use a value to determine whether to go up or down a list of weapons.
    {
        currentWeapon.SetActive(false); // this is to prevent player from permanently activating their weapons by switching them.
        switch (weapon)
        {
            case Weapon.beam:
                weapon = Weapon.kinetic;
                currentWeapon = kineticWeapon;
                currentDamage = kineticDamage;
                break;
            case Weapon.kinetic:
                weapon = Weapon.missile;
                currentWeapon = missileWeapon;
                currentDamage = missileDamage;
                break;
            case Weapon.missile:
                weapon = Weapon.beam;
                currentWeapon = beamWeapon;
                currentDamage = beamDamage;
                break;
        }
    }

    void OnFire()
    {
        currentWeapon.SetActive(true);
        if (weapon == Weapon.kinetic) { kineticWeapon.SendMessage("Fire"); }
    }

    void OnCollisionEnter(Collision collider)
    {
        string cTag = collider.gameObject.tag;
        switch (cTag)
        {
            case "Asteroid":
                TakeKineticDamage(1);
                break;
            case "Ship":
                TakeKineticDamage(1);
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FoeAttack")
        {
            AttackerManager am = other.gameObject.GetComponent<AttackerManager>();
            TakeBeamDamage(am.beamDamage);
        }
    }

    void TakeKineticDamage(int damage)
    {

        if (sp > 0) { sp -= damage; }
        else { hp -= 2 * damage; }
    }

    void TakeBeamDamage(int damage)
    {
        if (sp > 0) { sp -= damage * 2; }
        else { hp -= damage; }
    }
}
