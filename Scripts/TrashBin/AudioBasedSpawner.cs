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


    private float[] samples = new float[1024];
 
    // Update is called once per frame
    void Update()
    {
        AudioListener.GetSpectrumData(samples, 0, fftwindow);
        debugValue = samples[frequency];
        if (samples[frequency]> spawnThreshold)
        {
            StartCoroutine(ExecuteAfterTime(8));
        }
    }
    IEnumerator ExecuteAfterTime(float time)
    {
        GameObject objectPrefab = Instantiate(objectPrefabs[Random.Range(0,2)], points[Random.Range(0, 4)]);
        objectPrefab.transform.localPosition = Vector3.zero;
        objectPrefab.transform.Rotate(transform.forward, 90 * Random.Range(0, 4));
        yield return new WaitForSeconds(time);
    }
}

// Sourced from PushyPixels: https://www.youtube.com/watch?v=AAPqo5P3woc&ab_channel=PushyPixels
