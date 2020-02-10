using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BooleanExplain : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isOn;
    TextMeshPro text;
    void Start()
    {
        text = gameObject.GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isOn) {
            text.color = new Color32(255, 255, 255, 255);
        }
        else {
            text.color = new Color32(255, 255, 255, 0);
        }
    }
}
