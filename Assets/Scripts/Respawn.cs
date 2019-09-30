using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private Vector3 startPosition;
    private int respawnCount;
    private Rigidbody rb;

    private bool respawn;

    void Start()
    {
        startPosition = transform.position;
        respawn = false;
        respawnCount = 0;
        rb = GetComponent<Rigidbody>();
    }

    void LateUpdate()
    {
        respawn = transform.position.y != startPosition.y;
        if (respawn) { 
            respawnCount += 1; 
            if (respawnCount > 100) { 
                transform.position = startPosition; 
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero; 
            }
        }
        else {respawnCount = 0;}
        
    }
}
