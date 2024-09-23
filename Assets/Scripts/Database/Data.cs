using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data
{


    public static readonly AgentFlyweight basicAgent = new AgentFlyweight
    {
        MaxSpeed = 10,
        MaxTemp = 30,
        MaxWood = 10,
        MaxFood = 10,
        MaxHunger = 100,
        MaxSteering = 10
    };
    /*public static readonly WorldData GetWarmData = new WorldData
    {
        temp = 100,
        health = 50,
        hunger = 50,
        hasFirepit = true,
        item = Item.WOOD,
    };*/

    public static readonly WorldData CurrentWorldData = new WorldData
    {
        hasFirepit = true,

    };
}
