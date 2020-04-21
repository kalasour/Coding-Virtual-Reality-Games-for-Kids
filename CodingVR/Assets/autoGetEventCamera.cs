using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoGetEventCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera currentCamera = null;
    private Canvas canvas = null;
    void Start()
    {
        canvas = GetComponent<Canvas>();
        GameObject co = GameObject.Find("CenterEyeAnchor");
        if (co == null) co = GameObject.Find("FirstPersonCharacter");
        if (co != null) currentCamera = co.GetComponent<Camera>();
        if (currentCamera != null)
            canvas.worldCamera = currentCamera;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
