using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public List<List<GameObject>> Collections = new List<List<GameObject>>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AddCollection(List<GameObject> collection)
    {
        Collections.Add(collection);
        int i = 0;
        foreach(List<GameObject> c in Collections)
        {
            i++;
        }
    }


}
