using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public int lengthInSeconds;
    private int count;
    private Emitter emitter;
    private Manipulator manipulator;

    void Start()
    {
        if(lengthInSeconds < 3)
        {
            lengthInSeconds = 3;
        }
        emitter = GameObject.Find("Emitter").GetComponent(typeof(Emitter)) as Emitter;
        manipulator = gameObject.GetComponent(typeof(Manipulator)) as Manipulator;

        count = 0;
        StartCoroutine("Counter"); 
    }

    IEnumerator Counter()
    {
        yield return new WaitForSeconds(1);
        count++;
        Debug.Log(count);
        Beat();
        if(count < lengthInSeconds)
        {
            StartCoroutine("Counter");
        }
    }

    void Beat()
    {
        emitter.Emit();
        manipulator.Manipulate();
    }

}
