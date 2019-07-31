﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour
{
    public int divisions;
    public float interval;
    public bool rotates;
    public GameObject particle;

    private float angleBetweenEmissions;
    private float[] emissionAngles;
    public Collector collector;


    void Start()
    {
        collector = GameObject.Find("Player").GetComponent(typeof(Collector)) as Collector;
        SetUpAngles();
    }

    void SetUpAngles()
    {
        angleBetweenEmissions = 360.0F / divisions;
        emissionAngles = new float[divisions];
        for(int i = 0; i < divisions; i++)
        {
            emissionAngles[i] = (i) * angleBetweenEmissions;
        }
    }

    void rotateAngles()
    {
        for(int i = 0; i < divisions; i++)
        {
            emissionAngles[i] -= angleBetweenEmissions / (divisions / 2);
        }
    }

    public void Emit()
    {
        List<GameObject> collection = new List<GameObject>();

        foreach(int i in emissionAngles)
        {
            GameObject newParticle = Instantiate(particle, transform.position, transform.rotation);
            newParticle.transform.Rotate(0, 0, i, Space.Self);
            collection.Add(newParticle);
        }
        
        collector.AddCollection(collection);

        if(rotates)
        {
            rotateAngles();
        }
    }
}
