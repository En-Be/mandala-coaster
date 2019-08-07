using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiers : MonoBehaviour
{
    public GameObject trail;
    private Transform tier_0_points;
    private Transform tier_1_points;
    private Transform tier_2_points;
    private Color lerpedColor = Color.black;

    void Start()
    {
        tier_0_points = gameObject.transform.GetChild(1);
        tier_1_points = gameObject.transform.GetChild(3);
        tier_2_points = gameObject.transform.GetChild(5);
    }

    public void Appear()
    {
        StartCoroutine("Trail");
        tier_0_points.gameObject.SetActive(true);
        tier_1_points.gameObject.SetActive(true);
        tier_2_points.gameObject.SetActive(true);
        lerpedColor = Color.black;
        StartCoroutine("lerpColor");
    }

    public void Disappear()
    {
        StopCoroutine("Trail");
        tier_0_points.gameObject.SetActive(false);
        tier_1_points.gameObject.SetActive(false);
        tier_2_points.gameObject.SetActive(false);
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
        tier_0_points.gameObject.GetComponent<Renderer>().material.color = lerpedColor;
        tier_1_points.gameObject.GetComponent<Renderer>().material.color = lerpedColor;
        tier_2_points.gameObject.GetComponent<Renderer>().material.color = lerpedColor;
        StartCoroutine("lerpColor");
    }
}
