using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour
{
    public int divisions;
    public float interval;

    public bool rotates;

    private Transform player;
    private float angleBetweenEmissions;
    private float[] emissionAngles;

    public GameObject particle;
    public GameObject point;

    // Start is called before the first frame update
    void Start()
    {
        SetUpAngles();
        StartCoroutine("Emit");
        // player = GameObject.
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetUpAngles()
    {
        angleBetweenEmissions = 360.0F / divisions;
        emissionAngles = new float[divisions];
        for(int i = 0; i < divisions; i++)
        {
            emissionAngles[i] = (i) * angleBetweenEmissions;
            // Debug.Log(emissionAngles[i]);
        }
    }

    void rotateAngles()
    {
        for(int i = 0; i < divisions; i++)
        {
            emissionAngles[i] -= angleBetweenEmissions / 4;
        }
    }

    IEnumerator Emit()
    {
        if(rotates)
        {
            rotateAngles();
        }
        foreach(int i in emissionAngles)
        {
            GameObject newParticle = Instantiate(particle, transform.position, transform.rotation);
            Debug.Log(newParticle.transform.rotation);
            newParticle.transform.Rotate(0, 0, i, Space.Self);
            Instantiate(point, transform.position, transform.rotation);
        }
        yield return new WaitForSeconds(interval);
        StartCoroutine("Emit");
    }
}
