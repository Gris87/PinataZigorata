using UnityEngine;
using System.Collections;

public class AudioSourceScript : MonoBehaviour
{
    public AudioClip clip         = null;
    public bool      soundPlaying = true;



    public void playClip(AudioClip clip, float volume = 1)
    {
        GetComponent<AudioSource>().PlayOneShot(clip, volume);
    }

    public void playSoundClip(AudioClip clip)
    {
        playClip(clip, Settings.SoundVolume);
    }

    public void playMusicClip(AudioClip clip)
    {
        playClip(clip, Settings.MusicVolume);
    }

    public void playClip()
    {
        if (soundPlaying)
        {
            playSoundClip(clip);
        }
        else
        {
            playMusicClip(clip);
        }
    }

    // Update is called once per frame
    void Update()
    {
        AudioSource audioSource = GetComponent<AudioSource>();

        if (audioSource.pitch != Time.timeScale)
        {
            audioSource.pitch = Time.timeScale;
        }

        if (soundPlaying)
        {
            if (audioSource.volume != Settings.SoundVolume)
            {
                audioSource.volume = Settings.SoundVolume;
            }
        }
        else
        {
            if (audioSource.volume != Settings.MusicVolume)
            {
                audioSource.volume = Settings.MusicVolume;
            }
        }
    }
}
