using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStats
{
    public static bool challengeMode=false;
    public static bool shootRate=false;
    public static int checkpoint=0;
    public static bool end=false;
    public static bool dead=false;
    public static bool hardMode=false;
    [SerializeField]public static int health = 3;
    [SerializeField]public static int money = 0;
    [SerializeField]public static int key=0;
    [SerializeField]public static int score=0;
    [SerializeField]public static string name = "---";

    public static bool purpleShot=false;
    public static int damage=1;

    public static int wave=0;
}
