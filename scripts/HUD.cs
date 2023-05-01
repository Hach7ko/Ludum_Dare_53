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
        _battleOrchestrator = GetNode<BattleOrchestrator>("Main/Middle/BattleOrchestrator");

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
            GetNode<Label>("Footer/RoulyoScore").Show();
            GetNode<Label>("Footer/SamoussaScore").Show();
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
        GetNode<Label>("GameTitle").Hide();

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
        GetNode<Label>("GameTitle").Show();
        GetNode<VBoxContainer>("Main/Middle/EndGameButton").Show();
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
            GetNode<Label>("RoulyoVictoryOrDefeat").Text = "Winner!";
            GetNode<Label>("SamoussaVictoryOrDefeat").Text = "Winner!";
        }
        else if (roulyoScore > samoussaScore)
        {
            _roulyoSprite.Play("victory");
            _samoussaSprite.Play("loss");
            GetNode<Label>("RoulyoVictoryOrDefeat").Text = "Winner!";
            GetNode<Label>("SamoussaVictoryOrDefeat").Text = "Loser!";
        }
        else if (roulyoScore < samoussaScore)
        {
            _roulyoSprite.Play("loss");
            _samoussaSprite.Play("victory");
            GetNode<Label>("RoulyoVictoryOrDefeat").Text = "Loser!";
            GetNode<Label>("SamoussaVictoryOrDefeat").Text = "Winner!";
        }

        GetNode<Label>("RoulyoVictoryOrDefeat").Show();
        GetNode<Label>("SamoussaVictoryOrDefeat").Show();
    }

    //-----------------------------------------------------------------------------
    private void OnUpdateScore(string roulyoScore, string samoussaScore)
    {
        GetNode<Label>("Footer/RoulyoScore").Text = "Score:" + roulyoScore;
        GetNode<Label>("Footer/SamoussaScore").Text = "Score:" + samoussaScore;
    }

    //-----------------------------------------------------------------------------
    private void OnRetryPressed()
    {
        _isGameReadyToPlay = true;
        GetNode<VBoxContainer>("Main/Middle/EndGameButton").Hide();
        GetNode<Label>("RoulyoVictoryOrDefeat").Hide();
        GetNode<Label>("SamoussaVictoryOrDefeat").Hide();
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
