using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue //Dialogue for DialogueManager
{
    public string name;
    [TextArea(3,10)]
    public string[] sentences;
}
