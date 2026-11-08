using Godot;
using System;

[GlobalClass]
public partial class AlimentarScript : Node
{
	[Export] CareManagerScript CareManager;

	public override void _Ready()
	{
		
	}

	void MyInputMethod(Node viewport, InputEvent @event, long shapeIdx)
	{

		if (@event is InputEventMouseButton mousButt)
		{
			CareManager.ReponerHambre();
		}

	}

	
}
