using Godot;

public partial class HUD : Control
{
    [Signal]
    public delegate void CountdownReachedZeroEventHandler();
    [Signal]
    public delegate void GameStartedEventHandler();
    private bool _isGameReadyToPlay = false;
    private int _countdown = 3;
    private bool _isGameStarted = false;

    //-----------------------------------------------------------------------------
    public override void _Ready()
    {
        GetNode<AudioStreamPlayer>("../IdleTheme").Play();
    }

    public override void _Input(InputEvent inputEvent)
    {
        if (inputEvent.IsActionPressed("confirm") && _isGameReadyToPlay && !_isGameStarted)
        {
            EmitSignal(nameof(GameStarted));
            _isGameStarted = true;
            GetNode<Label>("Main/Middle/Countdown").Show();
            GetNode<Timer>("Main/Middle/CountdownToStart").Start();
            GetNode<Node2D>("../PerformerSelection").Hide();
            GetNode<Label>("Footer/PressToStart").Hide();
            GetNode<Label>("Header/GameTitle").Hide();
            GetNode<AudioStreamPlayer>("../Countdown").Play();
        }
    }
    //-----------------------------------------------------------------------------
    public void OnCountdownToStartTimeout()
    {
        --_countdown;
        GetNode<Label>("Main/Middle/Countdown").Text = _countdown.ToString();
        if (_countdown == 0)
        {
            _isGameReadyToPlay = false;
            GetNode<Timer>("Main/Middle/CountdownToStart").Stop();
            GetNode<Label>("Main/Middle/Countdown").Hide();
            EmitSignal(nameof(CountdownReachedZero));
            GetNode<AudioStreamPlayer>("../MainBeat").Play();
            GetNode<AudioStreamPlayer>("../IdleTheme").Stop();
        }
    }
    //-----------------------------------------------------------------------------
    private void OnGamepad1PerformerSelected(string performer)
    {
        GetNode<Label>("Header/Gamepad1/Gamepad1Peformer").Text = "Player 1 : " + performer;
    }

    private void OnGamepad2PerformerSelected(string performer)
    {
        GetNode<Label>("Header/Gamepad2/Gamepad2Peformer").Text = "Player 2 : " + performer;
    }
    //-----------------------------------------------------------------------------
    private void OnIsGameReadyToPlay(bool isGameReadyToPlay)
    {
        _isGameReadyToPlay = isGameReadyToPlay;
        if (_isGameReadyToPlay)
        {
            GetNode<Label>("Footer/PressToStart").Show();
        }
        else
        {
            GetNode<Label>("Footer/PressToStart").Hide();
        }
    }
    //-----------------------------------------------------------------------------
    private void OnBattleEnded()
    {
        _isGameStarted = false;
        GetNode<Label>("Header/GameTitle").Show();
    }
    //-----------------------------------------------------------------------------
    private void OnUpdateScore(string performer1, string performer2)
    {
        GetNode<Label>("Header/Gamepad1/Score").Text = performer1;
        GetNode<Label>("Header/Gamepad2/Score").Text = performer2;
    }
}
