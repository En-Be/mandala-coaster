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
        
        findOtherComponents();

        count = 0;
        StartCoroutine("Counter"); 
    }

    void findOtherComponents()
    {
        emitter = GameObject.Find("Emitter").GetComponent(typeof(Emitter)) as Emitter;
        manipulator = gameObject.GetComponent(typeof(Manipulator)) as Manipulator;
    }

    IEnumerator Counter()
    {
        yield return new WaitForSeconds(1);
        Beat();
        count++;
        if(count < lengthInSeconds)
        {
            StartCoroutine("Counter");
        }
    }

    void Beat()
    {
        emitter.Emit();
        manipulator.Manipulate(count);
    }

}
