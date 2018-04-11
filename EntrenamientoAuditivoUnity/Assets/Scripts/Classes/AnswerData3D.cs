using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerData3D
{
    public bool correct;
    public int playedInterval;
    public int answeredInterval;
    public string firstNote;
    public string expectedNote;
    public string inputNote;
    public float time;

    // Constructor
    // This class can not be monobehaviour
    public AnswerData3D(bool correct, int playedInterval, int answeredInterval,
        string firstNote, string expectedNote, string inputNote, float time)
    {
        this.correct = correct;
        this.playedInterval = playedInterval;
        this.answeredInterval = answeredInterval;
        this.firstNote = firstNote;
        this.expectedNote = expectedNote;
        this.inputNote = inputNote;
        this.time = time;
    }
}
