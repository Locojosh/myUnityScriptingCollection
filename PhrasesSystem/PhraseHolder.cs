using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhraseHolder : MonoBehaviour
{
    string phrase;
    public UITxtUpdater sUIPhrase;

    public void InitializePhrase()
    {
        phrase = PhrasesAvailable.Instance.GetPhrase();
        UpdateUI();
    }
    public bool IsCorrect_OnPhraseFound()
    {
        if(PhrasesManager.Instance.IsCorrect_OnPhraseFound(phrase))
            return true;
        return false;
    }
    private void UpdateUI()
    {
        sUIPhrase.UpdateUI(phrase);
    }
}
