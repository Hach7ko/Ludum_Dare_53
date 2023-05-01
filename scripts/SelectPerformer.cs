using Godot;

public partial class Config
{

    public const int ROULYO_PERFORMER_ID = 0;
    public const int SAMOUSSA_PERFORMER_ID = 1;
    public const int CPU_CONTROLLER_ID = 0;
    public const int GPAD1_CONTROLLER_ID = 1;
    public const int GPAD2_CONTROLLER_ID = 2;
    public const string ROULYO_DESCRIPTION = "Straight from the suburbs, \n Roulyo chose the thug life, \n but the thug life did not chose him";
    public const string SAMOUSSA_DESCRIPTION = "Maybe they're born with it, \n maybe it's the onesie.";
}

public partial class SelectPerformer : Control
{
    [Signal]
    public delegate void IsGameReadyToPlayEventHandler(bool isGameReadyToPlay);
    private const int SPACE_BETWEEN_GAMEPAD = 100; //px
    public enum Performers : int
    {
        Roulyo = 0,
        CPU = 1,
        Samoussa = 2
    }
    private Godot.Collections.Array<Node> _gamepad1Positions;
    private Sprite2D _gamepad1;
    private int _gamepad1IndexPosition = (int)Performers.CPU; //Starting at the middle of the screen
    private Godot.Collections.Array<Node> _gamepad2Positions;
    private Sprite2D _gamepad2;
    private int _gamepad2IndexPosition = (int)Performers.CPU; //Starting at the middle of the screen
    public Performers _gamepad1SelectedPerformer = Performers.CPU;
    public Performers _gamepad2SelectedPerformer = Performers.CPU;
    private bool _isGameStarted = false;

    public override void _Ready()
    {
        _gamepad1Positions = GetTree().GetNodesInGroup("Gamepad1Position");
        _gamepad2Positions = GetTree().GetNodesInGroup("Gamepad2Position");

        _gamepad1 = GetNode<Sprite2D>("Gamepad1");
        _gamepad1.GlobalPosition = new Vector2(GetViewportRect().Size.X / 2, GetViewportRect().Size.Y / 2 - SPACE_BETWEEN_GAMEPAD);

        _gamepad2 = GetNode<Sprite2D>("Gamepad2");
        _gamepad2.GlobalPosition = new Vector2(GetViewportRect().Size.X / 2, GetViewportRect().Size.Y / 2 + SPACE_BETWEEN_GAMEPAD);

    }
    //-----------------------------------------------------------------------------
    public override void _PhysicsProcess(double delta)
    {
        if (!_isGameStarted)
        {
            //We can add later linear interpolation to make it move smoothly
            if (Input.IsActionJustPressed("left_gamepad1"))
            {
                int currentIndex = _gamepad1IndexPosition == 0 ? 0 : --_gamepad1IndexPosition;
                if (currentIndex == 0)
                {
                    if (_gamepad2SelectedPerformer == Performers.Roulyo)
                    {
                        _gamepad1IndexPosition = (int)Performers.CPU;
                        GetNode<AnimationPlayer>("../AnimationPlayer").Play("shake_gamepad1");
                    }
                    else if (_gamepad2SelectedPerformer != Performers.Roulyo)
                    {
                        Gamepad1PerformerSelected(Performers.Roulyo, currentIndex);
                    }
                }
                else
                {
                    SelectCPUForGamepad("gamepad1");
                }
            }
            if (Input.IsActionJustPressed("right_gamepad1"))
            {
                int currentIndex = _gamepad1IndexPosition == _gamepad1Positions.Count - 1 ? _gamepad1Positions.Count - 1 : ++_gamepad1IndexPosition;
                if (_gamepad1IndexPosition == _gamepad1Positions.Count - 1)
                {
                    //Player is already selected, play the shake animation
                    if (_gamepad2SelectedPerformer == Performers.Samoussa)
                    {
                        _gamepad1IndexPosition = (int)Performers.CPU;
                        GetNode<AnimationPlayer>("../AnimationPlayer").Play("shake_gamepad1");
                    }
                    else if (_gamepad2SelectedPerformer != Performers.Samoussa)
                    {
                        Gamepad1PerformerSelected(Performers.Samoussa, currentIndex);
                    }
                }
                else
                {
                    SelectCPUForGamepad("gamepad1");
                }
            }
            if (Input.IsActionJustPressed("left_gamepad2"))
            {
                int currentIndex = _gamepad2IndexPosition == 0 ? 0 : --_gamepad2IndexPosition;
                if (currentIndex == 0)
                {
                    //Player is already selected, play the shake animation
                    if (_gamepad1SelectedPerformer == Performers.Roulyo)
                    {
                        _gamepad2IndexPosition = (int)Performers.CPU;
                        GetNode<AnimationPlayer>("../AnimationPlayer").Play("shake_gamepad2");
                    }
                    else if (_gamepad1SelectedPerformer != Performers.Roulyo)
                    {
                        Gamepad2PerformerSelected(Performers.Roulyo, currentIndex);
                    }
                }
                else
                {
                    SelectCPUForGamepad("gamepad2");
                }
            }
            if (Input.IsActionJustPressed("right_gamepad2"))
            {
                int currentIndex = _gamepad2IndexPosition == _gamepad2Positions.Count - 1 ? _gamepad2Positions.Count - 1 : ++_gamepad2IndexPosition;
                if (_gamepad2IndexPosition == _gamepad2Positions.Count - 1)
                {
                    if (_gamepad1SelectedPerformer == Performers.Samoussa)
                    {
                        _gamepad2IndexPosition = (int)Performers.CPU;
                        GetNode<AnimationPlayer>("../AnimationPlayer").Play("shake_gamepad2");
                    }
                    else if (_gamepad1SelectedPerformer != Performers.Samoussa)
                    {
                        Gamepad2PerformerSelected(Performers.Samoussa, currentIndex);

                    }
                }
                else
                {
                    SelectCPUForGamepad("gamepad2");
                }
            }
        }
    }

    //-----------------------------------------------------------------------------
    public bool IsGamepadCPUBound(int gpadIdx)
    {
        return (gpadIdx == Config.GPAD1_CONTROLLER_ID && _gamepad1SelectedPerformer == Performers.CPU)
            || (gpadIdx == Config.GPAD2_CONTROLLER_ID && _gamepad2SelectedPerformer == Performers.CPU);
    }
    //-----------------------------------------------------------------------------
    public int GetGamepadForPerformer(Performers performer)
    {
        if (_gamepad1SelectedPerformer == performer)
        {
            return Config.GPAD1_CONTROLLER_ID;
        }
        else if (_gamepad2SelectedPerformer == performer)
        {
            return Config.GPAD2_CONTROLLER_ID;
        }
        else
        {
            return Config.CPU_CONTROLLER_ID;
        }
    }
    //-----------------------------------------------------------------------------
    private void SelectCPUForGamepad(string gamepad)
    {
        if (gamepad == "gamepad1")
        {
            GetNode<Label>("Description/Gamepad1Description").Text = "";
            GetNode<Label>("Description/Gamepad1Description").Hide();
            _gamepad1SelectedPerformer = Performers.CPU;
            _gamepad1.GlobalPosition = new Vector2(GetViewportRect().Size.X / 2, GetViewportRect().Size.Y / 2 - 100);
        }
        else if (gamepad == "gamepad2")
        {
            GetNode<Label>("Description/Gamepad2Description").Text = "";
            GetNode<Label>("Description/Gamepad2Description").Hide();
            _gamepad2SelectedPerformer = Performers.CPU;
            _gamepad2.GlobalPosition = new Vector2(GetViewportRect().Size.X / 2, GetViewportRect().Size.Y / 2 + 100);
        }
        OnIsGameReadyToPlay();
    }
    //-----------------------------------------------------------------------------
    private void Gamepad1PerformerSelected(Performers performer, int index)
    {

        GetNode<Label>("Description/Gamepad1Description").Text = performer == Performers.Roulyo ? Config.ROULYO_DESCRIPTION : Config.SAMOUSSA_DESCRIPTION;
        GetNode<Label>("Description/Gamepad1Description").Show();
        _gamepad1SelectedPerformer = performer;
        _gamepad1.GlobalPosition = (_gamepad1Positions[index] as Marker2D).GlobalPosition;
        OnIsGameReadyToPlay();
    }
    //-----------------------------------------------------------------------------
    private void Gamepad2PerformerSelected(Performers performer, int index)
    {
        GetNode<Label>("Description/Gamepad2Description").Text = performer == Performers.Roulyo ? Config.ROULYO_DESCRIPTION : Config.SAMOUSSA_DESCRIPTION;
        GetNode<Label>("Description/Gamepad2Description").Show();
        _gamepad2SelectedPerformer = performer;
        _gamepad2.GlobalPosition = (_gamepad2Positions[index] as Marker2D).GlobalPosition;
        OnIsGameReadyToPlay();
    }
    //-----------------------------------------------------------------------------
    private void OnIsGameReadyToPlay()
    {
        bool _isGameReadyToPlay = (_gamepad1SelectedPerformer != Performers.CPU || _gamepad2SelectedPerformer != Performers.CPU) ? true : false;
        EmitSignal(nameof(IsGameReadyToPlay), _isGameReadyToPlay);
    }
    //-----------------------------------------------------------------------------
    private void OnGameStarted()
    {
        _isGameStarted = true;
        GetNode<Label>("Description/Gamepad1Description").Hide();
        GetNode<Label>("Description/Gamepad2Description").Hide();
    }
}
