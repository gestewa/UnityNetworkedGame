using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public GameObject spawnable;
    public int maxCount = 10;
    private int count = 0;
    private int time;
    float MinX = -5;
    float MinZ = -5;
    float MaxX = 5;
    float MaxZ = 5;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        spawn();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (time == 50) { spawn(); time = 0;}
        time += 1;
        updateCount();
    }

    void spawn(){
        if (count >= maxCount) return;
        Debug.Log(count);
        float x = Random.Range(MinX,MaxX);
        float z = Random.Range(MinZ,MaxZ);
        float y = 0.46f;
        GameObject spawned = Instantiate(spawnable, new Vector3(x,y,z), Quaternion.identity);
    }

    void updateCount(){
        count = (GameObject.FindGameObjectsWithTag("Pickup")).Length;
    }
}
