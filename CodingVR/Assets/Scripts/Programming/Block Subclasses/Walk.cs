using UnityEngine;
using System.Collections;

public class Walk : SimpleInscructionBlock {
    
    override public void Run(){
        // Debug.Log("Walk\n");
       // Player Player= GameObject.FindWithTag ("Player").GetComponent<Player> ();
       // Player.Walk();
       Codable toRunObj = GameObject.FindWithTag("Temp").GetComponent<Codable>();
        toRunObj.Forward();
        if (Next!=null)Next.Run();
    }
}
