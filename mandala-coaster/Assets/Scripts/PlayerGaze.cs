using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGaze : MonoBehaviour
{
    private RaycastHit rayHit;
    public string currentTier;
    public Timer timer;
    public GameObject reticule;

    void Start()
    {
        timer = GameObject.Find("Player").GetComponent(typeof(Timer)) as Timer;
        reticule = GameObject.Find("Reticule");
    }

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out rayHit))
        {
            currentTier = rayHit.transform.name;

            if(currentTier == "tier_0" && timer.playing == false)
            {
                reticule.transform.localScale += new Vector3(0.01F, 0.01F, 0.01F);
            }
            
            if(reticule.transform.localScale.x >= 1.5 && reticule.activeSelf)
            {
                reticule.transform.localScale = new Vector3(0.2F, 0.2F, 0.2F);
                reticule.SetActive(false);
                timer.BeginNewMandala();
            }
        }
    }
}
