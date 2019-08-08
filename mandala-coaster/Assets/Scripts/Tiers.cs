using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiers : MonoBehaviour
{
    public GameObject trail;
    private List<Transform> tier_points = new List<Transform>();

    private Color lerpedColor = Color.black;

    void Start()
    {
        tier_points.Add(gameObject.transform.GetChild(1));
        tier_points.Add(gameObject.transform.GetChild(3));
        tier_points.Add(gameObject.transform.GetChild(5));
    }

    public void Appear()
    {
        StartCoroutine("Trail");
        foreach(Transform tier in tier_points)
        {
            tier.gameObject.SetActive(true);
        }
        lerpedColor = Color.black;
        StartCoroutine("lerpColor");
    }

    public void Disappear()
    {
        StopCoroutine("Trail");
        foreach(Transform tier in tier_points)
        {
            tier.gameObject.SetActive(false);
        }
        StopCoroutine("lerpColor");
    }

    IEnumerator Trail()
    {
        Instantiate(trail, transform.position, transform.rotation);
        yield return new WaitForSeconds(1);
        StartCoroutine("Trail");
    }

    IEnumerator lerpColor()
    {
        yield return new WaitForSeconds(0);
        lerpedColor = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time, 1));
        foreach(Transform tier in tier_points)
        {
            tier.gameObject.GetComponent<Renderer>().material.color = lerpedColor;
        }
        StartCoroutine("lerpColor");
    }
}
