using System;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Singleton
    //Turn this class into a Singleton
    private static AudioManager instance;
    public static AudioManager Instance
    {
        get
        {
            if(instance == null)
            Debug.LogError("AudioManager is NULL");

            return instance; 
        }
    }    
    #endregion
    public Sound[] sounds;

    private void Awake() 
    {
        instance = this; //Singleton

        foreach(var s in sounds)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();

            s.audioSource.clip = s.clip;
            s.audioSource.volume = s.volume;
            s.audioSource.pitch = s.pitch;
            s.audioSource.loop = s.loop;
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
}
