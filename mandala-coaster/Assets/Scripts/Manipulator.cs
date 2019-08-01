using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manipulator : MonoBehaviour
{
    private Collector collector;
    private List<GameObject> selection;
    private List<Color> colours;

    void Start()
    {
        collector = gameObject.GetComponent(typeof(Collector)) as Collector;
        colours = new List<Color>();
        colours.Add(Color.blue);
        colours.Add(Color.red);
        colours.Add(Color.yellow);
    }

    public void Manipulate(int collection)
    {
        Debug.Log(collection);
        selectParticles(collection);
        ChangeColor(collection);
    }

    void selectParticles(int collection)
    {
        selection = new List<GameObject>();
        allParticles(collection);
    }

    void individualParticles(int collection)
    {
        foreach(GameObject particle in collector.Collections[collection])
        {
            //give them their own colour
        }
    }

    void allParticles(int collection)
    {
        // for every particle
        foreach(GameObject particle in collector.Collections[collection])
        {
            selection.Add(particle);
        }
    }

    void alternatingParticles()
    {
        // for every other particle
        // give them the same colour
    }

    void ChangeColor(int collection)
    {
        Material material = new Material(Shader.Find("Unlit/Color"));
        material.color = colours[collection];
        foreach(GameObject particle in selection)
        {
            Renderer rend = particle.GetComponent<Renderer>();
            rend.material = material;
        }
    }
}
