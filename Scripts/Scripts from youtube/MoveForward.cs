using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public int speed;
    public Sabers sb;
    // Start is called before the first frame update
    void Start()
    {
        sb = GetComponent<Sabers>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= Time.deltaTime * transform.forward * speed;
        StartCoroutine(ExecuteAfterTime(10));
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        ScoreManager.score--;
        ScoreManager.missedBox++;
        Destroy(this.gameObject);  // manages score, miss count and destroys object
        
    }
}
