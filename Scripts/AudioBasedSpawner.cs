using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBasedSpawner : MonoBehaviour
{
    public GameObject [] objectPrefabs;
    public float spawnThreshold = 0.1f;
    public int frequency = 0;
    public FFTWindow fftwindow;
    public float debugValue;
    public Transform[] points;
    public bool[] CanSpawn;

    public float CoolDown = 0.5f;
    public float counter = 0f;
    public bool EnterCoolDown = false;

    public int SpawnLimit = 2;
    public int ItemsSpawned = 0;

    private float[] samples = new float[1024];


    private void Start()
    {
        CanSpawn = new bool[points.Length];
        RefreshCanSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.GetSpectrumData(samples, 0, fftwindow);
        debugValue = samples[frequency];
        //Debug.Log($"{samples[frequency]}");
        if (samples[frequency]> spawnThreshold && EnterCoolDown == false)
        {
            Debug.Log($"Passed: {samples[frequency]}");
            //StartCoroutine(ExecuteAfterTime(8));
            ExecuteAfterTime(1);
            ItemsSpawned++;
            if(ItemsSpawned >= SpawnLimit)
            {
                EnterCoolDown = true;
            }
        }
        if(EnterCoolDown == true) // solving the buggy spawning
        {
            counter += Time.deltaTime;
            if(counter>= CoolDown)
            {
                counter = 0f;
                EnterCoolDown = false;
                RefreshCanSpawn();
            }
        }
    }
     void ExecuteAfterTime(float time) //Basic delay
    {
        int toSpawn = Random.Range(0, points.Length);
        while(CanSpawn[toSpawn] == false)
        {
            toSpawn = Random.Range(0, points.Length);
        }
        GameObject objectPrefab = Instantiate(objectPrefabs[Random.Range(0,objectPrefabs.Length)], points[Random.Range(0, points.Length)].position, Quaternion.identity);
        objectPrefab.transform.Rotate(transform.forward, 90 * Random.Range(0, 4));
        CanSpawn[toSpawn] = false;
    }

    public void  RefreshCanSpawn() // makes the spawner spawn one cube at a location at a time
    {
        for (int i = 0; i < points.Length; i++)
        {
            CanSpawn[i] = true;
        }
    }
}

// Sourced from PushyPixels: https://www.youtube.com/watch?v=AAPqo5P3woc&ab_channel=PushyPixels
