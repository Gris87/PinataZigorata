using UnityEngine;
using System.Collections;

public class MenuButtonScript : MonoBehaviour
{
	public Transform        mainMenu  = null;
	public SwitchMenuScript nextMenu  = null;
	public AudioClip        clip      = null;
	public float            showDelay = 0f;
	public float            hideDelay = 0f;
	public float            menuDelay = 0f;

	private Animator mAnimator = null;



	private IEnumerator startShowAnimation()
	{
		yield return new WaitForSeconds(showDelay);
		mAnimator.SetTrigger(Global.SHOW_TRIGGER_HASH);
	}

	private IEnumerator startHideAnimation()
	{
		yield return new WaitForSeconds(hideDelay);
		mAnimator.SetTrigger(Global.HIDE_TRIGGER_HASH);
	}

	private IEnumerator startSwithingToNextMenu()
	{
		yield return new WaitForSeconds(menuDelay);
		nextMenu.show();
	}

	private void playSound()
	{
		audio.PlayOneShot(clip, 1); // TODO: Options.effectsVolume);
	}

	private void hide()
	{
		for (int i=0; i<mainMenu.childCount; ++i)
		{
			MenuButtonScript menuButtonScript = mainMenu.GetChild(i).GetComponent<MenuButtonScript>();

			if (menuButtonScript)
			{
				StartCoroutine(menuButtonScript.startHideAnimation());
			}
		}
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
		hide();

		StartCoroutine(startSwithingToNextMenu());
	}
	
	public void OnSettingsClicked()
	{
		Debug.Log("Settings pressed");

		playSound();
		hide();

		StartCoroutine(startSwithingToNextMenu());
	}

	public void OnExitClicked()
	{
		playSound();
		exitApp();
	}
	
	void OnEnable()
	{
		if (mAnimator == null)
		{
			mAnimator = GetComponent<Animator>();
		}

		StartCoroutine(startShowAnimation());
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
