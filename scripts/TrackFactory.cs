using Godot;
using System;

public class Punch
{
    public string Word { get; set; }
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
                        Phrase = "Oh, yeah you may think I'm _X_",
                        Punches = new Punch[]
                        {
                            new Punch { Word = "not tall", Weight = 0 },
                            new Punch { Word = "minimoi", Weight = 1 },
                            new Punch { Word = "small", Weight = 2 },
                        }
                    },
                    new Line
                    {
                        Phrase = "Haven't you heard _X_",
                        Punches = new Punch[]
                        {
                            new Punch { Word = "making fun of height is no fun", Weight = 0 },
                            new Punch { Word = "tiny is the new cute", Weight = 1 },
                            new Punch { Word = "of one-size-fit-all", Weight = 2 },
                        }
                    },
                    new Line
                    {
                        Phrase = "Sure I may not be that _X_",
                        Punches = new Punch[]
                        {
                            new Punch { Word = "gigantesque", Weight = 0 },
                            new Punch { Word = "big", Weight = 1 },
                            new Punch { Word = "tall", Weight = 2 },
                        }
                    },
                    new Line
                    {
                        Phrase = "But at least I am no _X_",
                        Punches = new Punch[]
                        {
                            new Punch { Word = "schmuck", Weight = 0 },
                            new Punch { Word = "French", Weight = 1 },
                            new Punch { Word = "neanderthal", Weight = 2 },
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
                        Phrase = "It ain't like you have a sense of _X_",
                        Punches = new Punch[]
                        {
                            new Punch { Word = "fashion", Weight = 0 },
                            new Punch { Word = "sight", Weight = 1 },
                            new Punch { Word = "style", Weight = 2 },
                        }
                    },
                    new Line
                    {
                        Phrase = "Being dressed like _X_",
                        Punches = new Punch[]
                        {
                            new Punch { Word = "you only have one set of clothes", Weight = 0 },
                            new Punch { Word = "a dull jokster", Weight = 1 },
                            new Punch { Word = "my little brother", Weight = 2 },
                        }
                    },
                    new Line
                    {
                        Phrase = "Bumpkin white boy trying to _X_",
                        Punches = new Punch[]
                        {
                            new Punch { Word = "be a bad boy", Weight = 0 },
                            new Punch { Word = "say something vile", Weight = 1 },
                            new Punch { Word = "do freestyle", Weight = 2 },
                        }
                    },
                    new Line
                    {
                        Phrase = "Only screams - _X_",
                        Punches = new Punch[]
                        {
                            new Punch { Word = "trying to hard", Weight = 0 },
                            new Punch { Word = "I am an amateur", Weight = 1 },
                            new Punch { Word = "street-cred poser", Weight = 2 },
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
                        Phrase = "You're high in space, but I'm high on _X_",
                        Punches = new Punch[]
                        {
                            new Punch { Word = "crack", Weight = 0 },
                            new Punch { Word = "everyday", Weight = 1 },
                            new Punch { Word = "life", Weight = 2 },
                        }
                    },
                    new Line
                    {
                        Phrase = "Street life, nightlife, up until the _X_",
                        Punches = new Punch[]
                        {
                            new Punch { Word = "wildlife", Weight = 0 },
                            new Punch { Word = "sunrise", Weight = 1 },
                            new Punch { Word = "afterlife", Weight = 2 },
                        }
                    },
                    new Line
                    {
                        Phrase = "Closer to the sun, let me help you _X_",
                        Punches = new Punch[]
                        {
                            new Punch { Word = "get down", Weight = 0 },
                            new Punch { Word = "get a nice tan", Weight = 1 },
                            new Punch { Word = "fly away", Weight = 2 },
                        }
                    },
                    new Line
                    {
                        Phrase = "Icarus first, then you in my _X_",
                        Punches = new Punch[]
                        {
                            new Punch { Word = "telescope", Weight = 0 },
                            new Punch { Word = "bed", Weight = 1 },
                            new Punch { Word = "ashtray", Weight = 2 },
                        }
                    },
                }
            },
        };

        return _track2;
    }
}
