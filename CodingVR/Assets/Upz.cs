using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Upz : SimpleInscructionBlock
{
    // Start is called before the first frame update
    public string parentId = "";
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    override public void Run()
    {
        // Debug.Log("Walk\n");
        // Player Player= GameObject.FindWithTag ("Player").GetComponent<Player> ();
        // Player.Walk();
        parentId = transform.parent.gameObject.GetComponent<ID>().Id;
        GameObject[] Codables = GameObject.FindGameObjectsWithTag("Codable").Select(CodeContent => CodeContent.gameObject).ToArray<GameObject>();
        foreach (GameObject code in Codables)
        {
            if (code.GetComponent<ID>().Id == parentId)
            {
                Codable toRunObj = code.GetComponent<Codable>();
                toRunObj.Up();
                if (Next != null) Next.Run();
            }
        }

    }
}
