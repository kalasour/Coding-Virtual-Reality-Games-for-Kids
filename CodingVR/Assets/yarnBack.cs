using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yarnBack : MonoBehaviour
{
    // Start is called before the first frame update
    public Boolean state = null;
    void Start()
    {
        state = GameObject.Find("isOnArea").GetComponent<Boolean>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (state.value) {
            transform.Translate(transform.forward * 0.1f, Space.World);
        }
        else if (transform.position.x <= -88.5) {
            transform.Translate(-transform.forward * 0.005f, Space.World);
        }
    }
}
