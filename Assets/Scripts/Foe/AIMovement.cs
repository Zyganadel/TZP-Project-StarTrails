using UnityEngine;

// To use this script, attach it to the GameObject that you would like to rotate towards another game object.
// After attaching it, go to the inspector and drag the GameObject you would like to rotate towards into the target field.
// Move the target around in the scene view to see the GameObject continuously rotate towards it.
public class AIMovement : MonoBehaviour
{
    // The target marker.
    public Transform target;
    public Rigidbody rb;

    // Angular speed in radians per sec.
    [SerializeField] float speed = 1.0f;
    [SerializeField] float moveSpeed = 0.1f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Determine which direction to rotate towards
        Vector3 targetDirection = target.position - transform.position;

        // The step size is equal to speed times frame time.
        float singleStep = speed * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        // Draw a ray pointing at our target in
        Debug.DrawRay(transform.position, newDirection, Color.red);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);

        // Move the object
        rb.AddForce(transform.forward * moveSpeed);
    }
}