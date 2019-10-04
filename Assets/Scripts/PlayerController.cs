using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerController : NetworkBehaviour {

    public float speed;

    private Rigidbody rb;
    private Vector3 movement;
    private bool isLocal;
    private Score score;

    [HideInInspector]
    public string playerName;

    void Start ()
    {
        isLocal = GetComponent<NetworkIdentity>().isLocalPlayer;
    }

    public override void OnStartLocalPlayer()
    {
        score = GameObject.Find("ScoreKeeper").GetComponent<Score>();
        CmdRegister(playerName);

        GetComponent<MeshRenderer>().material.color = Color.blue;
        // Pass the camera a refrence to this player's transform
        Camera.main.GetComponent<CameraController>().playerTransform = transform;
        GetComponent<Roll>().enabled = true;
        
        // If the player was not rolling, this would be adequate
        // Camera.main.transform.position = transform.position - transform.forward * 10 + transform.up*3;
        // Camera.main.transform.LookAt(transform.position);
        // Camera.main.transform.parent = transform;
    }

    void OnTriggerEnter(Collider other) 
    {
        if (!isLocal){ return; }
        // Destroy collectable objects
        if (other.gameObject.CompareTag("Pickup"))
        {
            Destroy(other.gameObject);
            CmdUpdateScore(playerName);
        }
    }

        [Command]
        void CmdRegister(string name)
        {
            score.addPlayer(name);
        }

        [Command]
        void CmdUpdateScore(string name)
        {
            score.score(name);
        }
}