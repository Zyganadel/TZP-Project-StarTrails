using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kineticWeapon : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    private bool isClone = false;

    // Start is called before the first frame update
    void OnAwake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed;
    }

    void Fire()
    {
        GameObject clone = Instantiate(this.gameObject); // used this.gameObject for readability
        kineticWeapon cloneComponent = clone.GetComponent<kineticWeapon>();
        cloneComponent.isClone = true;
    }
}
