using System;
using UnityEngine;

public class AttackableManager : MonoBehaviour
{

    public int hp = 1;
    public int maxHP = 1;
    public string defeatMsg;
    public int scoreValue;
    int dTake = 0;

    PlayerController pc;
    public ProgControllerDemo1 prc;
    BarManager hpBar;

    // Unbreak CheckHP
    Collider other;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb;
        rb = GetComponent<Rigidbody>();
        if (rb == null) { rb = gameObject.AddComponent<Rigidbody>(); }
        rb.useGravity = false;
        rb.isKinematic = true;
        try { hpBar = GetComponentInChildren<BarManager>(); }
        catch { }
    }

    // Update is called once per frame
    void Update()
    {

        if(hpBar != null)
        {
            float hp2 = hp;
            float maxHP2 = maxHP;

            hpBar.hpFloat = hp2 / maxHP2;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerAttack"))
        {
            this.other = other;
            prc = other.GetComponentInParent<ProgControllerDemo1>();
            pc = other.GetComponentInParent<PlayerController>();
            if (pc == null )
            {
                kineticWeapon kw = other.GetComponent<kineticWeapon>();
                pc = kw.origin;
            }
            dTake = pc.currentDamage;
            CheckHP();
            hp -= dTake;
        }
    }
    public void CheckHP()
    {
        if (hp - dTake <= 0)
        {
            try { pc.gameObject.SendMessage(defeatMsg, scoreValue); }
            catch (NullReferenceException e) { Debug.LogError("Got a NullReferenceException!!!"); }
            gameObject.SetActive(false);
        }
    }
}
