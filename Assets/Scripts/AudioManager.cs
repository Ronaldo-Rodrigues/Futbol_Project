using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    //musica BG
    public AudioClip[] clips;
    public AudioSource musicaBG;
    //sons FX
    public AudioClip[] clipsFX;
    public AudioSource sonsFX;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    AudioClip GetRandom()
    {
        return clips[Random.Range(0, clips.Length)];
    }
  
    void Update()
    {
        if (!musicaBG.isPlaying)
        {
            musicaBG.clip = GetRandom();
            musicaBG.Play();
        }
    }

    public void SonsFXToca(int index)
    {
        sonsFX.clip = clipsFX[index];
        sonsFX.Play();
    }
}
