using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yarnBack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -88.5) {
            transform.Translate(-transform.forward*0.005f, Space.World);
        }
    }
}
