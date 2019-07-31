using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manipulator : MonoBehaviour
{
    private Collector collector;

    void Start()
    {
        collector = gameObject.GetComponent(typeof(Collector)) as Collector;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Manipulate()
    {

    }
}
