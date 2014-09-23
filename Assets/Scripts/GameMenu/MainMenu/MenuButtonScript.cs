using UnityEngine;
using System.Collections;

public class MenuButtonScript : MonoBehaviour
{
	public Transform         mainMenu          = null;
	public SwitchMenuScript  nextMenu          = null;
	public AudioSourceScript audioSourceScript = null;
	public float             showDelay         = 0f;
	public float             hideDelay         = 0f;
	public float             menuDelay         = 0f;

	private Animator mAnimator         = null;
	private Vector3  mOriginalPosition = new Vector3(-1000, 0, 0);



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
		nextMenu.goNext();
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

		audioSourceScript.playClickClip();
		hide();

		StartCoroutine(startSwithingToNextMenu());
	}
	
	public void OnSettingsClicked()
	{
		Debug.Log("Settings pressed");

		audioSourceScript.playClickClip();
		hide();

		StartCoroutine(startSwithingToNextMenu());
	}

	public void OnExitClicked()
	{
		audioSourceScript.playClickClip();
		exitApp();
	}

	void OnDisable()
	{
		GetComponent<RectTransform>().localPosition = mOriginalPosition;
	}
	
	void OnEnable()
	{
		if (mOriginalPosition.x <= -1000)
		{
			mOriginalPosition = GetComponent<RectTransform>().localPosition;
		}

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
