using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private readonly string m_boxTag = "Box";
    private Sabers sb;
    private void OnTriggerEnter(Collider other)
    {
        var target = other.transform;
        if (other.gameObject.tag == m_boxTag)
        {
            ScoreManager.score--;
            ScoreManager.missedBox++;
            Destroy(target.gameObject);
        }
        
    }
}
