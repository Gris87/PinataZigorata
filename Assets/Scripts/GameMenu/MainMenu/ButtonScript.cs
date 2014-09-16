using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour
{
	private static int SHOW_TRIGGER_HASH = Animator.StringToHash("Show");
	private static int HIDE_TRIGGER_HASH = Animator.StringToHash("Hide");



	public AudioClip clip      = null;
	public float 	 showDelay = 0f;
	public float	 hideDelay = 0f;

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
		yield return new WaitForSeconds(showDelay);
		mAnimator.SetTrigger(SHOW_TRIGGER_HASH);
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
