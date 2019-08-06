using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private int lengthInSeconds;
    private int elapsedSeconds;
    private int count;
    private int stage;
    private int stageLength;
    private float interval;

    private Emitter emitter;
    private Manipulator manipulator;
    private PlayerGaze playerGaze;

    void Start()
    {
        lengthInSeconds = 60;
        stageLength = 20;
        interval = 1.0F;
        findOtherComponents();
        setUpOtherComponents();
        count = 0;
        StartCoroutine("Counter");
        StartCoroutine("Beat");
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
        yield return new WaitForSeconds(1);
        elapsedSeconds++;
        if(elapsedSeconds == stageLength)
        {
            stage++;
            manipulator.stage = stage;
            interval /= 3;
            elapsedSeconds = 0;
        }
        if(stage != 4)
        {
            StartCoroutine("Counter");
        }
        else
        {
            StopCoroutine("Beat");
        }
        Debug.Log($"count: {count}");
        Debug.Log($"elapsedSeconds: {elapsedSeconds}");
        Debug.Log($"stage: {stage}");
    }

    IEnumerator Beat()
    {
        yield return new WaitForSeconds(interval);
        emitter.Emit(playerGaze.currentTier);
        manipulator.Manipulate(count);
        count++;
        StartCoroutine("Beat");
    }

}
