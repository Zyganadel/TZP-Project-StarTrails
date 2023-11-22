using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class missileWeapon : MonoBehaviour
{
    public PlayerController origin;
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float lookSpeed = 5f;
    private bool isClone = false;
    [SerializeField] private float timer = 5.0f;

    [SerializeField] private Transform target;

    // Start is called before the first frame update
    void OnAwake()
    {
        // very sloppy raycast stuff for missile targeting.
        Ray ray = new Ray();
        ray.direction = transform.forward;
        RaycastHit hit;
        Physics.Raycast(ray, out hit); // to my knowledge, this raycasts in ray's direction, from ray's origin, returning the first thing it hits.
        target = hit.transform;
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

        Vector3 targetDirection = target.position - transform.position;

        // The step size is equal to speed times frame time.
        float singleStep = lookSpeed * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);
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
