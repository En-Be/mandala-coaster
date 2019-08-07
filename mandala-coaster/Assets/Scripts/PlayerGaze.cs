using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGaze : MonoBehaviour
{
    private RaycastHit rayHit;
    public string currentTier;
    public Timer timer;
    private GameObject reticule;
    private GameObject ring;

    void Start()
    {
        timer = GameObject.Find("Player").GetComponent(typeof(Timer)) as Timer;
        reticule = GameObject.Find("Reticule");
        ring = GameObject.Find("ring");

    }

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out rayHit))
        {
            currentTier = rayHit.transform.name;

            if(currentTier == "tier_0" && timer.playing == false)
            {
                reticule.transform.localScale += new Vector3(0.005F, 0.005F, 0.005F);
            }
            else if(reticule.transform.localScale.x >= 0.1F)
            {
                reticule.transform.localScale -= new Vector3(0.01F, 0.01F, 0.01F);
            }
            
            if(reticule.transform.localScale.x >= 0.8F && reticule.activeSelf)
            {
                reticule.SetActive(false);
                ring.SetActive(false);
                reticule.transform.localScale = new Vector3(0.1F, 0.1F, 0.1F);
                timer.BeginNewMandala();
            }
        }
    }
}
