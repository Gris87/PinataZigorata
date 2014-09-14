using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour
{
	private static int APPEAR_ANIMATION_HASH    = Animator.StringToHash("Appear");
	private static int DISAPPEAR_ANIMATION_HASH = Animator.StringToHash("Disappear");



	public AudioClip clip;
	public float 	 appearDelay;
	public float	 disappearDelay;

	private Animator mAnimator;



	private void playSound()
	{
		audio.PlayOneShot(clip, 1); // TODO: Options.effectsVolume);
	}

	private void exitApp()
	{
		Debug.Log("Application finished");
		Application.Quit();
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
		playSound();
		exitApp();
	}

	IEnumerator appear()
	{
		yield return new WaitForSeconds(appearDelay);
		mAnimator.SetTrigger(APPEAR_ANIMATION_HASH);
	}

	// Use this for initialization
	void Start()
	{
		mAnimator = GetComponent<Animator>();

		StartCoroutine(appear());
	}

	// Update is called once per frame
	void Update()
	{
		// TODO: Uncomment it
		/*
        if (InputControl.GetKeyDown(KeyCode.Escape))
        {
			exitApp();
        }
		*/
	}
}
