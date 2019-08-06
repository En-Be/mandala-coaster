using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public int lengthInSeconds;
    private int count;
    private Emitter emitter;
    private Manipulator manipulator;
    private PlayerGaze playerGaze;

    void Start()
    {
        if(lengthInSeconds < 3)
        {
            lengthInSeconds = 3;
        }
        
        findOtherComponents();
        setUpOtherComponents();

        count = 0;
        StartCoroutine("Counter"); 
    }

    void findOtherComponents()
    {
        emitter = GameObject.Find("Emitter").GetComponent(typeof(Emitter)) as Emitter;
        playerGaze = GameObject.Find("Main Camera").GetComponent(typeof(PlayerGaze)) as PlayerGaze;
        manipulator = gameObject.GetComponent(typeof(Manipulator)) as Manipulator;
    }

    void setUpOtherComponents()
    {
        manipulator.setLengthInSeconds(lengthInSeconds);
    }

    IEnumerator Counter()
    {
        yield return new WaitForSeconds(0.1F);
        Beat();
        count++;
        if(count < lengthInSeconds)
        {
            StartCoroutine("Counter");
        }
    }

    void Beat()
    {
        emitter.Emit(playerGaze.currentTier);
        manipulator.Manipulate(count);
    }

}
