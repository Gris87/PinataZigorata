using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour
{
	private static int SHOW_TRIGGER_HASH = Animator.StringToHash("Show");
	private static int HIDE_TRIGGER_HASH = Animator.StringToHash("Hide");



	public GameObject              newGameMenu             = null;
	public NewGameScrollRectScript newGameScrollRectScript = null;
	public GameObject              settingsMenu            = null;
	public AudioClip               clip                    = null;
	public float                   showDelay               = 0f;
	public float                   hideDelay               = 0f;
	public float                   menuDelay               = 0f;

	private Animator mAnimator;



	private IEnumerator startHideAnimation()
	{
		yield return new WaitForSeconds(hideDelay);
		mAnimator.SetTrigger(HIDE_TRIGGER_HASH);
	}

	private IEnumerator startShowAnimation()
	{
		yield return new WaitForSeconds(showDelay);
		mAnimator.SetTrigger(SHOW_TRIGGER_HASH);
	}

	private IEnumerator newGame()
	{
		yield return new WaitForSeconds(menuDelay);

		// Disable main menu
		transform.parent.gameObject.SetActive(false);

		newGameMenu.SetActive(true);
		newGameScrollRectScript.show();
	}

	private IEnumerator settings()
	{
		yield return new WaitForSeconds(menuDelay);

		// Disable main menu
		transform.parent.gameObject.SetActive(false);

		settingsMenu.SetActive(true);
		// TODO: Show settings menu
	}

	private void playSound()
	{
		audio.PlayOneShot(clip, 1); // TODO: Options.effectsVolume);
	}

	private void hide()
	{
		Transform parent = transform.parent;

		for (int i=0; i<parent.childCount; ++i)
		{
			ButtonScript buttonScript = parent.GetChild(i).GetComponent<ButtonScript>();

			if (buttonScript)
			{
				StartCoroutine(buttonScript.startHideAnimation());
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

		StartCoroutine(newGame());
	}
	
	public void OnSettingsClicked()
	{
		Debug.Log("Settings pressed");

		playSound();
		hide();

		StartCoroutine(settings());
	}

	public void OnExitClicked()
	{
		playSound();
		exitApp();
	}

	// Use this for initialization
	void Start()
	{
		mAnimator = GetComponent<Animator>();

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
