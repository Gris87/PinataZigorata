using UnityEngine;
using System.Collections;

public class AudioSourceScript : MonoBehaviour
{
	public AudioClip clickClip;



	public void playClip(AudioClip clip, float volume = 1)
	{
		audio.PlayOneShot(clip, volume);
	}

	public void playClickClip()
	{
		playClip(clickClip); // TODO: Options.effectsVolume);
	}
}
