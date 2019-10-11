using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

[RequireComponent(typeof(NetworkIdentity))]
[RequireComponent(typeof(NetworkTransform))]
[RequireComponent(typeof(Respawn))]
[RequireComponent(typeof(Roll))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Transform))]
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

        CmdRegister();

        GetComponent<MeshRenderer>().material.color = Color.blue;
        // Pass the camera a refrence to this player's transform
        Camera.main.GetComponent<CameraController>().playerTransform = transform;
        GetComponent<Roll>().enabled = true;
        
        // If the player was not rolling, this would be adequate
        // Camera.main.transform.position = transform.position - transform.forward * 10 + transform.up*3;
        // Camera.main.transform.LookAt(transform.position);
        // Camera.main.transform.parent = transform;
    }

    public void OnDestroy(){
        Debug.Log("Player: "+playerName+" exited");
        // CmdDelete();
    }

    void OnTriggerEnter(Collider other) 
    {
        if (!isLocal){ return; }
        // Destroy collectable objects
        if (other.gameObject.CompareTag("Pickup"))
        {
            Destroy(other.gameObject);
            CmdUpdateScore();
        }
    }

    [Command]
    void CmdRegister()
    {
        score.addPlayer(playerName);
    }

    [Command]
    void CmdUpdateScore()
    {
        score.score(playerName);
    }

    [Command]
    void CmdDelete()
    {
        score.deletePlayer(playerName);
    }
}