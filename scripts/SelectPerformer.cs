using Godot;

public partial class SelectPerformer : Node2D
{
    private Godot.Collections.Array<Node> _player1Positions;
    private Godot.Collections.Array<Node> _player2Positions;
	private Sprite2D _player1;
    private int _player1IndexPosition = 1;
	private Sprite2D _player2;
	private int _player2IndexPosition = 1;

    public override void _Ready()
    {
        _player1Positions = GetTree().GetNodesInGroup("Player1Position");
		_player2Positions = GetTree().GetNodesInGroup("Player2Position");

		_player1 = GetNode<Sprite2D>("Player1");
        _player1.Position = (_player1Positions[_player1IndexPosition] as Marker2D).Position;

        _player2 = GetNode<Sprite2D>("Player2");
		_player2.Position = (_player2Positions[_player2IndexPosition] as Marker2D).Position;
    }
    public override void _PhysicsProcess(double delta)
	{
		//We can add later linear interpolation to make it smooth
		if(Input.IsActionJustPressed("left_player1"))
		{
			_player1.Position = (_player1Positions[_player1IndexPosition == 0 ? 0 : --_player1IndexPosition] as Marker2D).Position;
        }
		if(Input.IsActionJustPressed("right_player1"))
		{
            _player1.Position = (_player1Positions[_player1IndexPosition == _player1Positions.Count - 1 ? _player1Positions.Count - 1 : ++_player1IndexPosition] as Marker2D).Position;
		}
		if(Input.IsActionJustPressed("left_player2"))
		{
			_player2.Position = (_player2Positions[_player2IndexPosition == 0 ? 0 : --_player2IndexPosition] as Marker2D).Position;
		}
		if(Input.IsActionJustPressed("right_player2"))
		{
			_player2.Position = (_player2Positions[_player2IndexPosition == _player2Positions.Count - 1 ? _player2Positions.Count - 1 : ++_player2IndexPosition] as Marker2D).Position;
		}
	}
}
