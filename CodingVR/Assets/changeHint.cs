using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class changeHint : MonoBehaviour
{
    // Start is called before the first frame update
    public string message = "";
    public GameObject room = null;
    void Start()
    {
        room = GameObject.Find("ROOM");
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            GameObject left = room.GetComponent<PauseRoom>().LeftCanvas;
            if (left != null)
            {
                GameObject tmo = left.transform.GetChild(0).transform.GetChild(0).gameObject;
                TextMeshPro tm = tmo.GetComponent<TextMeshPro>();
                Debug.Log(tmo.name);
                Debug.Log(tm.text);
                tm.SetText(message);
                tm.color = Color.black;
            }
        }
    }
}
