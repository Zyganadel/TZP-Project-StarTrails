using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerManager : MonoBehaviour
{
    public GameObject beam;
    public int beamDamage;
    public float beamCD = 2;
    private float beamTimer = 0;
    private AIMovement trackTarget;
    private Transform tfMine;
    private Transform tfTarget;
    private GameObject target;

    // temporarily set the target to always be the player
    public GameObject player;
    

    // Start is called before the first frame update
    void Start()
    {
        trackTarget = GetComponent<AIMovement>();
        tfMine = GetComponent<Transform>();

        // temporarily set the target to always be the player
        target = player;

    }

    // Update is called once per frame
    void Update()
    {
        trackTarget.target = tfTarget;
        tfTarget = target.GetComponent<Transform>();
        float dist = Vector3.Distance(tfTarget.position, tfMine.position);
        if (dist <= 8 && beamTimer > beamCD)
        {
            beam.SetActive(true);
            beamTimer = 0;
        }
        beamTimer += Time.deltaTime;
    }
}
