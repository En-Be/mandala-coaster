using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public int lengthInSeconds;
    private int count;
    private Emitter emitter;

    void Start()
    {
        emitter = GameObject.Find("Emitter").GetComponent(typeof(Emitter)) as Emitter;
        count = 0;
        StartCoroutine("Beat"); 
    }

    IEnumerator Beat()
    {
        yield return new WaitForSeconds(1);
        emitter.Emit();
        count++;
        Debug.Log(count);
        if(count < lengthInSeconds)
        {
            StartCoroutine("Beat");
        }
    }

}
