using Godot;
using System;

static public partial class StaticTools
{
    static public int nimod(float a, float b)
    {
        return  (int)(a - b * Math.Floor(a / b));
    }
}

public partial class BattleOrchestrator : Control
{
    // LOGIC
    private const int BPM = 120;
    private const int BASE_DROP_TIME_MS = 5000;
    private const string PUNCH_MARK = "_X_";

    private RandomNumberGenerator rd = new RandomNumberGenerator();
    private Performer[] _performers = new Performer[2];
    private int _currentPerformerIdx = -1;
    private int _currentLineIdx = -1;
    private int _currentLineLength = 0;
    private int _currentPunchIdx = -1;
    private ulong _dropStartTimeMs = 0;

    // GUI
    private VBoxContainer _incomingPunchCtrl = null;
    private VBoxContainer _incomingPhraseCtrl = null;
    private VBoxContainer _verseCtrl = null;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        rd.Seed = (ulong)Time.GetUnixTimeFromSystem();

        _performers[0] = new Performer(TrackFactory.GetTrack1());
        _performers[1] = new Performer(TrackFactory.GetTrack2());

        foreach (Performer p in _performers)
        {
            p.PrintTrack();
        }

        _incomingPunchCtrl = GetNode<VBoxContainer>("DropZone/IncomingPunch");
        _incomingPhraseCtrl = GetNode<VBoxContainer>("DropZone/IncomingPhrase");
        _verseCtrl = GetNode<VBoxContainer>("Verse");

        Reset();
        Start();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        if (_currentPerformerIdx == 0)
        {
            ProcessInput("left_player1", "right_player1");
        }
        else if (_currentPerformerIdx == 1)
        {
            ProcessInput("left_player2", "right_player2");
        }

        UpdateDropZone();
    }

    private void ProcessInput(string leftEvtName, string rightEvtName)
    {
        if (Input.IsActionJustReleased(leftEvtName))
        {
            _currentPunchIdx = StaticTools.nimod((float)_currentPunchIdx - 1.0f, _performers[_currentPerformerIdx].GetCurrentLine().Punches.Length);
        }
        else if (Input.IsActionJustReleased(rightEvtName))
        {
            _currentPunchIdx = StaticTools.nimod((float)_currentPunchIdx + 1.0f, _performers[_currentPerformerIdx].GetCurrentLine().Punches.Length);
        }
    }

    private void Reset()
    {
        _incomingPunchCtrl.GetNode<Label>("Label").Text = "";
        _incomingPhraseCtrl.GetNode<Label>("Label").Text = "";
        _verseCtrl.GetNode<Label>("0").Text = "";
        _verseCtrl.GetNode<Label>("1").Text = "";
        _verseCtrl.GetNode<Label>("2").Text = "";
        _verseCtrl.GetNode<Label>("3").Text = "";
    }

    private void Start()
    {
        _currentPerformerIdx = 0;
        _currentLineIdx = 0;

        SetDropZone(_performers[_currentPerformerIdx].GetCurrentLine());
    }

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

            _incomingPhraseCtrl.GetNode<Label>("Label").Text = line.Phrase.ReplaceN(PUNCH_MARK, voidStr);
        }

        _dropStartTimeMs = Time.GetTicksMsec();

        _verseCtrl.GetNode<Label>(_currentLineIdx.ToString()).Text = "...";

        UpdateDropZone();
    }

    private void UpdateDropZone()
    {
        if (true) // isTextDirty
        {
            Line line = _performers[_currentPerformerIdx].GetCurrentLine();

            string punchStr = line.Punches[_currentPunchIdx].Word;
            int wordIdx = line.Phrase.Find(PUNCH_MARK);
            string paddedPunchStr = punchStr.PadLeft(wordIdx + punchStr.Length + ((_currentLineLength - line.Phrase.Length - punchStr.Length) / 2) + 1);

            paddedPunchStr = paddedPunchStr.PadRight(_currentLineLength);

            _incomingPunchCtrl.GetNode<Label>("Label").Text = paddedPunchStr;
        }

        ulong currentTimeMs = Time.GetTicksMsec();
        ulong elapsedTimeMs = currentTimeMs - _dropStartTimeMs;
        float elapsedRatio = (float)elapsedTimeMs / (float)BASE_DROP_TIME_MS;

        _incomingPunchCtrl.Position = new Vector2(0, _incomingPhraseCtrl.Position.Y * elapsedRatio);

        if (elapsedRatio >= 1.0f)
        {
            FinalizeDrop();
        }
    }

    private void FinalizeDrop()
    {
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

        SetDropZone(_performers[_currentPerformerIdx].GetCurrentLine());
    }
}
