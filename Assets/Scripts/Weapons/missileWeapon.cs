using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class missileWeapon : MonoBehaviour
{
    public PlayerController origin;
    [SerializeField] private float speed = 1.0f;
    private bool isClone = false;
    [SerializeField] private float timer = 5.0f;

    // Start is called before the first frame update
    void OnAwake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isClone)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
            timer -= Time.deltaTime;
            if (timer <= 0) { GameObject.Destroy(gameObject); }
        }
    }

    void Fire()
    {
        Transform ptf = GetComponentInParent<Transform>();
        GameObject clone = Instantiate(this.gameObject); // used this.gameObject for readability
        Transform clonetf = clone.GetComponent<Transform>();
        clonetf.position = ptf.position;
        clonetf.rotation = ptf.rotation;
        missileWeapon clonemw = clone.GetComponent<missileWeapon>();
        clonemw.isClone = true;
        clonemw.origin = GetComponentInParent<PlayerController>();
        gameObject.SetActive(false);
    }
}
