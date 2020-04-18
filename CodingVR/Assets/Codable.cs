using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Codable : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isForward = false;
    public bool isTurned = false;
    private bool turning = false;
    private bool canTurn = true;
    int count = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isForward)
        {
            transform.Translate(transform.forward, Space.World);
            // if (transform.childCount > 0)
            // {
            //     Transform fChild = transform.GetChild(0);
            //     fChild.Translate(-0.1f, 0, 0);
            // }

            isForward = false;
        }
        if (isTurned && canTurn)
        {
            canTurn = false;
            turning = true;
            count = 0;
            isTurned = false;
        }
        if (!canTurn) { isTurned = false; }
        if (turning)
        {
            transform.rotation = Quaternion.Euler(0, transform.localEulerAngles.y + 1, 0);
            count++;
            if (count == 90)
            {
                turning = false;
                canTurn = true;
            }
        }


    }

    public void Turn()
    {
        isTurned = true;
    }
    public void Forward()
    {
        isForward = true;
    }
}
