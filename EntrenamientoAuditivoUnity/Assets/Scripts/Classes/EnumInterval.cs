// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// Enumeration that defines intervals that are going to be used in the game
// The value is asigned according to the number of semitones that separate the notes in each interval
public enum Interval
{
    None = -1,

    MinorSecond = 1,
    MajorSecond,
    MinorThird,
    MajorThird,
    PerfectFourth,
    AugmentedFourth,
    PerfectFifth,
    MinorSixth,
    MajorSixth,
    MinorSeventh,
    MajorSeventh
};

public class EnumInterval {

    // Returns the interval between two notes, given its ID
    public static Interval determineInterval(int firstNote, int secondNote)
    {
        int semitones = Mathf.Abs(secondNote - firstNote);

        if (semitones < (int)(Interval.MinorSecond) || semitones > (int)(Interval.MajorSeventh))
        {
            return Interval.None;
        }
        return (Interval)semitones;
    }
    
}
