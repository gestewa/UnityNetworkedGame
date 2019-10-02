using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerController : NetworkBehaviour {

    public float speed;
    public int id;

    private Rigidbody rb;
    private Vector3 movement;
    private bool isLocal;

    void Start ()
    {
        isLocal = GetComponent<NetworkIdentity>().isLocalPlayer;
        rb = GetComponent<Rigidbody>();
        movement = new Vector3(0.0f, 0.0f, 0.0f);
    }

    void FixedUpdate ()
    {
        if (!isLocal){return;}
        float moveHorizontal = Input.GetAxis ("right");
        float moveVertical = Input.GetAxis ("up");

        movement.x = moveHorizontal;
        movement.z = moveVertical;

        rb.AddForce (movement * speed);
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            Destroy(other.gameObject);
        }
    }

    public void setID(int ID){
        id = ID;
    }
}