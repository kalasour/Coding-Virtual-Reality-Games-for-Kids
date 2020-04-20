using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ID : MonoBehaviour
{
    // Start is called before the first frame update
    public string Id = "";
    void Start()
    {
        if (Id == "") Id = gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
