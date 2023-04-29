using Godot;

public partial class SelectPerformer : Node2D
{
    public override void _PhysicsProcess(double delta)
	{
		Sprite2D roulyo = GetNode<Sprite2D>("Roulyo");
		Sprite2D samoussa = GetNode<Sprite2D>("Samoussa");
		Sprite2D player1 = GetNode<Sprite2D>("Player1");
		Sprite2D player2 = GetNode<Sprite2D>("Player2");

		if(Input.IsActionJustPressed("left_player1"))
		{
            player1.Position = roulyo.Position;
		}
		if(Input.IsActionJustPressed("right_player1"))
		{
            player1.Position = samoussa.Position;
		}
		if(Input.IsActionJustPressed("left_player2"))
		{
			player2.Position = roulyo.Position;
		}
		if(Input.IsActionJustPressed("right_player2"))
		{
			player2.Position = samoussa.Position;
		}
	}
}
