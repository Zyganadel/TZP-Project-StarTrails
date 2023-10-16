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
    public int missileDamage = 2;
    // add missile later.

    public GameObject currentWeapon;
    public Weapon weapon;

    private int score = 0;

    //temp stuff


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
                break;
            case Weapon.kinetic:
                weapon = Weapon.missile;
                currentWeapon = missileWeapon;
                break; //this will need to be replaced with missile eventually.
            case Weapon.missile:
                weapon = Weapon.beam;
                currentWeapon = beamWeapon;
                break;
        }
    }

    void OnFire()
    {
        currentWeapon.SetActive(true);
        if (weapon == Weapon.kinetic) { kineticWeapon.SendMessage("Fire"); }
    }

}
