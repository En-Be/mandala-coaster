using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // Have a fixed duration

    // Timer starts emissions

    // Timer ends emissions

    public int lengthInSeconds;
    private bool running;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("countdown"); 
    }

    IEnumerator countdown()
    {
        running = true;
        yield return new WaitForSeconds(lengthInSeconds);
        running = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(running)
        {

        }
    }
}
