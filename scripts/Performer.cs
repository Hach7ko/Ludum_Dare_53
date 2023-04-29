using Godot;
using System;

public class WeightedWord
{
    public string Word {get; set; }
    public uint Weight { get; set; }
}

public class Line
{
    public string Phrase { get; set; }
    public WeightedWord[] Punches { get; set; }
}

public class Verse
{
    public Line[] Lines { get; set; }
}

public class Track
{
    public Verse[] Verses { get; set; }
}

public partial class Performer : Node
{
    protected Track _track;
    private uint _currentLine = 0;
    private uint _currentVerse = 0;

    public override void _Ready()
    {
        _track = new Track();
    }

    public Line GetNextLine()
    {
        return _track.Verses[_currentVerse].Lines[_currentLine];
    }

    protected void PrintTrack()
    {
        string trackStr = new string("");

        foreach (Verse verse in _track.Verses)
        {
            foreach (Line line in verse.Lines)
            {
                trackStr += line.Phrase + " { ";

                foreach (WeightedWord punch in line.Punches)
                {
                    trackStr += punch.Word + ":" + punch.Weight + ", ";
                }
                trackStr += "}";

                GD.Print(trackStr);
            }
        }
    }
}
