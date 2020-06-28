using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMute : MonoBehaviour
{
    private AudioManager audioManager;
    private float[] levels;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();

        levels = new float[audioManager.sounds.Length];
        for (int i = 0; i < levels.Length; i++)
        {
            levels[i] = audioManager.sounds[i].volume;
        }
    }
    public void Mute()
    {
        audioManager.Play("Click");
        foreach (Sound s in audioManager.sounds)
        {
            s.source.volume = 0;
        }

    }
    public void Amplify()
    {
        for (int i = 0; i < levels.Length; i++)
        {
            audioManager.sounds[i].source.volume = levels[i];
        }
    }
}
