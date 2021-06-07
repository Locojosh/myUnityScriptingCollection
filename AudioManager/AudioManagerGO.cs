using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManagerGO : MonoBehaviour
{
    #region Singleton
    //Turn this class into a Singleton
    private static AudioManagerGO instance;
    public static AudioManagerGO Instance
    {
        get
        {
            if(instance == null)
            Debug.LogError("AudioManagerGO is NULL");

            return instance; 
        }
    }    
    #endregion
    public Sound[] sounds;
    [SerializeField] private GameObject[] soundsPositions;

    private void Awake() 
    {
        instance = this; //Singleton

        soundsPositions = new GameObject[sounds.Length];
        for (int i = 0; i < soundsPositions.Length; i++)
        {
            soundsPositions[i] = new GameObject("Sound_" + sounds[i].name);
        }

        for (int i = 0; i < sounds.Length; i++)
        {
            sounds[i].audioSource = soundsPositions[i].AddComponent<AudioSource>();

            sounds[i].audioSource.clip = sounds[i].clip;
            sounds[i].audioSource.volume = sounds[i].volume;
            sounds[i].audioSource.pitch = sounds[i].pitch;
            sounds[i].audioSource.loop = sounds[i].loop;

            if(sounds[i].maxDistance != 0)
            {
                sounds[i].audioSource.spatialBlend = 1.0f;
                sounds[i].audioSource.maxDistance = sounds[i].maxDistance;  
            }                      
        }  
    }
    
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if(s == null)
        {
            Debug.LogWarning("Sound "+ name + " not found");
            return;
        }

        s.audioSource.Play();
    }
    public void Play(string name, Vector3 pos)
    {
        int index = Array.FindIndex(sounds, sound => sound.name == name);

        Sound s = sounds[index];
        if(s == null)
        {
            Debug.LogWarning("Sound "+ name + " not found");
            return;
        }
        else
        {
            soundsPositions[index].transform.position = pos;
            s.audioSource.Play();
        }
    }
}
