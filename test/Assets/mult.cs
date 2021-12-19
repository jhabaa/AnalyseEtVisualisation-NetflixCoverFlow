using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mult : MonoBehaviour
{
    public List<GameObject> test;
    // Start is called before the first frame update
    void Start()
    {
        GameObject g = new GameObject();
        test.Add(g);
        test.Remove(g);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
