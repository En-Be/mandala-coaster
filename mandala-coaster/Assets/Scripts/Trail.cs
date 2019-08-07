using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    private Transform tier_0_points;
    private Transform tier_1_points;
    private Transform tier_2_points;

    private Color lerpedColor = Color.black;

    void Start()
    {
        tier_0_points = gameObject.transform.GetChild(1);
        tier_1_points = gameObject.transform.GetChild(3);
        tier_2_points = gameObject.transform.GetChild(5);
        lerpedColor = Color.black;
        StartCoroutine("lerpColor");
        StartCoroutine("Kill");
    }

    IEnumerator lerpColor()
    {
        yield return new WaitForSeconds(0);
        lerpedColor = Color.Lerp(Color.grey, Color.black, Mathf.PingPong(Time.time, 1));
        tier_0_points.gameObject.GetComponent<Renderer>().material.color = lerpedColor;
        tier_1_points.gameObject.GetComponent<Renderer>().material.color = lerpedColor;
        tier_2_points.gameObject.GetComponent<Renderer>().material.color = lerpedColor;
        StartCoroutine("lerpColor");
    }

    IEnumerator Kill()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
