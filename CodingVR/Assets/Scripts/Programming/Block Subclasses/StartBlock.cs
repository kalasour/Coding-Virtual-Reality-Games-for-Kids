using System.Collections;
using UnityEngine;

public class StartBlock : Block {
	override public void Run () {
		if(Next!=null)Next.Run();
	}

	override protected void CreateConnections () {
		this.isStartBlock=true;
		this.blockType = BlockType.BlockTypeInscrution;
		Connection previousConnection = new Connection (this, new Vector3 (35, 42,0), Connection.ConnectionType.Previous);
		Connection nextConnection = new Connection (this, new Vector3 (-52.5f, -24.1f, 0), Connection.ConnectionType.Next);

		previousConnection.SetAcceptableBlockType (BlockType.BlockTypeStart);
		nextConnection.SetAcceptableBlockType (BlockType.BlockTypeInscrution);

		this.connections.Add (previousConnection);

		this.connections.Add (nextConnection);
	}
}