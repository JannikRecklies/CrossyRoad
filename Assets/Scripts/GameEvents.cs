using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class GameEvents
{
    public static event Action<int> OnPlayerDied;

    public static void PlayerDied(int score)
    {
        // ensures that the event is only raised if there are methods subscribed to it
        if (OnPlayerDied != null)
        {
            OnPlayerDied(score);
        }
    }
}
