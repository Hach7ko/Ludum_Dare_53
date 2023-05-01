using Godot;
using System;

public class Punch
{
    public string Word {get; set; }
    public int Weight { get; set; }
}

public class Line
{
    public string Phrase { get; set; }
    public Punch[] Punches { get; set; }
}

public class Verse
{
    public Line[] Lines { get; set; }
}

public class Track
{
    public Verse[] Verses { get; set; }
}

public class TrackFactory
{
    static private Track _track1 = null;
    static private Track _track2 = null;

//-----------------------------------------------------------------------------
    static public Track GetTrack1()
    {
        if (_track1 != null)
            return _track1;

        _track1 = new Track();
        _track1.Verses = new Verse[]
        {
            new Verse
            {
                Lines = new Line[]
                {
                    new Line
                    {
                        Phrase = "Non non, bof bof, tu _X_",
                        Punches = new Punch[]
                        {
                            new Punch { Word = "pues", Weight = 0 },
                            new Punch { Word = "fouettes", Weight = 1 },
                            new Punch { Word = "prends ton cul pour une trompette", Weight = 2 },
                        }
                    },
                    new Line
                    {
                        Phrase = "Ouais ouais, si si, la _X_",
                        Punches = new Punch[]
                        {
                            new Punch { Word = "girafe", Weight = 0 },
                            new Punch { Word = "pizza", Weight = 1 },
                            new Punch { Word = "famille", Weight = 2 },
                        }
                    },
                    new Line
                    {
                        Phrase = "Non non, bof bof, tu _X_",
                        Punches = new Punch[]
                        {
                            new Punch { Word = "pues", Weight = 0 },
                            new Punch { Word = "fouettes", Weight = 1 },
                            new Punch { Word = "prends ton cul pour une trompette", Weight = 2 },
                        }
                    },
                    new Line
                    {
                        Phrase = "Ouais ouais, si si, la _X_",
                        Punches = new Punch[]
                        {
                            new Punch { Word = "girafe", Weight = 0 },
                            new Punch { Word = "pizza", Weight = 1 },
                            new Punch { Word = "famille", Weight = 2 },
                        }
                    },
                }
            },
            new Verse
            {
                Lines = new Line[]
                {
                    new Line
                    {
                        Phrase = "Non non, bof bof, tu _X_",
                        Punches = new Punch[]
                        {
                            new Punch { Word = "pues", Weight = 0 },
                            new Punch { Word = "fouettes", Weight = 1 },
                            new Punch { Word = "prends ton cul pour une trompette", Weight = 2 },
                        }
                    },
                    new Line
                    {
                        Phrase = "Ouais ouais, si si, la _X_",
                        Punches = new Punch[]
                        {
                            new Punch { Word = "girafe", Weight = 0 },
                            new Punch { Word = "pizza", Weight = 1 },
                            new Punch { Word = "famille", Weight = 2 },
                        }
                    },
                    new Line
                    {
                        Phrase = "Non non, bof bof, tu _X_",
                        Punches = new Punch[]
                        {
                            new Punch { Word = "pues", Weight = 0 },
                            new Punch { Word = "fouettes", Weight = 1 },
                            new Punch { Word = "prends ton cul pour une trompette", Weight = 2 },
                        }
                    },
                    new Line
                    {
                        Phrase = "Ouais ouais, si si, la _X_",
                        Punches = new Punch[]
                        {
                            new Punch { Word = "girafe", Weight = 0 },
                            new Punch { Word = "pizza", Weight = 1 },
                            new Punch { Word = "famille", Weight = 2 },
                        }
                    },
                }
            },
            new Verse
            {
                Lines = new Line[]
                {
                    new Line
                    {
                        Phrase = "Non non, bof bof, tu _X_",
                        Punches = new Punch[]
                        {
                            new Punch { Word = "pues", Weight = 0 },
                            new Punch { Word = "fouettes", Weight = 1 },
                            new Punch { Word = "prends ton cul pour une trompette", Weight = 2 },
                        }
                    },
                    new Line
                    {
                        Phrase = "Ouais ouais, si si, la _X_",
                        Punches = new Punch[]
                        {
                            new Punch { Word = "girafe", Weight = 0 },
                            new Punch { Word = "pizza", Weight = 1 },
                            new Punch { Word = "famille", Weight = 2 },
                        }
                    },
                    new Line
                    {
                        Phrase = "Non non, bof bof, tu _X_",
                        Punches = new Punch[]
                        {
                            new Punch { Word = "pues", Weight = 0 },
                            new Punch { Word = "fouettes", Weight = 1 },
                            new Punch { Word = "prends ton cul pour une trompette", Weight = 2 },
                        }
                    },
                    new Line
                    {
                        Phrase = "Ouais ouais, si si, la _X_",
                        Punches = new Punch[]
                        {
                            new Punch { Word = "girafe", Weight = 0 },
                            new Punch { Word = "pizza", Weight = 1 },
                            new Punch { Word = "famille", Weight = 2 },
                        }
                    },
                }
            },
        };

        return _track1;
    }

//-----------------------------------------------------------------------------
    static public Track GetTrack2()
    {
        if (_track2 != null)
            return _track2;

        _track2 = new Track();
        _track2.Verses = new Verse[]
        {
            new Verse
            {
                Lines = new Line[]
                {
                    new Line
                    {
                        Phrase = "Non non, bof bof, tu _X_",
                        Punches = new Punch[]
                        {
                            new Punch { Word = "pues", Weight = 0 },
                            new Punch { Word = "fouettes", Weight = 1 },
                            new Punch { Word = "prends ton cul pour une trompette", Weight = 2 },
                        }
                    },
                    new Line
                    {
                        Phrase = "Ouais ouais, si si, la _X_",
                        Punches = new Punch[]
                        {
                            new Punch { Word = "girafe", Weight = 0 },
                            new Punch { Word = "pizza", Weight = 1 },
                            new Punch { Word = "famille", Weight = 2 },
                        }
                    },
                    new Line
                    {
                        Phrase = "Non non, bof bof, tu _X_",
                        Punches = new Punch[]
                        {
                            new Punch { Word = "pues", Weight = 0 },
                            new Punch { Word = "fouettes", Weight = 1 },
                            new Punch { Word = "prends ton cul pour une trompette", Weight = 2 },
                        }
                    },
                    new Line
                    {
                        Phrase = "Ouais ouais, si si, la _X_",
                        Punches = new Punch[]
                        {
                            new Punch { Word = "girafe", Weight = 0 },
                            new Punch { Word = "pizza", Weight = 1 },
                            new Punch { Word = "famille", Weight = 2 },
                        }
                    },
                }
            },
            new Verse
            {
                Lines = new Line[]
                {
                    new Line
                    {
                        Phrase = "Non non, bof bof, tu _X_",
                        Punches = new Punch[]
                        {
                            new Punch { Word = "pues", Weight = 0 },
                            new Punch { Word = "fouettes", Weight = 1 },
                            new Punch { Word = "prends ton cul pour une trompette", Weight = 2 },
                        }
                    },
                    new Line
                    {
                        Phrase = "Ouais ouais, si si, la _X_",
                        Punches = new Punch[]
                        {
                            new Punch { Word = "girafe", Weight = 0 },
                            new Punch { Word = "pizza", Weight = 1 },
                            new Punch { Word = "famille", Weight = 2 },
                        }
                    },
                    new Line
                    {
                        Phrase = "Non non, bof bof, tu _X_",
                        Punches = new Punch[]
                        {
                            new Punch { Word = "pues", Weight = 0 },
                            new Punch { Word = "fouettes", Weight = 1 },
                            new Punch { Word = "prends ton cul pour une trompette", Weight = 2 },
                        }
                    },
                    new Line
                    {
                        Phrase = "Ouais ouais, si si, la _X_",
                        Punches = new Punch[]
                        {
                            new Punch { Word = "girafe", Weight = 0 },
                            new Punch { Word = "pizza", Weight = 1 },
                            new Punch { Word = "famille", Weight = 2 },
                        }
                    },
                }
            },
            new Verse
            {
                Lines = new Line[]
                {
                    new Line
                    {
                        Phrase = "Non non, bof bof, tu _X_",
                        Punches = new Punch[]
                        {
                            new Punch { Word = "pues", Weight = 0 },
                            new Punch { Word = "fouettes", Weight = 1 },
                            new Punch { Word = "prends ton cul pour une trompette", Weight = 2 },
                        }
                    },
                    new Line
                    {
                        Phrase = "Ouais ouais, si si, la _X_",
                        Punches = new Punch[]
                        {
                            new Punch { Word = "girafe", Weight = 0 },
                            new Punch { Word = "pizza", Weight = 1 },
                            new Punch { Word = "famille", Weight = 2 },
                        }
                    },
                    new Line
                    {
                        Phrase = "Non non, bof bof, tu _X_",
                        Punches = new Punch[]
                        {
                            new Punch { Word = "pues", Weight = 0 },
                            new Punch { Word = "fouettes", Weight = 1 },
                            new Punch { Word = "prends ton cul pour une trompette", Weight = 2 },
                        }
                    },
                    new Line
                    {
                        Phrase = "Ouais ouais, si si, la _X_",
                        Punches = new Punch[]
                        {
                            new Punch { Word = "girafe", Weight = 0 },
                            new Punch { Word = "pizza", Weight = 1 },
                            new Punch { Word = "famille", Weight = 2 },
                        }
                    },
                }
            },
        };

        return _track2;
    }
}
