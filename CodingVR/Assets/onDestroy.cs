using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject explored;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// This function is called when the MonoBehaviour will be destroyed.
    /// </summary>
    void OnDestroy()
    {
        if (explored != null)
        {
            Instantiate(explored, transform.position, explored.transform.rotation).SetActive(true);
        }
    }
}
