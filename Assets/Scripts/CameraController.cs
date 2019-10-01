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
        if (players.Length == 0){return;} 
        foreach (GameObject p in players) {
             if (p.GetComponent<NetworkIdentity>().isLocalPlayer){
                 if (player == null){
                    player = p;
                    offset = transform.position - player.transform.position;
                 }
                 else {
                    player = p;
                 }
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