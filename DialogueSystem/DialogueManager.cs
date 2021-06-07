using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    #region Singleton
    private static DialogueManager instance;
    public static DialogueManager Instance
    {
        get
        {
            if(instance == null)
                Debug.LogError("DialogueManager is NULL");

            return instance;
        }
    }    
    #endregion
    public Queue<string> sentences; //Sentences for dialogue
    public TextMeshProUGUI nameText; //Name of NPC
    public TextMeshProUGUI dialogueText; //Text of NPC
    public Animator animatorDialogue; //Animator for dialogue opening/closing
    private void Start() 
    {
        instance = this; //Singleton
        sentences = new Queue<string>();
    }
    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting dialogue with " + dialogue.name);
        nameText.text = dialogue.name;
        animatorDialogue.SetBool("IsOpen", true);

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
    }
    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }
    private void EndDialogue() //Actions after end of conversation here
    {
        Debug.Log("Fin de conversacion");
        animatorDialogue.SetBool("IsOpen", false);
    }
}
