using UnityEngine;
using System.Collections;
using System.Linq;

public class TurnRight : SimpleInscructionBlock {
    public string parentId = "";
    public GameObject[] Codables;
    override public void Run(){
        parentId = transform.parent.gameObject.GetComponent<ID>().Id;
        Codables = Resources.FindObjectsOfTypeAll<Codable>().Select(com => com.gameObject).ToArray<GameObject>();
        foreach (GameObject code in Codables)
        {
            if (code.GetComponent<ID>().Id == parentId)
            {
                Codable toRunObj = code.GetComponent<Codable>();
                toRunObj.TurnRight();
                if (Next != null) Next.Run();
            }
        }
    }
}
