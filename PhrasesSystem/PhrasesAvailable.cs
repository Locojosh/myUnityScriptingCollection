using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhrasesAvailable : MonoBehaviour
{
    #region SINGLETON
    //Turn this class into a Singleton
    private static PhrasesAvailable instance;
    public static PhrasesAvailable Instance
    {
        get
        {
            if(instance == null)
            Debug.LogError("PhrasesAvailable is NULL");

            return instance; 
        }
    } 
    #endregion
    private List<string> thePhrases;
    public List<string> ThePhrases {get{return thePhrases;}}

    private void Awake() 
    {
        instance = this; //Singleton
    }

    public void InitializePhrases(List<string> value)
    {
        thePhrases = new List<string>(value);
    }

    public string GetPhrase()
    {
        string phrase = thePhrases[0];
        thePhrases.RemoveAt(0);

        return phrase;
    }
}
