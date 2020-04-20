using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ORB : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject forceField = null;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// This function is called when the behaviour becomes disabled or inactive.
    /// </summary>
    void OnDisable()
    {
        if (forceField != null)
            Destroy(forceField);
    }

    /// <summary>
    /// This function is called when the MonoBehaviour will be destroyed.
    /// </summary>
    void OnDestroy()
    {
        if (forceField != null)
            Destroy(forceField);
    }
}
