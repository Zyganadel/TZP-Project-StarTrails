using System;
using UnityEngine;

public class AttackableManager : MonoBehaviour
{
    public int hp = 1;
    public int maxHP = 1;
    public string defeatMsg;
    public int scoreValue;
    int dTake = 0;

    public ProgControllerDemo1 prc;
    BarManager hpBar;

    // Unbreak CheckHP
    Collider other;

    // Start is called before the first frame update
    void Start()
    {
        hpBar = GetComponentInChildren<BarManager>();
    }

    // Update is called once per frame
    void Update()
    {

        float hp2 = hp;
        float maxHP2 = maxHP;

        hpBar.hpFloat = hp2 / maxHP2;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerAttack"))
        {
            this.other = other;
            prc = other.GetComponentInParent<ProgControllerDemo1>();
            PlayerController pc = other.GetComponentInParent<PlayerController>();
            dTake = pc.currentDamage;
            CheckHP();
            hp -= dTake;
        }
    }
    public void CheckHP()
    {
        if (hp - dTake <= 0)
        {
            try { other.SendMessage(defeatMsg, scoreValue); }
            catch (NullReferenceException e) { Debug.LogError("Got a NullReferenceException!!!"); }
            gameObject.SetActive(false);
        }
    }
}
