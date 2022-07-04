using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saber : MonoBehaviour
{
    private readonly string m_boxTag = "Box";
    private Box cube;

    private void OnTriggerEnter(Collider other)
    {
        cube = this.GetComponent<Box>();
        var target = other.transform;
        if (other.gameObject.name == "Top Direction" && other.gameObject.tag == m_boxTag)
        {       
            if (cube.isBlue == true)
            {
                ScoreManager.score++;
            }         
        }

        if (other.gameObject.name == "Left Direction" && other.gameObject.tag == m_boxTag)
        {
            if (cube.isBlue == true)
            {
                ScoreManager.score++;
            }
        }
        if (other.gameObject.name == "Right Direction" && other.gameObject.tag == m_boxTag)
        {
            if (cube.isBlue == true)
            {
                ScoreManager.score++;
            }
        }
        if (other.gameObject.name == "Bottom Direction" && other.gameObject.tag == m_boxTag)
        {
            if (cube.isBlue == true)
            {
                ScoreManager.score++;
            }
        }

        Destroy(target.parent.gameObject);
    }
}
