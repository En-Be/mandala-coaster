using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiers : MonoBehaviour
{
    public GameObject trail;

    void Start()
    {
        StartCoroutine("Trail");
    }



    IEnumerator Trail()
    {
        Instantiate(trail, transform.position, transform.rotation);
        yield return new WaitForSeconds(1);
        StartCoroutine("Trail");
    }
}
