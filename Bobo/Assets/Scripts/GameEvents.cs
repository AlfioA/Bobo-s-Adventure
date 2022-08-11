using System;
using UnityEngine;

public class GameEvents
{
    private static GameEvents _instance;

    public static GameEvents Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new GameEvents();
            }
            return _instance;
        }
    }

    private event Action onPlayerDeath;

    public event Action OnPlayerDeath
    {
        add
        {
            onPlayerDeath -= value;
            onPlayerDeath += value;
        }
        remove
        {
            onPlayerDeath -= value;
        }
    }

    public void TriggerOnPlayerDeath()
    {
        if (onPlayerDeath != null)
        {
            onPlayerDeath();
        }
    }
}
