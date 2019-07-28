using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navel : MonoBehaviour
{
    public int divisions;

    private float angleBetweenEmissions;
    private float[] emissionAngles;

    // Start is called before the first frame update
    void Start()
    {
        angleBetweenEmissions = 360.0F / divisions;
        emissionAngles = new float[divisions];
        for(int i = 0; i < divisions; i++)
        {
            emissionAngles[i] = (i) * angleBetweenEmissions;
            Debug.Log(emissionAngles[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
