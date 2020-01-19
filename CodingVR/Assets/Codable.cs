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
    void Update()
    {
        if (isForward)
        {
            transform.position = new Vector3(transform.position.x-0.1f, transform.position.y, transform.position.z);
            if (transform.childCount > 0)
            {
                Transform fChild = transform.GetChild(0);
                fChild.position = new Vector3(fChild.position.x - 0.1f, fChild.position.y, fChild.position.z);
            }

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
