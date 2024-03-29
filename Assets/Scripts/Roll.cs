using UnityEngine;

public class Roll : MonoBehaviour {

    public float speed = 5;

    private Rigidbody rb;
    private Vector3 movement;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        movement = new Vector3(0.0f, 0.0f, 0.0f);
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("right");
        float moveVertical = Input.GetAxis ("up");

        movement.x = moveHorizontal;
        movement.z = moveVertical;

        rb.AddForce (movement * speed);
    }
}