using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeContentController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] contents;
    public GameObject[] codables;
    public float dis = 0;
    public bool isSelf = true;
    void Start()
    {
        contents = GameObject.FindGameObjectsWithTag("CodeContent");
        codables = GameObject.FindGameObjectsWithTag("Codable");
    }

    // Update is called once per frame
    void Update()
    {
        dis = Vector3.Distance(codables[0].transform.position, transform.position);
        for (int i = 0; i < codables.Length; i++)
        {
            string id = codables[i].GetComponent<ID>().Id;
            GameObject content = Array.Find(contents, c => c.GetComponent<ID>().Id == id);

            if (Vector3.Distance(transform.position, codables[i].transform.position) <= 3f)
            {
                codables[i].GetComponent<Codable>().ray.SetActive(false);
                content.SetActive(true);
                isSelf = false;
            }
            else
            {
                codables[i].GetComponent<Codable>().ray.SetActive(true);
                content.SetActive(false);
            }

        }

        if (isSelf)
        {
            GameObject content = Array.Find(contents, c => c.GetComponent<ID>().Id == "self");

            content.SetActive(true);
        }
        else
        {
            GameObject content = Array.Find(contents, c => c.GetComponent<ID>().Id == "self");
            content.SetActive(false);
        }
        isSelf = true;
    }
}
