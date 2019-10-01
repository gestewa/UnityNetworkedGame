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

    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.blue;
        // Pass the camera a refrence to this player's transform
        Camera.main.GetComponent<CameraController>().playerTransform = transform;
        
        // If the player was not rolling, this would be adequate
        // Camera.main.transform.position = transform.position - transform.forward * 10 + transform.up*3;
        // Camera.main.transform.LookAt(transform.position);
        // Camera.main.transform.parent = transform;
    }

    void FixedUpdate ()
    {
        if (!isLocal){ return; }
        float moveHorizontal = Input.GetAxis ("right");
        float moveVertical = Input.GetAxis ("up");

        movement.x = moveHorizontal;
        movement.z = moveVertical;

        rb.AddForce (movement * speed);
    }

    void OnTriggerEnter(Collider other) 
    {
        // Destroy collectable objects
        if (other.gameObject.CompareTag("Pickup"))
        {
            Destroy(other.gameObject);
        }
    }

    public void setID(int ID){
        id = ID;
    }
}