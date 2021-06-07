using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamplePlayer : MonoBehaviour
{
    public int level;
    public int health; 

    public void SavePlayer()
    {
        GameSaveLoad.Save(1, this);
    }
    public void LoadPlayer()
    {
        GameData data = GameSaveLoad.Load(1);

        level = data.level;
        health = data.health;
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }
}
