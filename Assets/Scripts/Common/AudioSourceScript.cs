using UnityEngine;
using System.Collections;

public class AudioSourceScript : MonoBehaviour
{
	public AudioClip clickClip;



	public void playClip(AudioClip clip, float volume = 1)
	{
		audio.PlayOneShot(clip, volume);
	}

	public void playSoundClip(AudioClip clip)
	{
		if (Settings.SoundEnabled)
		{
			playClip(clip, Settings.SoundVolume);
		}
	}

	public void playMusicClip(AudioClip clip)
	{
		if (Settings.MusicEnabled)
		{
			playClip(clip, Settings.MusicVolume);
		}
	}

	public void playClickClip()
	{
		playSoundClip(clickClip);
	}
}
