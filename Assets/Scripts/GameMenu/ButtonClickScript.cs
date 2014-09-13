using UnityEngine;
using System.Collections;

public class ButtonClickScript : MonoBehaviour
{
	public AudioClip clip;

	private void playSound()
	{
		audio.PlayOneShot(clip, 1); // TODO: Options.effectsVolume);
	}

	public void OnNewGameClicked()
	{
		Debug.Log("New game pressed");

		playSound();
	}
	
	public void OnSettingsClicked()
	{
		Debug.Log("Settings pressed");

		playSound();
	}

	public void OnExitClicked()
	{
		Debug.Log("Application finished");
		Application.Quit();

		playSound();
	}
}
