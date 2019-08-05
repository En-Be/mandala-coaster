using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public float speed;
    public float direction;
    public int lifeInSeconds;

    void Start()
    {
        StartCoroutine("kill");
    }

    void Update()
    {
        transform.Rotate(0, 0, direction, Space.Self);
        transform.Translate(Vector3.up * (Time.deltaTime * speed));
    }

    IEnumerator kill()
    {
        yield return new WaitForSeconds(lifeInSeconds);
        Destroy(gameObject);
    }
}
