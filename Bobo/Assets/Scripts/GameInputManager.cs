using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public static class GameInputManager
{
    static Dictionary<string, KeyCode> keyMapping;
    public enum keyMaps{Shoot,Jump};

    public static KeyCode[] defaults = new KeyCode[2]
    {
        KeyCode.X,
        KeyCode.Z
    };

    static GameInputManager()
    {
        InitializeDictionary();
    }

    private static void InitializeDictionary()
    {
        keyMapping = new Dictionary<string, KeyCode>();
        for (int i = 0; i < 2; ++i)
        {
            keyMapping.Add(((keyMaps)i).ToString(), defaults[i]);
        }
    }

    public static void SetKeyMap(string keyMap, KeyCode key)
    {
        if (!keyMapping.ContainsKey(keyMap))
            throw new ArgumentException("Invalid KeyMap in SetKeyMap: " + keyMap);
        keyMapping[keyMap] = key;
        if(keyMap=="Jump"){
            defaults[1]=key;
        }
        else{
            defaults[0]=key;
        }
    }

    public static bool GetKeyDown(string keyMap)
    {
        return Input.GetKeyDown(keyMapping[keyMap]);
    }

    public static bool GetKey(string keyMap)
    {
        return Input.GetKey(keyMapping[keyMap]);
    }

    public static KeyCode GetButton(string button)
    {
        return keyMapping[button];
    }


    /*public static string[] GetKeyMaps()
    {
        return keyMaps;
    }*/
}