using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CameraController : MonoBehaviour {

    private GameObject player;
    private Vector3 offset;
    private Vector3 origCamPos;
    

    void Start ()
    {
        player = null;
        origCamPos = transform.position;
    }

    void Update(){
        UpdatePlayer();
    }

    void UpdatePlayer(){
        UnityEngine.GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length == 0){player = null; return;} 
        foreach (GameObject p in players) {
            // In the list of players, find the one that the camera should track
            if (p.GetComponent<NetworkIdentity>().isLocalPlayer){
                // Check if we need to update the camera offset from the player
                if (player == null){
                    offset = transform.position - player.transform.position;
                }
                player = p; 
                return;
            }
        }
        player = null;
        transform.position = origCamPos;
    }

    void LateUpdate ()
    {
        if (player == null){return;}
        transform.position = player.transform.position + offset;
    }
}