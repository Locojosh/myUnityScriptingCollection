using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives_Sprites : MonoBehaviour
{
    #region SINGLETON
    private static Lives_Sprites instance;
    public static Lives_Sprites Instance
    {
        get
        {
            if(instance == null)
            Debug.LogError("Lives_Sprites is NULL");

            return instance; 
        }
    }    
    #endregion
    private int lives;
    public Sprite[] spritesLives;
    private SpriteRenderer rend;

    private void Awake() 
    {
        instance = this; //Singleton
        rend = GetComponent<SpriteRenderer>();
    }
    private void Start() 
    {
        lives = spritesLives.Length -1;
        rend.sprite = spritesLives[lives];
    }

    public void LoseLife()
    {
        lives--;
        rend.sprite = spritesLives[lives];

        if(lives <= 0)
        {
            Die();
        }
    }
    
    private void Die()
    {
        Debug.Log("You dead!");
    }
}
