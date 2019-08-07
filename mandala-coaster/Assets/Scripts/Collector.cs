using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public List<List<GameObject>> Collections = new List<List<GameObject>>();

    public void AddCollection(List<GameObject> collection)
    {
        Collections.Add(collection);
    }

    public List<List<GameObject>> SelectAllParticles(int collection)
    {        
        List<List<GameObject>> selection = new List<List<GameObject>>();
        List<GameObject> group = new List<GameObject>();
        foreach(GameObject particle in Collections[collection])
        {
            group.Add(particle);
        }
        selection.Add(group);
        return selection;
    }

    public List<List<GameObject>> SelectAlternatingParticles(int collection)
    {
        List<List<GameObject>> selection = new List<List<GameObject>>();
        List<GameObject> odds_group = new List<GameObject>();
        List<GameObject> evens_group = new List<GameObject>();
        for(int i= 0; i < Collections[collection].Count; i++)
        {
            if(i % 2 == 0)
            {
                evens_group.Add(Collections[collection][i]);
            }
            else
            {
                odds_group.Add(Collections[collection][i]);
            }
        }
        selection.Add(odds_group);
        selection.Add(evens_group);
        return selection;
    }

    public List<List<GameObject>> SelectIndividualParticles(int collection)
    {
        List<List<GameObject>> selection = new List<List<GameObject>>();
        foreach(GameObject particle in Collections[collection])
        {
            List<GameObject> group = new List<GameObject>();
            group.Add(particle);
            selection.Add(group);
        }
        return selection;
    }

    public void ResetCollection()
    {
        Collections = new List<List<GameObject>>();
    }
}
