using Godot;

public partial class Player1 : Sprite2D
{
	public override void _Process(double delta)
	{
		if(Input.IsActionPressed("left_player1"))
		{
			GD.Print("move left player1");
		}
		if(Input.IsActionPressed("right_player1"))
		{
			GD.Print("move right player1");
		}
	}
}
