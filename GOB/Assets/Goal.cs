﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal
{
    public string goalName;
    public float value;
    float baseChange;

    float timeSinceLastDecision;
    float valueAtPreviousDecision;
    
    public Goal (string name, float value, float change)
    {
        goalName = name;
        this.value = value;
        baseChange = change;
    }
    public float GetDiscontentment(float newValue) { return newValue * newValue; }
    public float GetChange() {

        //float rateOverTime = (value - valueAtPreviousDecision)/timeSinceLastDecision;
        //baseChange = 1.0f * baseChange - 0.05f * rateOverTime;

        return baseChange;
    }
    public void SatisfyGoal(Action actionToPerform)
    {
        timeSinceLastDecision = 0;
        value -= actionToPerform.GetGoalChange(this);
        value = (value < 0) ? 0 : value;
        Debug.Log("Goal " + goalName + " changed to " + value.ToString("F2"));
    } 
    public void IncreaseNeed() { 
        value += baseChange;
        timeSinceLastDecision++;
    }

}
