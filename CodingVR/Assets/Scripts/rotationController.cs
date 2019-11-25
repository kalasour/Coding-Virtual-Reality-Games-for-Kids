using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationController : MonoBehaviour
{
    public Transform cameraPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(this.transform.position + cameraPos.transform.rotation * Vector3.forward, cameraPos.transform.rotation * Vector3.up);
    }
}
