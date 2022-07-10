using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Sabers : MonoBehaviour
{
    public LayerMask layer;  // select color via layer
    private Vector3 previousPos;
    public string level;
    public AudioSource _break;

    private void Start()
    {
        _break = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit; // hitting the box at around 135 degree margin for direction input with raycast
        if(Physics.Raycast(transform.position,transform.forward,out hit,1,layer))
        {
            if(Vector3.Angle(transform.position-previousPos,hit.transform.up)>130)
            {
                _break.Play();
                ScoreManager.score++;              
                Destroy(hit.transform.gameObject, 1.5f); // add score and destroy the cube for FPS!
            }
        }
        previousPos = transform.position;
        
        if(ScoreManager.missedBox > 4)
        {
            SceneManager.LoadScene(level);  // on 5 misses, death screen
        }    
    }
}
