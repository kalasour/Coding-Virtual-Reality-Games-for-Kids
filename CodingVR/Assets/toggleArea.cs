using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleArea : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject targetTrigger;
    public BooleanExplain targetText;
    public string booString;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == targetTrigger) {
            GameObject[] found = GameObject.FindGameObjectsWithTag("Block");
            foreach (GameObject i in found) {
                if (i.GetComponent<Boolean>() != null)
                {
                    Boolean boo = i.GetComponent<Boolean>();
                    if (boo.ID == booString) {
                        boo.value = true;
                    }
                }
            }
        }
        if (other.gameObject.CompareTag("Player") && targetText != null) {
            targetText.isOn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == targetTrigger)
        {
            GameObject[] found = GameObject.FindGameObjectsWithTag("Block");
            foreach (GameObject i in found)
            {
                if (i.GetComponent<Boolean>() != null)
                {
                    Boolean boo = i.GetComponent<Boolean>();
                    if (boo.ID == booString)
                    {
                        boo.value = false;
                    }
                }
            }
        }
        if (other.gameObject.CompareTag("Player") && targetText != null)
        {
            targetText.isOn = false;
        }
    }
}
