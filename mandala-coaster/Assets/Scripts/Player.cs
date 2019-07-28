using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // public Transform camera;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        // camera = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        // transform.rotation = camera.rotation;
        // Debug.Log(camera.rotation);
        transform.Translate(Vector3.forward * (Time.deltaTime * speed));
    }
}
