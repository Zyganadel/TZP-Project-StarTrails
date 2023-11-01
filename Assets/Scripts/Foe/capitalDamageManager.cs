using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class capitalDamageManager : MonoBehaviour
{
    // Get the important components of the ship, so we can deduct health when they are gone.
    AttackableManager localAM;
    AttackableManager[] critComponentAMs;
    GameObject[] critComponentObjects;
    bool[] ccCheck;

    // Start is called before the first frame update
    void Start()
    {
        // set our AMs
        localAM = GetComponent<AttackableManager>();
        critComponentAMs = GetComponentsInChildren<AttackableManager>();

        // Set a reminder that our CCs should exist until we're told otherwise, and get GameObjects for the CCs.
        ccCheck = new bool[critComponentAMs.Length];
        critComponentObjects = new GameObject[critComponentAMs.Length];
        for (int i = 0; i < critComponentAMs.Length; i++)
        {
            ccCheck[i] = true;
            critComponentObjects[i] = critComponentAMs[i].gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Do this here because I coded TempBeam really terribly.
        for (int i = 0;i < critComponentAMs.Length;i++)
        {
            // Only do things if we don't know that the component was destroyed yet.
            if (ccCheck[i])
            {
                // Only take damage if the component was obliterated.
                if (!critComponentObjects[i].activeSelf)
                {
                    Debug.Log("Module destroyed! Attempting to deal damage to the capital!");
                    localAM.hp -= critComponentAMs[i].scoreValue;
                    ccCheck[i] = false;
                }
            }
        }
    }
}
