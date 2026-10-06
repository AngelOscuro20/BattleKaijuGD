using Godot;
using System;

[GlobalClass]
public partial class NewScript : Node
{
[Export]
	Timer timer1;
[Export]
	int prueba = 0;
[Export]
private AnimatedSprite2D sprite;
[Export]
private RigidBody2D rigidbody;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print(prueba);
		timer1.Start(5);
		timer1.OneShot = true;
	}

	public override void _Process(double delta)
	{
		GD.Print(timer1.TimeLeft);
		if(timer1.IsStopped())
		{
			Wander();
			timer1.Start(5);
		}
	}
	public void Wander()
	{	
	int speed = 3;
	int direccion = GD.RandRange(0,8);
		switch (direccion)
		{
			default: break;
			case 0:break;
			case 1: sprite.FlipH =true;rigidbody.ApplyCentralImpulse(speed*new Vector2(1,0));sprite.Play("Walking");break;
			case 2: sprite.FlipH =false;rigidbody.ApplyCentralImpulse(speed*new Vector2(-1,0));sprite.Play("Walking");break;
			case 3: sprite.FlipH =true;rigidbody.ApplyCentralImpulse(speed*new Vector2(0,1));sprite.Play("Walking");break;
			case 4: sprite.FlipH =true;rigidbody.ApplyCentralImpulse(speed*new Vector2(0,-1));sprite.Play("Walking");break;
			case 5: sprite.FlipH =true;rigidbody.ApplyCentralImpulse(speed*new Vector2(1,-1));sprite.Play("Walking");break;
			case 6: sprite.FlipH =false;rigidbody.ApplyCentralImpulse(speed*new Vector2(-1,1));sprite.Play("Walking");break;
			case 7: sprite.FlipH =false;rigidbody.ApplyCentralImpulse(speed*new Vector2(-1,-1));sprite.Play("Walking");break;
			case 8: sprite.FlipH =true;rigidbody.ApplyCentralImpulse(speed*new Vector2(1,1));sprite.Play("Walking");break;
		}
	}

}
