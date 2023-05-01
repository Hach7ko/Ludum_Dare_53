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
                        Phrase = "Yo -, let me start this _X_",
                        Punches = new Punch[]
                        {
                            new Punch { Word = "delivery", Weight = 0 },
                            new Punch { Word = "battle", Weight = 1 },
                            new Punch { Word = "flow", Weight = 2 },
                        }
                    },
                    new Line
                    {
                        Phrase = "My skill's so high, yours' _X_",
                        Punches = new Punch[]
                        {
                            new Punch { Word = "meh.", Weight = 0 },
                            new Punch { Word = "a joke", Weight = 1 },
                            new Punch { Word = "near zero", Weight = 2 },
                        }
                    },
                    new Line
                    {
                        Phrase = "I'll take you for a ride, _X_",
                        Punches = new Punch[]
                        {
                            new Punch { Word = "jump in my car", Weight = 0 },
                            new Punch { Word = "a real rollercoaster", Weight = 1 },
                            new Punch { Word = "a rodeo", Weight = 2 },
                        }
                    },
                    new Line
                    {
                        Phrase = "Oh wait -, first you should _X_",
                        Punches = new Punch[]
                        {
                            new Punch { Word = "wipe you feet", Weight = 0 },
                            new Punch { Word = "go", Weight = 1 },
                            new Punch { Word = "grow", Weight = 2 },
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
                        Phrase = "Coming from _X_, I've seen some shit",
                        Punches = new Punch[]
                        {
                            new Punch { Word = "the neighbors'", Weight = 0 },
                            new Punch { Word = "the 90's", Weight = 1 },
                            new Punch { Word = "the fire age", Weight = 2 },
                        }
                    },
                    new Line
                    {
                        Phrase = "_X_, all kind of memories",
                        Punches = new Punch[]
                        {
                            new Punch { Word = "Free food, free drinks", Weight = 0 },
                            new Punch { Word = "Gameboy, MTV", Weight = 1 },
                            new Punch { Word = "Mammoths, dodos", Weight = 2 },
                        }
                    },
                    new Line
                    {
                        Phrase = "But I'll tell you what, I'm no _X_",
                        Punches = new Punch[]
                        {
                            new Punch { Word = "freeloader", Weight = 0 },
                            new Punch { Word = "random gen X kid", Weight = 1 },
                            new Punch { Word = "hypocrite", Weight = 2 },
                        }
                    },
                    new Line
                    {
                        Phrase = "I never thaught I'd see a _X_",
                        Punches = new Punch[]
                        {
                            new Punch { Word = "butler", Weight = 0 },
                            new Punch { Word = "a rapper in their jammies", Weight = 1 },
                            new Punch { Word = "real teletubbies", Weight = 2 },
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
                        Phrase = "Some like chocolate, some like _X_",
                        Punches = new Punch[]
                        {
                            new Punch { Word = "Jeff Bezos", Weight = 0 },
                            new Punch { Word = "pizza", Weight = 1 },
                            new Punch { Word = "vanilla", Weight = 2 },
                        }
                    },
                    new Line
                    {
                        Phrase = "Denim, cap and jacket, from the _X_",
                        Punches = new Punch[]
                        {
                            new Punch { Word = "H&M store", Weight = 0 },
                            new Punch { Word = "closet", Weight = 1 },
                            new Punch { Word = "city's market", Weight = 2 },
                        }
                    },
                    new Line
                    {
                        Phrase = "That's my gear of choice, _X_",
                        Punches = new Punch[]
                        {
                            new Punch { Word = "420 ilvl", Weight = 0 },
                            new Punch { Word = "I'm not dancing rumba", Weight = 1 },
                            new Punch { Word = "for clashing with ya", Weight = 2 },
                        }
                    },
                    new Line
                    {
                        Phrase = "There's no bringin' me down, not without a _X_",
                        Punches = new Punch[]
                        {
                            new Punch { Word = "xanax", Weight = 0 },
                            new Punch { Word = "fight", Weight = 1 },
                            new Punch { Word = "rocket", Weight = 2 },
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
