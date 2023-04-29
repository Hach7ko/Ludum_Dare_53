using Godot;
using System;

public partial class Roulyo : Performer
{
    public override void _Ready()
    {
        base._Ready();

        _track.Verses = new Verse[]
        {
            new Verse
            {
                Lines = new Line[]
                {
                    new Line
                    {
                        Phrase = "Non non, bof bof, tu _X_",
                        Punches = new WeightedWord[]
                        {
                            new WeightedWord { Word = "pues", Weight = 0 },
                            new WeightedWord { Word = "fouettes", Weight = 1 },
                            new WeightedWord { Word = "prends ton cul pour une trompette", Weight = 2 },
                        }
                    },
                    // new Line
                    // {
                    // },
                }
            },
            // new Verse
            // {
            // },
        };

        PrintTrack();
    }
}
