using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoRotator : MonoBehaviour
{
    // Start is called before the first frame update
    public float toMove = 0f;
    public float speed = 3f;
    public float x = -0.1f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (toMove >= speed * 2 || toMove <= -speed * 2) x *= -1f;
        toMove += x;
        transform.Rotate(new Vector3(toMove, speed, 0), Space.World);

    }
}
