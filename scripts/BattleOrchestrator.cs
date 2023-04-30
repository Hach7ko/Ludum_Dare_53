using Godot;
using System;

static public partial class StaticTools
{
    static public int nimod(float a, float b)
    {
        return (int)(a - b * Math.Floor(a / b));
    }
}

public partial class BattleOrchestrator : Control
{
    // SIGNAL
    [Signal]
    public delegate void BattleEndedEventHandler();
    [Signal]
    public delegate void UpdateScoreEventHandler(string performer1, string performer2);
    // LOGIC
    private const int BPM = 120;
    private const int BASE_DROP_TIME_MS = 5000;
    private const string PUNCH_MARK = "_X_";

    private bool _isStarted = false;
    private RandomNumberGenerator rd = new RandomNumberGenerator();
    private Performer[] _performers = new Performer[2];
    private int _currentPerformerIdx = -1;
    private int _currentLineIdx = -1;
    private int _currentLineLength = 0;
    private int _currentPunchIdx = -1;
    private bool _punchIsDirty = false;
    private ulong _dropStartTimeMs = 0;

    // GUI
    private Label _incomingPunchLabel = null;
    private Label _incomingPhraseLabel = null;
    private VBoxContainer _verseCtrl = null;
    private SelectPerformer _playerManager = null;

    //-----------------------------------------------------------------------------
    public override void _Ready()
    {
        rd.Seed = (ulong)Time.GetUnixTimeFromSystem();

        _performers[0] = new Performer(TrackFactory.GetTrack1());
        _performers[1] = new Performer(TrackFactory.GetTrack2());

        _incomingPunchLabel = GetNode<Label>("IncomingPunch");
        _incomingPhraseLabel = GetNode<Label>("IncomingPhrase");
        _verseCtrl = GetNode<VBoxContainer>("Verse");
        _playerManager = GetNode<SelectPerformer>("/root/MainNode/PerformerSelection");

        Reset();
    }

    //-----------------------------------------------------------------------------
    public override void _Process(double delta)
    {
        if (!_isStarted)
            return;

        // gamepad index is [1-2]
        if (_currentPerformerIdx == 0 && !_playerManager.IsGamepadCPUBound(1))
        {
            ProcessInput("left_gamepad1", "right_gamepad1");
        }
        else if (_currentPerformerIdx == 1 && !_playerManager.IsGamepadCPUBound(2))
        {
            ProcessInput("left_gamepad2", "right_gamepad2");
        }

        UpdateDropZone();
    }

    //-----------------------------------------------------------------------------
    public string GetScoreForPlayer(uint playerIdx)
    {
        GD.Print(playerIdx);
        if (playerIdx != 1 && playerIdx != 2)
        {
            GD.PrintErr("playerIdx should be in [1-2]");
            return null;
        }

        return _performers[playerIdx - 1].Score.ToString();
    }

    //-----------------------------------------------------------------------------
    private void ProcessInput(string leftEvtName, string rightEvtName)
    {
        if (Input.IsActionJustReleased(leftEvtName))
        {
            GetNode<AudioStreamPlayer>("ScribbleRoulyo").Play();
            _currentPunchIdx = StaticTools.nimod((float)_currentPunchIdx - 1.0f, _performers[_currentPerformerIdx].GetCurrentLine().Punches.Length);
            _punchIsDirty = true;
        }
        else if (Input.IsActionJustReleased(rightEvtName))
        {
            GetNode<AudioStreamPlayer>("ScribbleSamoussa").Play();
            _currentPunchIdx = StaticTools.nimod((float)_currentPunchIdx + 1.0f, _performers[_currentPerformerIdx].GetCurrentLine().Punches.Length);
            _punchIsDirty = true;
        }
    }

    //-----------------------------------------------------------------------------
    private void Reset()
    {
        _performers[0].Score = 0;
        _performers[1].Score = 0;

        _incomingPunchLabel.Text = "";
        _incomingPhraseLabel.Text = "";
        _verseCtrl.GetNode<Label>("0").Text = "";
        _verseCtrl.GetNode<Label>("1").Text = "";
        _verseCtrl.GetNode<Label>("2").Text = "";
        _verseCtrl.GetNode<Label>("3").Text = "";
    }

    //-----------------------------------------------------------------------------
    private void Start()
    {
        _isStarted = true;
        _currentPerformerIdx = 0;
        _currentLineIdx = 0;

        SetDropZone(_performers[_currentPerformerIdx].GetCurrentLine());

        Show();
    }

    //-----------------------------------------------------------------------------
    private void SetDropZone(Line line)
    {
        _currentPunchIdx = rd.RandiRange(0, _performers[_currentPerformerIdx].GetCurrentLine().Punches.Length - 1);

        // Line setup
        {
            int maxPunchLength = 0;

            foreach (Punch punch in line.Punches)
            {
                maxPunchLength = Math.Max(punch.Word.Length, maxPunchLength);
            }

            string voidStr = new String("");
            voidStr = voidStr.PadLeft(maxPunchLength);

            _currentLineLength = line.Phrase.Length + maxPunchLength - PUNCH_MARK.Length;

            _incomingPhraseLabel.Text = line.Phrase.ReplaceN(PUNCH_MARK, voidStr.Replace(" ", "."));
        }

        _dropStartTimeMs = Time.GetTicksMsec();

        _verseCtrl.GetNode<Label>(_currentLineIdx.ToString()).Text = "...";

        _punchIsDirty = true;

        UpdateDropZone();
    }

    //-----------------------------------------------------------------------------
    private void UpdateDropZone()
    {
        if (_punchIsDirty) // isTextDirty
        {
            Line line = _performers[_currentPerformerIdx].GetCurrentLine();

            string punchStr = line.Punches[_currentPunchIdx].Word;
            int wordIdx = line.Phrase.Find(PUNCH_MARK);
            string paddedPunchStr = punchStr.PadLeft(wordIdx + punchStr.Length + ((_currentLineLength - line.Phrase.Length - punchStr.Length) / 2) + 1);

            paddedPunchStr = paddedPunchStr.PadRight(_currentLineLength);

            _incomingPunchLabel.Text = paddedPunchStr.Replace(" ", ".");

            _punchIsDirty = false;
        }

        float dropTimeMs = BASE_DROP_TIME_MS;

        if (_playerManager.IsGamepadCPUBound(_currentPerformerIdx + 1))
        {
            dropTimeMs /= 2.0f;
        }

        ulong currentTimeMs = Time.GetTicksMsec();
        ulong elapsedTimeMs = currentTimeMs - _dropStartTimeMs;
        float elapsedRatio = (float)elapsedTimeMs / dropTimeMs;

        _incomingPunchLabel.Position = new Vector2(_incomingPunchLabel.Position.X, _incomingPhraseLabel.Position.Y * elapsedRatio);

        if (elapsedRatio >= 1.0f)
        {
            FinalizeDrop();
        }
    }

    //-----------------------------------------------------------------------------
    private void FinalizeDrop()
    {
        int weight = _performers[_currentPerformerIdx].GetCurrentLine().Punches[_currentPunchIdx].Weight;
        _performers[_currentPerformerIdx].Score += weight;
        PlayScoreSound(weight);
        EmitSignal(nameof(UpdateScore), GetScoreForPlayer(1), GetScoreForPlayer(2));
        string lineStr = _performers[_currentPerformerIdx].GetCurrentLine().Phrase;
        lineStr = lineStr.ReplaceN(PUNCH_MARK, _performers[_currentPerformerIdx].GetCurrentLine().Punches[_currentPunchIdx].Word);

        _verseCtrl.GetNode<Label>(_currentLineIdx.ToString()).Text = lineStr;
        _currentLineIdx = StaticTools.nimod(_currentLineIdx + 1, 4);

        if (_currentLineIdx == 0) // we looped
        {
            _currentPerformerIdx = StaticTools.nimod(_currentPerformerIdx + 1, 2);
            Reset();
        }
        else
        {
            _performers[_currentPerformerIdx].GoToNextLine();
        }

        if (_performers[0].IsTrackOver && _performers[1].IsTrackOver)
        {
            EmitSignal(nameof(BattleEnded));
        }
        else
        {
            SetDropZone(_performers[_currentPerformerIdx].GetCurrentLine());
        }
    }

    //-----------------------------------------------------------------------------
    private void OnCountdownReachedZero()
    {
        Start();
    }
    //-----------------------------------------------------------------------------
    private void PlayScoreSound(int weight)
    {
        switch (weight)
        {
            case 0:
                GetNode<AudioStreamPlayer>("Boo").Play();
                break;
            case 1:
                GetNode<AudioStreamPlayer>("Clapping").Play();
                break;
            case 2:
                GetNode<AudioStreamPlayer>("Yeah").Play();
                break;
        }
    }
}
