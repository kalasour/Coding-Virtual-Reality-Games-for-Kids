using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Codable : MonoBehaviour
{
    // Start is called before the first frame update
    bool isForward = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isForward)
        {
            transform.Translate(-0.1f, 0, 0,Space.World);
           // if (transform.childCount > 0)
           // {
           //     Transform fChild = transform.GetChild(0);
           //     fChild.Translate(-0.1f, 0, 0);
           // }

            isForward = false;
        }

        
    }

    public void Turn()
    {
        transform.rotation = Quaternion.Euler(0, transform.localEulerAngles.y + 90, 0);
    }
    public void Forward()
    {
        isForward = true;
    }
}
