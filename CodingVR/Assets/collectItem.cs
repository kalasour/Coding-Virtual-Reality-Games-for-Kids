using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectItem : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            if (target != null) {
                target.SetActive(true);
                Destroy(gameObject);
            }
        }
    }
}
