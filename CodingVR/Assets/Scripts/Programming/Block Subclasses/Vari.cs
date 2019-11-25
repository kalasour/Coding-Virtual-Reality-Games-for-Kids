using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class Vari : Block
{
    public string var;
    public Text childText;
    public bool isY;
    override public double GetValue()
    {
        // Debug.Log(get.getDistance());
        // Debug.Log(get.getDistance());

        return 1000;
    }
    // private void Start() {
    // 	childText.text=name;
    // }

    private void Update()
    {
      
    }
    override protected void CreateConnections()
    {
        // var = childText.text;
        this.blockType = BlockType.BlockTypeNumeric;
        Connection previousConnection = new Connection(this, new Vector2(50, 50), Connection.ConnectionType.Previous);

        previousConnection.SetAcceptableBlockType(BlockType.BlockTypeLogic);

        this.connections.Add(previousConnection);

    }
}