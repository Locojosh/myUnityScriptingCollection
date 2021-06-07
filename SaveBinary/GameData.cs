using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int level;
    public int health;
    public float[] position = new float[3];
    public GameData(ExamplePlayer player) //Constructor to create class.. include another class as parameter
    {
        level = player.level;
        health = player.health;
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}
