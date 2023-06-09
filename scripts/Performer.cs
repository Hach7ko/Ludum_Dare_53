using Godot;
using System;

public partial class Performer
{
    private Track _track = null;
    private int _currentVerse = 0;
    private int _currentLine = 0;
    public int Score { get; set; }
    public bool IsTrackOver { get; private set; }

//-----------------------------------------------------------------------------
    public Performer(Track track)
    {
        _track = track;
        Score = 0;
    }

//-----------------------------------------------------------------------------
    public Line GetCurrentLine()
    {
        return _track.Verses[_currentVerse].Lines[_currentLine];
    }

//-----------------------------------------------------------------------------
    public void GoToNextLine()
    {
        _currentLine = (_currentLine + 1) % _track.Verses[_currentVerse].Lines.Length;

        if (_currentLine == 0) // we looped
        {
            _currentVerse = (_currentVerse + 1) % _track.Verses.Length;

            if (_currentVerse == 0)
            {
                IsTrackOver = true;
            }
        }
    }

//-----------------------------------------------------------------------------
    public void RestartTrack()
    {
        _currentLine = 0;
        _currentVerse = 0;
        IsTrackOver = false;
    }

//-----------------------------------------------------------------------------
    public void PrintTrack()
    {
        string trackStr = new string("");

        foreach (Verse verse in _track.Verses)
        {
            foreach (Line line in verse.Lines)
            {
                trackStr += line.Phrase + " { ";

                foreach (Punch punch in line.Punches)
                {
                    trackStr += punch.Word + ":" + punch.Weight + ", ";
                }
                trackStr += "}";

                GD.Print(trackStr);
            }
        }
    }
}
