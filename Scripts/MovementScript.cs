using Godot;
using System;

[GlobalClass]
public partial class MovementScript : Node
{

	public bool petting = false;
	[Export] Timer timer1;
	[Export] int prueba = 0;
	[Export] private AnimatedSprite2D sprite;
	[Export] private RigidBody2D rigidbody;
	[Export] private GpuParticles2D particulas;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print(prueba);
		timer1.Start(5);
		timer1.OneShot = true;
	}

	public void OnRigidBody2dMouseEntered()
	{
		petting = true;
		particulas.Emitting = true;
		GD.Print(petting);
	}
	public void OnRigidBody2dMouseExited()
	{
		petting = false;
		particulas.Emitting = false;
		GD.Print(petting);
	}
	public override void _Process(double delta)
	{
		
		//GD.Print(timer1.TimeLeft);
		if(timer1.IsStopped())
		{
			rigidbody.LinearVelocity= new Vector2(0,0);
			Wander();
			timer1.Start(5);
		}
	}
	public void Wander()
	{	
	int speed = 4;
	int direccion = GD.RandRange(0,8);
	if(!petting){
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

	public void MoveTo(Node2D node)
	{
		for (int i = 0; i < 10; i++)
		{
		if(node.Position.X > 0){sprite.FlipH =true;}
		else{sprite.FlipH =false;};
		sprite.Play("Walking");
		GD.Print(node.Position);
		Vector2 hacia = rigidbody.Position.MoveToward(node.Position,10);
		rigidbody.ApplyCentralImpulse(hacia);
		}
	}

	void MyInputMethod(Node viewport, InputEvent @event, long shapeIdx, NodePath nodo)
	{

		if (@event is InputEventMouseButton mousButt)
		{
		GD.Print(nodo);
		MoveTo(GetNode<StaticBody2D>(nodo + "/StaticBody2D"));
		}

	}

}
