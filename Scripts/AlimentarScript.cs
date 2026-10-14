using Godot;
using System;

[GlobalClass]
public partial class AlimentarScript : Node
{
	[Export] RigidBody2D rigidbody;
	Node kaiju;

	public override void _Ready()
	{

		
		kaiju = GetNode("../Samuiso");
	}

	
}
