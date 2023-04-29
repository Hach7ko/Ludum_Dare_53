using Godot;
using System;

public partial class Samoussa : Performer
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
                        Phrase = "Ouais ouais, si si, la _X_",
                        Punches = new WeightedWord[]
                        {
                            new WeightedWord { Word = "girafe", Weight = 0 },
                            new WeightedWord { Word = "pizza", Weight = 1 },
                            new WeightedWord { Word = "famille", Weight = 2 },
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
