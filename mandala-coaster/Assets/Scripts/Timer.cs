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
    private GameObject ring;
    private Collector collector;
    private Tiers tiers;


    void Start()
    {
        findOtherComponents();
        setUpOtherComponents();
        InitializeValues();

    }

    public void BeginNewMandala()
    {
        playing = true;
        StartCoroutine("Counter");
        StartCoroutine("Beat");
        tiers.Appear();
    }

    void findOtherComponents()
    {
        collector = gameObject.GetComponent(typeof(Collector)) as Collector;
        emitter = GameObject.Find("Emitter").GetComponent(typeof(Emitter)) as Emitter;
        playerGaze = GameObject.Find("Main Camera").GetComponent(typeof(PlayerGaze)) as PlayerGaze;
        manipulator = gameObject.GetComponent(typeof(Manipulator)) as Manipulator;
        reticule = GameObject.Find("Reticule");
        ring = GameObject.Find("ring");
        tiers = GameObject.Find("tiers").GetComponent(typeof(Tiers)) as Tiers;
    }

    void setUpOtherComponents()
    {
        manipulator.setLengthInSeconds(lengthInSeconds);
    }

    IEnumerator Counter()
    {
        yield return new WaitForSeconds(1);
        elapsedSeconds++;
        ChangeStage();
        if(stage != 4)
        {
            StartCoroutine("Counter");
        }
        else
        {
            Reset();
        }
    }

    void ChangeStage()
    {
        if(elapsedSeconds == stageLength)
        {
            stage++;
            manipulator.stage = stage;
            interval /= 3;
            elapsedSeconds = 0;
        }
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
        InitializeValues();
        StopCoroutine("Beat");
        collector.ResetCollection();
        tiers.Disappear();
        reticule.gameObject.SetActive(true);
        ring.gameObject.SetActive(true);
    }

    void InitializeValues()
    {
        playing = false;
        lengthInSeconds = 32;
        stageLength = 8;
        count = 0;
        interval = 1.0F;
        elapsedSeconds = 0;
        stage = 0;
        manipulator.stage = 0;

    }
}
