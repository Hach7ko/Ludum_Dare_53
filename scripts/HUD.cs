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
    private SelectPerformer _playerManager = null;
    private BattleOrchestrator _battleOrchestrator = null;


    //-----------------------------------------------------------------------------
    public override void _Ready()
    {
        GetNode<AudioStreamPlayer>("../IdleTheme").Play();

        _playerManager = GetNode<SelectPerformer>("/root/MainNode/PerformerSelection");
        _battleOrchestrator = GetNode<BattleOrchestrator>("Main/Control/Middle/BattleOrchestrator");

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
        GetNode<Label>("Main/Control/Middle/Countdown").Text = _countdown.ToString();
        if (_countdown == 0)
        {
            _isGameReadyToPlay = false;
            GetNode<Timer>("Main/Control/Middle/CountdownToStart").Stop();
            GetNode<Label>("Main/Control/Middle/Countdown").Hide();
            EmitSignal(nameof(CountdownReachedZero));
            GetNode<AudioStreamPlayer>("../MainBeat").Play();
            GetNode<AudioStreamPlayer>("../IdleTheme").Stop();
            GetNode<Label>("Footer/RoulyoScore").Show();
            GetNode<Label>("Footer/SamoussaScore").Show();
        }
    }
    //-----------------------------------------------------------------------------
    private void StartGame()
    {
        EmitSignal(nameof(GameStarted));
        _isGameStarted = true;

        GetNode<Label>("Main/Control/Middle/Countdown").Show();
        GetNode<Timer>("Main/Control/Middle/CountdownToStart").Start();
        GetNode<AudioStreamPlayer>("../Countdown").Play();

        GetNode<Control>("../PerformerSelection").Hide();

        GetNode<Label>("Footer/PressToStart").Hide();
        GetNode<Label>("Header/GameTitle").Hide();

        GetNode<Label>("Main/Left/Performer/RoulyoNameTag").Hide();
        GetNode<Label>("Main/Right/Performer/SamoussaNameTag").Hide();

        _roulyoSprite.Play("taunt");
        _samoussaSprite.Play("taunt");
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
        GetNode<VBoxContainer>("Main/Control/Middle/EndGameButton").Show();
        GetNode<AudioStreamPlayer>("../IdleTheme").Play();
        GetNode<AudioStreamPlayer>("../MainBeat").Stop();
        DisplayWinner();

    }
    //-----------------------------------------------------------------------------
    private void DisplayWinner()
    {
        int roulyoScore = _battleOrchestrator.GetScoreForPerformer(0).ToInt();
        int samoussaScore = _battleOrchestrator.GetScoreForPerformer(1).ToInt();

        if (roulyoScore == samoussaScore)
        {
            _roulyoSprite.Play("victory");
            _samoussaSprite.Play("victory");
            GetNode<Label>("Header/VictoryOrDefeat/RoulyoVictoryOrDefeat").Text = "Winner!";
            GetNode<Label>("Header/VictoryOrDefeat/SamoussaVictoryOrDefeat").Text = "Winner!";
        }
        else if (roulyoScore > samoussaScore)
        {
            _roulyoSprite.Play("victory");
            _samoussaSprite.Play("loss");
            GetNode<Label>("Header/VictoryOrDefeat/RoulyoVictoryOrDefeat").Text = "Winner!";
            GetNode<Label>("Header/VictoryOrDefeat/SamoussaVictoryOrDefeat").Text = "Loser!";
        }
        else if (roulyoScore < samoussaScore)
        {
            _roulyoSprite.Play("loss");
            _samoussaSprite.Play("victory");
            GetNode<Label>("Header/VictoryOrDefeat/RoulyoVictoryOrDefeat").Text = "Loser!";
            GetNode<Label>("Header/VictoryOrDefeat/SamoussaVictoryOrDefeat").Text = "Winner!";
        }

        GetNode<Label>("Header/VictoryOrDefeat/RoulyoVictoryOrDefeat").Show();
        GetNode<Label>("Header/VictoryOrDefeat/SamoussaVictoryOrDefeat").Show();
    }

    //-----------------------------------------------------------------------------
    private void OnUpdateScore(string roulyoScore, string samoussaScore)
    {
        GetNode<Label>("Footer/RoulyoScore").Text = "Score: " + roulyoScore;
        GetNode<Label>("Footer/SamoussaScore").Text = "Score: " + samoussaScore;
    }

    //-----------------------------------------------------------------------------
    private void OnRetryPressed()
    {
        _isGameReadyToPlay = true;
        GetNode<VBoxContainer>("Main/Control/Middle/EndGameButton").Hide();
        GetNode<Label>("Header/VictoryOrDefeat/RoulyoVictoryOrDefeat").Hide();
        GetNode<Label>("Header/VictoryOrDefeat/SamoussaVictoryOrDefeat").Hide();
        _countdown = COUTDOWN;
        GetNode<Label>("Main/Control/Middle/Countdown").Text = _countdown.ToString();
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
