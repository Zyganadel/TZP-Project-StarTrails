using UnityEngine;

// To use this script, attach it to the GameObject that you would like to rotate towards another game object.
// After attaching it, go to the inspector and drag the GameObject you would like to rotate towards into the target field.
// Move the target around in the scene view to see the GameObject continuously rotate towards it.
public class HPRotate : MonoBehaviour
{
    // The target marker.
    GameObject player;
    public Transform ptf; //player transform
    public Transform otf; //our transform

    // Angular speed in radians per sec.
    public float speed = 100.0f;

    void Start()
    {
        player = GameObject.Find("Player");
        ptf = player.GetComponent<Transform>();
        otf = GetComponent<Transform>();
        Debug.Log(player.name);
    }

    void Update()
    {
        otf.rotation = ptf.rotation;
    }
}