using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject spawnable;
    public int maxSpawned = 10, spawnInterval = 150;
    private int numSpawned = 0;
    private int time;
    float MinX = -5, MinZ = -5, MaxX = 5, MaxZ = 5;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (time == spawnInterval) { spawn(); time = 0;}
        time += 1;
        countSpawned();
    }

    void spawn(){
        if (numSpawned >= maxSpawned) { return; }
        float x = Random.Range(MinX,MaxX);
        float z = Random.Range(MinZ,MaxZ);
        float y = 0.46f;
        Instantiate(spawnable, new Vector3(x,y,z), Quaternion.identity);
    }

    void countSpawned(){
        numSpawned = (GameObject.FindGameObjectsWithTag("Pickup")).Length;
    }
}
