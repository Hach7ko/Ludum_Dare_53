using Godot;

public partial class HUD : Control
{
    [Signal]
    public delegate void CountdownReachedZeroEventHandler();
    [Signal]
    public delegate void GameStartedEventHandler();
    private bool _isGameReadyToPlay = false;
    private int  _countdown = 3;
    private bool _isGameStarted = false;
    public override void _Input(InputEvent inputEvent)
    {
        if (inputEvent.IsActionPressed("confirm") && _isGameReadyToPlay && !_isGameStarted)
        {
            EmitSignal(nameof(GameStarted));
            _isGameStarted = true;
            GetNode<Label>("Countdown").Show();
            GetNode<Timer>("CountdownToStart").Start();
            GetNode<Node2D>("../PerformerSelection").Hide();
        }
    }
//-----------------------------------------------------------------------------
    public void OnCountdownToStartTimeout()
    {
        --_countdown;
        GetNode<Label>("Countdown").Text = _countdown.ToString();
        if (_countdown == 0)
        {
            GetNode<Timer>("CountdownToStart").Stop();
            GetNode<Label>("Countdown").Hide();
            EmitSignal(nameof(CountdownReachedZero));
        }
    }
//-----------------------------------------------------------------------------
	private void OnGamepad1PerformerSelected(string performer)
    {
        GetNode<Label>("Gamepad1Peformer").Text = "Gamepad1 will play:" + performer;
    }

    private void OnGamepad2PerformerSelected(string performer)
    {
        GetNode<Label>("Gamepad2Peformer").Text = "Gamepad2 will play:" + performer;
    }
//-----------------------------------------------------------------------------
    private void OnIsGameReadyToPlay(bool isGameReadyToPlay)
    {
        _isGameReadyToPlay = isGameReadyToPlay;
        if (_isGameReadyToPlay)
        {
            GetNode<Label>("PressToStart").Show();
        } else
        {
            GetNode<Label>("PressToStart").Hide();
        }
    }
}
