using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    public string level;  // enter level name  (Case sensetive)
    [SerializeField]
    public int timeInSeconds;

    private void Awake()
    {
        StartCoroutine(ExecuteAfterTime(timeInSeconds)); // starts countdown
    }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time); // waits for the amount of seconds
        SceneManager.LoadScene(level);  // switches to new level
    }
}
