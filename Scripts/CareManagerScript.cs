using Godot;
using System;
using System.Dynamic;

public partial class CareManagerScript : Node
{
	[Export] GUIScript GUI;
	[Export] public int hambre = 5;
	[Export] public int fuerza = 5;
	[Export] Timer timerComer;
	[Export] Timer timerEntrenar;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		timerComer.Start(5);
		timerEntrenar.Start(5);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		//GD.Print(hambre);
		//GD.Print(fuerza);
	}

	public void ComerSignal()
	{
		hambre--;
		GUI.ActualizarHambre();
		GD.Print("hmabre");
	}
	public void EntrenarSignal()
	{
		fuerza--;
		GUI.ActualizarFuerza();
		GD.Print("feurza");
	}

	public int GetHambre(){return hambre;}
	public int GetFuerza(){return fuerza;}

	public void ReponerHambre()
	{
		hambre++;
		GUI.ActualizarHambre();
		GD.Print("nom");
	}

	public void ReponerFuerza()
	{
		fuerza++;
		GUI.ActualizarFuerza();
	}

}
