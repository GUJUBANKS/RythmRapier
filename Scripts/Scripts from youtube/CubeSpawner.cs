using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    
    public GameObject [] cubes;  // multiple cubes and spawn points
    public Transform [] points;
    public float beat = (60/130)*2;
    private float timer;
    // Update is called once per frame
    void Update()
    {
        if (timer>beat) // spawns after beat
        {
            GameObject cube = Instantiate(cubes[Random.Range(0, 2)], points[Random.Range(0, 4)]);
            // for different direction cubes
            cube.transform.localPosition = Vector3.zero;
            cube.transform.Rotate(transform.forward, 90 * Random.Range(0, 4));
            timer -= beat;
        }

        timer += Time.deltaTime; // resets timer
    }
}
