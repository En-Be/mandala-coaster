using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public bool playing;
    
    private int lengthInSeconds;
    private int elapsedSeconds;
    private int count;
    private int stage;
    private int stageLength;
    private float interval;

    private Emitter emitter;
    private Manipulator manipulator;
    private PlayerGaze playerGaze;
    private GameObject reticule;
    private Collector collector;


    void Start()
    {
        playing = false;
        lengthInSeconds = 12;
        stageLength = 3;
        findOtherComponents();
        setUpOtherComponents();
        count = 0;
        interval = 1.0F;
        elapsedSeconds = 0;
    }

    public void BeginNewMandala()
    {
        playing = true;
        StartCoroutine("Counter");
        StartCoroutine("Beat");
    }

    void findOtherComponents()
    {
        collector = gameObject.GetComponent(typeof(Collector)) as Collector;
        emitter = GameObject.Find("Emitter").GetComponent(typeof(Emitter)) as Emitter;
        playerGaze = GameObject.Find("Main Camera").GetComponent(typeof(PlayerGaze)) as PlayerGaze;
        manipulator = gameObject.GetComponent(typeof(Manipulator)) as Manipulator;
        reticule = GameObject.Find("Reticule");
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
            Reset();
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

    void Reset()
    {
        StopCoroutine("Beat");
        playing = false;
        count = 0;
        interval = 1.0F;
        elapsedSeconds = 0;
        stage = 0;
        collector.ResetCollection();
        manipulator.stage = 0;
        reticule.gameObject.SetActive(true);
    }
}
