using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class Boolean : Block
{
    public string var;
    public string ID;
    public Text childText;
    public bool value = false;
    override public bool CheckCond()
    {
        // Debug.Log(get.getDistance());
        // Debug.Log(get.getDistance());

        return value;
    }
    // private void Start() {
    // 	childText.text=name;
    // }
    private void FixedUpdate()
    {
        if(!value)
            gameObject.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
        else
            gameObject.GetComponent<Image>().color = new Color32(0, 255, 0, 255);

    }

    override protected void CreateConnections()
    {
        // var = childText.text;
        this.blockType = BlockType.BlockTypeLogic;
        Connection previousConnection = new Connection(this, new Vector2(50, 50), Connection.ConnectionType.Previous);

        previousConnection.SetAcceptableBlockType(BlockType.BlockTypeInscrution | BlockType.BlockTypeConditionJoint);

        this.connections.Add(previousConnection);

    }
}