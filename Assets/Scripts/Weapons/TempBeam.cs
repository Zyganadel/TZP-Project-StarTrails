using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempBeam : MonoBehaviour
{
    private GameObject player;
    public float beamMaxTime = 0.1f;
    private float beamActiveTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    void OnEnable()
    {
        beamActiveTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        beamActiveTime += Time.deltaTime;
        if (beamActiveTime >= beamMaxTime) { gameObject.SetActive(false); }
    }

    void FoeDestroyed(int v = 1) { player.SendMessage("FoeDestroyed", v); }
}