using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerData3D
{
    public bool correct;
    public int playedInterval;
    public int answeredInterval;
    public string firstNote;
    public string secondNote;
    public float time;

    // Constructor
    // This class can not be monobehaviour
    public AnswerData3D(bool correct, int playedInterval, int answeredInterval,
        string first_note, string second_note, float time)
    {
        this.correct = correct;
        this.playedInterval = playedInterval;
        this.answeredInterval = answeredInterval;
        this.firstNote = first_note;
        this.secondNote = second_note;
        this.time = time;
    }
}
