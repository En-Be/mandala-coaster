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

    void allParticles(int collection)
    {
        Material material = ChooseColor();
        Vector3 size = ChooseSize();
        float speed = ChooseVelocity();
        float direction = ChooseDirection();

        foreach(GameObject particle in collector.Collections[collection])
        {
            Renderer particleRenderer = particle.GetComponent<Renderer>();
            particleRenderer.material = material;
            Transform particleTransform = particle.GetComponent<Transform>();
            particleTransform.localScale += size;
            Particle particleScript = particle.GetComponent<Particle>();
            particleScript.speed = speed;
            particleScript.direction = direction;
        }
    }

    void alternatingParticles(int collection)
    {
        Material materialForOdds = ChooseColor();
        Material materialForEvens = ChooseColor();
        Vector3 sizeForOdds = ChooseSize();
        Vector3 sizeForEvens = ChooseSize();
        float speedForOdds = ChooseVelocity();
        float speedForEvens = ChooseVelocity();
        float directionForOdds = ChooseDirection();
        float directionForEvens = ChooseDirection();

        for(int i= 0; i < collector.Collections[collection].Count; i++)
        {
            Renderer particleRenderer = collector.Collections[collection][i].GetComponent<Renderer>();
            Transform particleTransform = collector.Collections[collection][i].GetComponent<Transform>();
            Particle particleScript = collector.Collections[collection][i].GetComponent<Particle>();
            if(i % 2 == 0)
            {
                particleRenderer.material = materialForEvens;
                particleTransform.localScale += sizeForEvens;
                particleScript.speed = speedForEvens;
                particleScript.direction =  directionForEvens;
            }
            else
            {
                particleRenderer.material = materialForOdds;
                particleTransform.localScale += sizeForOdds;
                particleScript.speed = speedForOdds;
                particleScript.direction = directionForOdds;
            }
        }
    }

    void individualParticles(int collection)
    {
        foreach(GameObject particle in collector.Collections[collection])
        {
            Renderer particleRenderer = particle.GetComponent<Renderer>();
            particleRenderer.material = ChooseColor();
            Transform particleTransform = particle.GetComponent<Transform>();
            particleTransform.localScale += ChooseSize();
            Particle particleScript = particle.GetComponent<Particle>();
            particleScript.speed = ChooseVelocity();
            particleScript.direction = ChooseDirection();

        }
    }

    Material ChooseColor()
    {
        Material material = new Material(Shader.Find("Unlit/Color"));
        material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

        return material;
    }

    Vector3 ChooseSize()
    {
        Vector3 size = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(0.0f, 1.0f), Random.Range(-0.5f, 0.5f));
        return size;
    }

    float ChooseVelocity()
    {
        float speed = Random.Range(1.0f, 5.0f);
        return speed;
    }

    float ChooseDirection()
    {
        float direction = Random.Range(-1.0f, 1.0f);
        return direction;
    }
}
