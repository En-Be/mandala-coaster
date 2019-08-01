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


}
