using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Difficulty
{
    static float timeToMaxDiff = 60;

    public static float GetDifficulty() 
    {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / timeToMaxDiff);
    }
}
