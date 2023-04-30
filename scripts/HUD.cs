using Godot;

public partial class HUD : Control
{
    [Signal]
    public delegate void CountdownReachedZeroEventHandler();
    [Signal]
    public delegate void GameStartedEventHandler();
    private const int COUTDOWN = 3; //seconds
    private bool _isGameReadyToPlay = false;
    private int _countdown = COUTDOWN;
    private bool _isGameStarted = false;
    private AnimatedSprite2D _roulyoSprite;
    private AnimatedSprite2D _samoussaSprite;


    //-----------------------------------------------------------------------------
    public override void _Ready()
    {
        GetNode<AudioStreamPlayer>("../IdleTheme").Play();

        _roulyoSprite = GetNode<AnimatedSprite2D>("Main/Left/Performer/Roulyo/AnimatedSprite2D");
        _roulyoSprite.Play("idle");

        _samoussaSprite = GetNode<AnimatedSprite2D>("Main/Right/Performer/Samoussa/AnimatedSprite2D");
        _samoussaSprite.Play("idle");
    }
    //-----------------------------------------------------------------------------
    public override void _Input(InputEvent inputEvent)
    {
        if (inputEvent.IsActionPressed("confirm") && _isGameReadyToPlay && !_isGameStarted)
        {
            StartGame();
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
    private void StartGame()
    {
        EmitSignal(nameof(GameStarted));
        _isGameStarted = true;

        GetNode<Label>("Main/Middle/Countdown").Show();
        GetNode<Timer>("Main/Middle/CountdownToStart").Start();
        GetNode<AudioStreamPlayer>("../Countdown").Play();

        GetNode<Node2D>("../PerformerSelection").Hide();

        GetNode<Label>("Footer/PressToStart").Hide();
        GetNode<Label>("Header/GameTitle").Hide();

        _roulyoSprite.Play("taunt");
        _samoussaSprite.Play("taunt");
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
            GetNode<AnimationPlayer>("../AnimationPlayer").Play("press_start_blinking");
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
        GetNode<VBoxContainer>("Main/Middle/EndGameButton").Show();
        GetNode<AudioStreamPlayer>("../IdleTheme").Play();
        GetNode<AudioStreamPlayer>("../MainBeat").Stop();
        DisplayWinner();

    }
    //-----------------------------------------------------------------------------
    private void DisplayWinner()
    {
        int winner = 0;
        //TODO: FIX weird results sometimes
        switch (winner)
        {
            case 0:
                _roulyoSprite.Play("victory");
                _samoussaSprite.Play("victory");
                GetNode<Label>("Main/Left/VictoryOrDefeat").Text = "Winner!";
                GetNode<Label>("Main/Right/VictoryOrDefeat").Text = "Winner!";
                break;
            case 1:
                _roulyoSprite.Play("loss");
                _samoussaSprite.Play("victory");
                GetNode<Label>("Main/Left/VictoryOrDefeat").Text = "Loser!";
                GetNode<Label>("Main/Right/VictoryOrDefeat").Text = "Winner!";
                break;
            case 2:
                _roulyoSprite.Play("victory");
                _samoussaSprite.Play("loss");
                GetNode<Label>("Main/Left/VictoryOrDefeat").Text = "Winner!";
                GetNode<Label>("Main/Right/VictoryOrDefeat").Text = "Loser!";
                break;

        }

        GetNode<Label>("Main/Left/VictoryOrDefeat").Show();
        GetNode<Label>("Main/Right/VictoryOrDefeat").Show();
    }
    //-----------------------------------------------------------------------------
    private void OnUpdateScore(string performer1, string performer2)
    {
        GetNode<Label>("Header/Gamepad1/Score").Text = performer1;
        GetNode<Label>("Header/Gamepad2/Score").Text = performer2;
    }
    //-----------------------------------------------------------------------------
    private void OnRetryPressed()
    {
        _isGameReadyToPlay = true;
        GetNode<VBoxContainer>("Main/Middle/EndGameButton").Hide();
        GetNode<Label>("Main/Left/Performer/VictoryOrDefeat").Hide();
        GetNode<Label>("Main/Right/Performer/VictoryOrDefeat").Hide();
        _countdown = COUTDOWN;
        GetNode<Label>("Main/Middle/Countdown").Text = _countdown.ToString();
        StartGame();
    }
    //-----------------------------------------------------------------------------
    private void OnSelectPerformerPressed()
    {
        GetTree().ReloadCurrentScene();
    }
    //-----------------------------------------------------------------------------
    private void OnQuitPressed()
    {
        GetTree().Quit();
    }
}
