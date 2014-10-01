using UnityEngine;
using System.Collections;

public class AudioSourceScript : MonoBehaviour
{
	public AudioClip clip         = null;	
	public bool      soundPlaying = true;



	public void playClip(AudioClip clip, float volume = 1)
	{
		audio.PlayOneShot(clip, volume);
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
        if (audio.pitch != Time.timeScale)
        {
            audio.pitch = Time.timeScale;
        }
        
        if (soundPlaying)
        {
            if (audio.volume != Settings.SoundVolume)
            {
                audio.volume = Settings.SoundVolume;
            }
        }
        else
        {
            if (audio.volume != Settings.MusicVolume)
            {
                audio.volume = Settings.MusicVolume;
            }
        }
    }
}
