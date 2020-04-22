using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class changeHint : MonoBehaviour
{
    // Start is called before the first frame update
    public string message = "";
    public PauseRoom room = null;
    public GameObject Selected = null;
    public int index = 0;
    void Start()
    {
        room = GameObject.Find("ROOM").GetComponent<PauseRoom>();

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            if (index == 0) Selected = room.BackCanvas;
            else if (index == 1) Selected = room.FrontCanvas;
            else if (index == 2) Selected = room.LeftCanvas;
            if (Selected != null)
            {
                GameObject tmo = Selected.transform.GetChild(0).transform.GetChild(0).gameObject;
                TextMeshProUGUI tm = tmo.GetComponent<TextMeshProUGUI>();
                tm.SetText(message);
                tm.color = Color.black;
            }
        }
    }
}
