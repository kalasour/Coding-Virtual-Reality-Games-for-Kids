using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaCon : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject last;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject Go = transform.GetChild(i).gameObject;
            if (last == null) last = Go;
            if (Go.GetComponent<toggleArea>().state && Go != last)
            {
                last.SetActive(true);
                last = Go;
                Go.SetActive(false);
            }
        }
    }
}
