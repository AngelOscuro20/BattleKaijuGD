using Godot;
using System;

public partial class GUIScript : VBoxContainer
{
	[Export] CareManagerScript CareManager;
	[Export] HBoxContainer containerHambre;
	[Export] HBoxContainer containerFuerza;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ActualizarHambre();
		ActualizarFuerza();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void ActualizarHambre()
	{ 
		for(int i = 0;i < containerHambre.GetChildCount();i++)
		{
			if(i < CareManager.getHambre()){containerHambre.GetChild<TextureRect>(i).Visible = true;}
			else{containerHambre.GetChild<TextureRect>(i).Visible = false;}
		}
		
	}
	public void ActualizarFuerza()
	{ 
		for(int i = 0;i < containerFuerza.GetChildCount();i++)
		{
			if(i < CareManager.getFuerza()){containerFuerza.GetChild<TextureRect>(i).Visible = true;}
			else{containerFuerza.GetChild<TextureRect>(i).Visible = false;}
		}
		
	}
}
