using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhrasesManager : MonoBehaviour
{
    #region SINGLETON
    //Turn this class into a Singleton
    private static PhrasesManager instance;
    public static PhrasesManager Instance
    {
        get
        {
            if(instance == null)
            Debug.LogError("PhrasesManager is NULL");

            return instance; 
        }
    } 
    #endregion
    [SerializeField] private List<string> thePhrases;
    //public List<string> ThePhrases {get{return thePhrases;}}
    private List<string> thePhrasesFound = new List<string>(); //of thePhrase
    [Header("References")]
    public UITxtUpdater sUIPhrasesFound;
    //
    int indexCorrectPhrase = 0;

    private void Awake() 
    {
        instance = this; //Singleton

        InitializePhrases();
    }

    //Call at Awake
    private void InitializePhrases()
    {
        PhrasesAvailable.Instance.InitializePhrases(thePhrases);
        UpdateUI();
    }
    private void UpdateUI()
    {
        //Build the string
        string theString = "";
        if(thePhrasesFound.Count > 0)
        foreach (var phrase in thePhrasesFound)
        {
            theString += phrase + " ";
        }
        //Update UI
        sUIPhrasesFound.UpdateUI(theString);
    }
    public bool IsCorrect_OnPhraseFound(string phraseFound)
    {
        if(thePhrases[indexCorrectPhrase].Equals(phraseFound))
        {
            indexCorrectPhrase++;
            thePhrasesFound.Add(phraseFound);
            OnPhraseFoundCorrect();
            if(indexCorrectPhrase == thePhrases.Count)
                OnAllPhrasesFound();
            return true;
        }            
        else
        {
            OnPhraseFoundIncorrect();
            return false;
        }            
    }
    private void OnPhraseFoundCorrect()
    {
        //Actions for all kinds of phraseHolders
        UpdateUI();
    }
    private void OnPhraseFoundIncorrect()
    {
        //Actions for all kinds of phraseHolders

    }
    private void OnAllPhrasesFound()
    {
        //Game over? or More phrases?

    }
}
