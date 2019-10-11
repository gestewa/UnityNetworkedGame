using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Transform))]
public class Respawn : MonoBehaviour
{
    private Vector3 startPosition;
    private Rigidbody rb;

    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    void LateUpdate()
    {
        bool respawn = transform.position.y <= startPosition.y - 15;
        if (respawn){
            transform.position = startPosition; 
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero; 
        }
    }
}
