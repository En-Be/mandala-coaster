using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navel : MonoBehaviour
{
    public int divisions;
    public float speed;
    private float angleBetweenEmissions;
    private float[] emissionAngles;

    public GameObject point;

    // Start is called before the first frame update
    void Start()
    {
        SetUpAngles();
        StartCoroutine("Emit");
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

    IEnumerator Emit()
    {
        foreach(int i in emissionAngles)
        {
            Instantiate(point, transform.position, Quaternion.AngleAxis(i, Vector3.forward));
        }
        yield return new WaitForSeconds(1 / speed);
        StartCoroutine("Emit");
    }
}
