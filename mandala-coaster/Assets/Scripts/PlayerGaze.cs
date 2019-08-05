using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGaze : MonoBehaviour
{
    private RaycastHit rayHit;
    public string currentTier;

    void Update()
    {
        
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out rayHit))
        {
            currentTier = rayHit.transform.name;
            Debug.Log(currentTier);
        }
    }
}
