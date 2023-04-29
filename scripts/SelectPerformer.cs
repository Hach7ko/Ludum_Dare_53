using Godot;

public partial class SelectPerformer : Node2D
{
	[Signal]
    public delegate void Gamepad1PerformerSelectedEventHandler(string performer);
	[Signal]
    public delegate void Gamepad2PerformerSelectedEventHandler(string performer);
	enum Performers : int
    {
        Roulyo = 0,
		CPU = 1,
        Samoussa = 2
    }
    private Godot.Collections.Array<Node> _gamepad1Positions;
	private Sprite2D 					  _gamepad1;
    private int 						  _gamepad1IndexPosition = (int)Performers.CPU; //Starting at the middle of the screen
	private Godot.Collections.Array<Node> _gamepad2Positions;
	private Sprite2D 					  _gamepad2;
	private int 						  _gamepad2IndexPosition = (int)Performers.CPU; //Starting at the middle of the screen
    private Performers 					  _gamepad1SelectedPerformer = Performers.CPU;
	private Performers 					  _gamepad2SelectedPerformer = Performers.CPU;
    public override void _Ready()
    {
        _gamepad1Positions = GetTree().GetNodesInGroup("Gamepad1Position");
		_gamepad2Positions = GetTree().GetNodesInGroup("Gamepad2Position");

		_gamepad1 = GetNode<Sprite2D>("Gamepad1");
        _gamepad1.Position = (_gamepad1Positions[_gamepad1IndexPosition] as Marker2D).Position;

        _gamepad2 = GetNode<Sprite2D>("Gamepad2");
		_gamepad2.Position = (_gamepad2Positions[_gamepad2IndexPosition] as Marker2D).Position;
    }
//-----------------------------------------------------------------------------
    public override void _PhysicsProcess(double delta)
	{
        //We can add later linear interpolation to make it move smoothly
        if(Input.IsActionJustPressed("left_gamepad1"))
		{
            int currentIndex = _gamepad1IndexPosition == 0 ? 0 : --_gamepad1IndexPosition;
			if(currentIndex == 0 && _gamepad2SelectedPerformer != Performers.Roulyo) 
			{
				_gamepad1.Position = (_gamepad1Positions[currentIndex] as Marker2D).Position;
				OnGamepad1PerformerSelected(Performers.Roulyo);
			} else
			{
                SelectCPUForGamepad("gamepad1");
            }			
        }
		if(Input.IsActionJustPressed("right_gamepad1"))
		{
			int currentIndex = _gamepad1IndexPosition == _gamepad1Positions.Count - 1 ? _gamepad1Positions.Count - 1 : ++_gamepad1IndexPosition;
			if(_gamepad1IndexPosition == _gamepad1Positions.Count - 1 && _gamepad2SelectedPerformer != Performers.Samoussa)
			{
            	_gamepad1.Position = (_gamepad1Positions[currentIndex] as Marker2D).Position;
				OnGamepad1PerformerSelected(Performers.Samoussa);
			} else
			{
				SelectCPUForGamepad("gamepad1");
			}
		}
		if(Input.IsActionJustPressed("left_gamepad2"))
		{
			int currentIndex = _gamepad2IndexPosition == 0 ? 0 : --_gamepad2IndexPosition;
			if(_gamepad2IndexPosition == 0 && _gamepad1SelectedPerformer != Performers.Roulyo)
			{
				_gamepad2.Position = (_gamepad2Positions[currentIndex] as Marker2D).Position;
				OnGamepad2PerformerSelected(Performers.Roulyo);
			} else
			{
				SelectCPUForGamepad("gamepad2");
			}
		}
		if(Input.IsActionJustPressed("right_gamepad2"))
		{
			int currentIndex = _gamepad2IndexPosition == _gamepad2Positions.Count - 1 ? _gamepad2Positions.Count - 1 : ++_gamepad2IndexPosition;
			if(_gamepad2IndexPosition == _gamepad2Positions.Count - 1  && _gamepad1SelectedPerformer != Performers.Samoussa)
			{
				_gamepad2.Position = (_gamepad2Positions[currentIndex] as Marker2D).Position;
				OnGamepad2PerformerSelected(Performers.Samoussa);
			} else
			{
                SelectCPUForGamepad("gamepad2");
            }
		}
	}
//-----------------------------------------------------------------------------
	private void SelectCPUForGamepad(string gamepad)
	{
		if(gamepad == "gamepad1")
		{
			_gamepad1.Position = (_gamepad1Positions[(int)Performers.CPU] as Marker2D).Position;
			OnGamepad1PerformerSelected(Performers.CPU);
		} else if(gamepad == "gamepad2")
		{
			_gamepad2.Position = (_gamepad2Positions[(int)Performers.CPU] as Marker2D).Position;
			OnGamepad2PerformerSelected(Performers.CPU);
		}

	}
//-----------------------------------------------------------------------------
	private void OnGamepad1PerformerSelected(Performers performer)
	{
        _gamepad1SelectedPerformer = performer;
        EmitSignal(nameof(Gamepad1PerformerSelected), performer.ToString());
    }
//-----------------------------------------------------------------------------
	private void OnGamepad2PerformerSelected(Performers performer)
	{
		_gamepad2SelectedPerformer = performer;
        EmitSignal(nameof(Gamepad2PerformerSelected), performer.ToString());
	}
}
