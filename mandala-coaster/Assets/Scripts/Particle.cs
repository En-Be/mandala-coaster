using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public int speed;
    public int lifeInSeconds;

    void Start()
    {
        StartCoroutine("kill");
    }

    void Update()
    {
        transform.Translate(Vector3.up * (Time.deltaTime * speed));
    }

    IEnumerator kill()
    {
        yield return new WaitForSeconds(lifeInSeconds);
        Destroy(gameObject);
    }
}
