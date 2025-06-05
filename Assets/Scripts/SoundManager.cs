using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SoundManager : MonoBehaviour
{

    public List<AudioClip> clips;
    public static SoundManager singleton;
    public AudioSource source;

    void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
        }
    }

    public void PlaySound(int index)
    {
        source.Stop();
        source.clip = clips[index];
        source.Play();
    }
}
