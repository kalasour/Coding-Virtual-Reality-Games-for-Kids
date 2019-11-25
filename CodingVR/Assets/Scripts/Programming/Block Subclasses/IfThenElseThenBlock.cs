﻿using System.Collections;
using UnityEngine;

public class IfThenElseThenBlock : Block {
	override public void Run () {
		if (If != null) {
			if (If.CheckCond ()) {

				if (Inside1 != null) Inside1.Run ();
				else {
					if (Inside2 != null) Inside2.Run ();
				}
			}
		}
		if (Next != null) Next.Run ();
		// if(this.nextConnection.cone!=null)Log("Beep2\n")
	}
	override protected void CreateConnections () {
		this.blockType = BlockType.BlockTypeInscrution;
		Connection previousConnection = new Connection (this, new Vector2 (6, 100), Connection.ConnectionType.Previous);
		Connection nextConnection = new Connection (this, new Vector2 (7, 0), Connection.ConnectionType.Next);
		Connection thenConnection = new Connection (this, new Vector2 (30, 77), Connection.ConnectionType.Inside1);
		Connection then2Connection = new Connection (this, new Vector2 (29, 20), Connection.ConnectionType.Inside2);
		Connection conditionConnection = new Connection (this, new Vector2 (66, 95), Connection.ConnectionType.If);

		previousConnection.SetAcceptableBlockType (BlockType.BlockTypeInscrution);
		nextConnection.SetAcceptableBlockType (BlockType.BlockTypeInscrution);
		thenConnection.SetAcceptableBlockType (BlockType.BlockTypeInscrution);
		then2Connection.SetAcceptableBlockType (BlockType.BlockTypeInscrution);
		conditionConnection.SetAcceptableBlockType (BlockType.BlockTypeLogic);

		this.connections.Add (previousConnection);

		this.connections.Add (thenConnection);
		this.connections.Add (then2Connection);
		this.connections.Add (conditionConnection);

		this.connections.Add (nextConnection);
	}
}