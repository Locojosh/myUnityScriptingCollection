using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhraseHoldersManager : MonoBehaviour
{
    [Header("*Each pool member must have a PhraseHolder script component")]
    public PoolManager sPhraseHoldersPoolManager;

    //***NOTE*** One of the Initializer methods below must be called at Start
   
    private void InitializeAll()
    {
        int poolSize = PhrasesAvailable.Instance.ThePhrases.Count;
        Initialize(poolSize);
    }
    public void InitializeQuantity(int quantity)
    {
        int maxSize = PhrasesAvailable.Instance.ThePhrases.Count;
        if(maxSize == 0) Debug.LogError("No phrases available to initialize phrase holders!");
        if(quantity > maxSize) quantity = maxSize;
        Initialize(quantity);
    }
    private void Initialize(int poolSize)
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject newHolder = sPhraseHoldersPoolManager.RequestObject();
            newHolder.GetComponent<PhraseHolder>().InitializePhrase();
        }
    }
}
