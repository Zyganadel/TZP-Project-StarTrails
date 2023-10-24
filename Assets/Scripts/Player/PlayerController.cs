using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum Weapon
{
    beam,
    kinetic,
    missile
}

public class PlayerController : MonoBehaviour
{
    //HUD EHP stuff
    RectTransform HUDhpbar;
    RectTransform HUDspbar;

    //weapons
    public GameObject beamWeapon;
    public int beamDamage = 2;
    public GameObject kineticWeapon;
    public int kineticDamage = 2;
    public GameObject missileWeapon;
    public int missileDamage = 4;
    //current weapons stuff
    public GameObject currentWeapon;
    public int currentDamage = 2;
    public Weapon weapon;

    private int score = 0;

    public int isp = 10; //initial value shield
    public int ihp = 10; //initial value health
    public int sp = 10; //shield
    public int hp = 10; //health


    void Start()
    {
        GameObject thpbar = GameObject.Find("HUDHP");
        GameObject tspbar = GameObject.Find("HUDSP");
        HUDhpbar = thpbar.GetComponent<RectTransform>();
        HUDspbar = tspbar.GetComponent<RectTransform>();
        sp = isp; hp = sp;
        UpdateGUI();
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
            
            TakeBeamDamage(1);
        }
    }

    void UpdateGUI()
    {
        // Foe HP Bar workaround
        float thp = hp;
        float tsp = sp;
        float tihp = ihp;
        float tisp = isp;

        // Set the x value of vector3s to the decimal value of hp/sp
        Vector3 hpv3 = HUDhpbar.localScale;
        Vector3 spv3 = HUDspbar.localScale;
        hpv3.x = thp / tihp;
        spv3.x = tsp / tisp;
        if (hp < 0) { hpv3.x = 0; }
        if (sp < 0) { spv3.x = 0; }

        // Set scale
        HUDhpbar.localScale = hpv3;
        HUDspbar.localScale = spv3;
    }

    void TakeKineticDamage(int damage)
    {
        if (sp > 0) { sp -= damage; }
        else { hp -= 2 * damage; }

        UpdateGUI();
    }

    void TakeBeamDamage(int damage)
    {
        if (sp > 0) { sp -= damage * 2; }
        else { hp -= damage; }

        UpdateGUI();
    }
}
