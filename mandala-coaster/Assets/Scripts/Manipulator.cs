using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manipulator : MonoBehaviour
{
    private Collector collector;
    private PlayerGaze playerGaze;
    private List<Color> colours;
    public int stage;

    void Start()
    {
        collector = gameObject.GetComponent(typeof(Collector)) as Collector;
        playerGaze = GameObject.Find("Main Camera").GetComponent(typeof(PlayerGaze)) as PlayerGaze;
        colours = new List<Color>();
        colours.Add(Color.blue);
        colours.Add(Color.red);
        colours.Add(Color.yellow);
    }

    public void Manipulate(int collection)
    {
        List<List<GameObject>> selection = selectParticles(collection);
        foreach(List<GameObject> group in selection)
        {
            ApplyColourAndSizeAndSpeedAndDirection(group);
        }
    }

    List<List<GameObject>> selectParticles(int collection)
    {
        List<List<GameObject>> selection = new List<List<GameObject>>();
        switch(playerGaze.currentTier)
        {
            case("tier_0"):
                selection =  new List<List<GameObject>>();
                break;
            case ("tier_1"):
                selection = collector.SelectAllParticles(collection);
                break;
            case ("tier_2"):
                selection = collector.SelectAlternatingParticles(collection);
                break;
            case ("tier_3"):
                selection = collector.SelectIndividualParticles(collection);
                break;
        }
        return selection;
    }

    void ApplyColourAndSizeAndSpeedAndDirection(List<GameObject> selection)
    {
        Material material = ChooseColor();
        Vector3 size = ChooseSize();
        float speed = ChooseVelocity();
        float direction = ChooseDirection();

        foreach(GameObject particle in selection)
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

    Material ChooseColor()
    {
        Material material = new Material(Shader.Find("Unlit/Color"));
        switch(stage)
        {
            default:
                material.color = colours[stage];
                break;
            case 3:
                material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
                break;
        }
        material.color += Random.ColorHSV(-0.5F, 0.5F, -0.5F, 0.5F, -0.5F, 0.5F);
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
