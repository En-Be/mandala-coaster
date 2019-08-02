using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manipulator : MonoBehaviour
{
    private Collector collector;
    private List<Color> colours;
    private int count;
    private int lengthInSeconds;

    void Start()
    {
        collector = gameObject.GetComponent(typeof(Collector)) as Collector;
        colours = new List<Color>();
        colours.Add(Color.blue);
        colours.Add(Color.red);
        colours.Add(Color.yellow);
        count = lengthInSeconds;
    }

    public void setLengthInSeconds(int length)
    {
        lengthInSeconds = length;
    }

    public void Manipulate(int collection)
    {
        selectParticles(collection);
    }

    void selectParticles(int collection)
    {
        int c = lengthInSeconds - count;
        count--;

        switch(c)
        {
            case 0:
                allParticles(collection);
                break;
            case 1:
                alternatingParticles(collection);
                break;
            case 2:
                individualParticles(collection);
                count += 3;
                break;
        }
    }

    void individualParticles(int collection)
    {
        foreach(GameObject particle in collector.Collections[collection])
        {
            Material material = ChooseColor(collection);
            Renderer rend = particle.GetComponent<Renderer>();
            rend.material = material;
        }
    }

    void allParticles(int collection)
    {
        Material material = ChooseColor(collection);
        foreach(GameObject particle in collector.Collections[collection])
        {
            Renderer rend = particle.GetComponent<Renderer>();
            rend.material = material;
        }
    }

    void alternatingParticles(int collection)
    {
        Material materialForOdds = ChooseColor(collection);
        Material materialForEvens = ChooseColor(collection);

        for(int i= 0; i < collector.Collections[collection].Count; i++)
        {
            Renderer rend = collector.Collections[collection][i].GetComponent<Renderer>();

            if(i % 2 == 0)
            {
                rend.material = materialForEvens;
            }
            else
            {
                rend.material= materialForOdds;
            }
        }
    }

    Material ChooseColor(int collection)
    {
        Material material = new Material(Shader.Find("Unlit/Color"));
        material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

        return material;
    }




}
